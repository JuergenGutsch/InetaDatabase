using System;
using System.Collections.Generic;

namespace Gos.Tools.Cqs.Command
{
    public class CommandPreconditionCheckException : Exception
    {
        public CommandPreconditionCheckException()
        {
        }

        public CommandPreconditionCheckException(IList<string> validationMessages)
        {
            ValidationMessages = validationMessages;
        }

        public IList<string> ValidationMessages { get; private set; }
    }
}