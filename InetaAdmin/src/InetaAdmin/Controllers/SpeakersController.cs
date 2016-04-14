using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Gos.Tools.Cqs.Command;
using Gos.Tools.Cqs.Query;
using InetaAdmin.Database.Entities;
using InetaAdmin.Infrastructure.Read.Queries;
using Microsoft.AspNet.Mvc;

namespace InetaAdmin.Controllers
{
    [Route("api/[controller]")]
    public class SpeakersController : Controller
    {
        private readonly IQueryProcessor _queryProcessor;
        private readonly ICommandDispatcher _commandDispatcher;

        public SpeakersController(
            IQueryProcessor queryProcessor,
            ICommandDispatcher commandDispatcher)
        {
            _queryProcessor = queryProcessor;
            _commandDispatcher = commandDispatcher;
        }

        [HttpGet]
        public async Task<IEnumerable<Speaker>> Get()
        {
            var query = new AllSpeakersQuery();
            var speakers = await _queryProcessor.ProcessAsync(query);
            return speakers;
        }

        [HttpGet("{id}")]
        public async Task<Speaker> Get(Guid id)
        {
            var query = new SpeakerByIdQuery(id);
            var speakers = await _queryProcessor.ProcessAsync(query);
            return speakers;
        }

        [HttpPost]
        public async void Post([FromBody]Speaker value)
        {
            var command = new InsertSpeakerCommand(value);
            await _commandDispatcher.DispatchCommandAsync(command);
        }

        [HttpPut("{id}")]
        public async void Put(int id, [FromBody]Speaker value)
        {
            var command = new UpdateSpeakerCommand(id, value);
            await _commandDispatcher.DispatchCommandAsync(command);
        }

        [HttpDelete("{id}")]
        public async void Delete(int id)
        {
            var command = new DeleteSpeakerCommand(id);
            await _commandDispatcher.DispatchCommandAsync(command);
        }
    }
}
