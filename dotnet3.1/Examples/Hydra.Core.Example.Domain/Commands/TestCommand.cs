using FluentValidation.Results;
using Hydra.Core.Mediator.Messages;

namespace Hydra.Core.Example.Domain.Commands
{
    public class TestCommand : Command<ValidationResult>
    {
        public string TestName { get; set; }

        public TestCommand(string testName)
        {
            TestName = testName;
        }
    }

    public class TestCommand2 : Command
    {
        public string TestName { get; set; }

        public TestCommand2(string testName)
        {
            TestName = testName;
        }
    }
}