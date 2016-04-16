using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Gos.Tools.Cqs.Command
{
    public class CommandDispatcher : ICommandDispatcher
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly ILogger _logger;

        public CommandDispatcher(ILoggerFactory loggerFactory, IServiceProvider serviceProvider)
        {
            _logger = loggerFactory.CreateLogger<CommandDispatcher>();
            _serviceProvider = serviceProvider;
        }

        public void DispatchCommand<TCommand>(TCommand command) where TCommand : ICommand
        {
            _logger.LogDebug("Dispatching command {0}", command);
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            CheckAllPreconditions(command);

            var handlers = _serviceProvider.GetServices<ICommandHandler<TCommand>>();
            foreach (var handler in handlers)
            {
                handler.Handle(command);
            }

            stopwatch.Stop();
            _logger.LogInformation("Execution time for command {0}: {1}", command, stopwatch.Elapsed.ToString("g"));
        }

        public async Task DispatchCommandAsync<TCommand>(TCommand command) where TCommand : ICommand
        {
            _logger.LogDebug("Dispatching command {0}", command);
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            CheckAllPreconditions(command);

            var handlers = _serviceProvider.GetServices<IAsyncCommandHandler<TCommand>>();
            foreach (var handler in handlers)
            {
                await handler.HandleAsync(command).ConfigureAwait(false);
            }

            stopwatch.Stop();
            _logger.LogInformation("Execution time for command {0}: {1}", command, stopwatch.Elapsed.ToString("g"));
        }

        public TReturn DispatchCommand<TCommand, TReturn>(TCommand command) where TCommand : ICommand
        {
            _logger.LogDebug("Dispatching command {0}", command);
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            CheckAllPreconditions(command);
            var handler = _serviceProvider.GetService<ICommandHandler<TCommand, TReturn>>();
            var result = handler.Handle(command);

            stopwatch.Stop();
            _logger.LogInformation("Execution time for command {0}: {1}", command, stopwatch.Elapsed.ToString("g"));

            return result;
        }

        public async Task<TReturn> DispatchCommandAsync<TCommand, TReturn>(TCommand command) where TCommand : ICommand
        {
            _logger.LogDebug("Dispatching command {0}", command);
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            CheckAllPreconditions(command);
            var handler = _serviceProvider.GetService<IAsyncCommandHandler<TCommand, TReturn>>();
            var result = await handler.HandleAsync(command).ConfigureAwait(false);

            stopwatch.Stop();
            _logger.LogInformation("Execution time for command {0}: {1}", command, stopwatch.Elapsed.ToString("g"));

            return result;
        }

        private void CheckAllPreconditions<TCommand>(TCommand command) where TCommand : ICommand
        {
            // We should enable contravariant bindings in Ninject to get directly precondition for every basetype,
            // but we are not that safe.
            // 1) Get the Base Command conditions
            var results = _serviceProvider.GetServices<ICommandPrecondition<ICommand>>().ToList().Select(condition => condition.Check(command)).ToList();

            //// 2) Get the secured command conditions
            //var securedCommand = command as BaseSecuredCommand;
            //if (securedCommand != null)
            //{
            //    _serviceProvider.GetServiceAll<ICommandPrecondition<BaseSecuredCommand>>().ToList().ForEach(condition => condition.Check(securedCommand));
            //}

            // 3) Get the specific conditions
            foreach (var condition in _serviceProvider.GetServices<ICommandPrecondition<TCommand>>())
            {
                results.Add(condition.Check(command));
            }

            if (results.Any(t => !t.IsValid))
            {
                throw new CommandPreconditionCheckException(results.SelectMany(result => result.ValidationMessages).ToList());
            }
        }
    }
}