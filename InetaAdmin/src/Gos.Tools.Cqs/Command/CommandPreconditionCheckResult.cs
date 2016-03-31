using System.Collections.Generic;

namespace Gos.Tools.Cqs.Command
{
    public class CommandPreconditionCheckResult
    {
        public CommandPreconditionCheckResult()
        {
            IsValid = true;
            ValidationMessages = new List<string>();
        }

        public bool IsValid { get; set; }
        public IList<string> ValidationMessages { get; set; }
    }
}