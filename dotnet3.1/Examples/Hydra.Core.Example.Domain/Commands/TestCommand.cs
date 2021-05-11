using Hydra.Core.Mediator.Messages;

namespace Hydra.Core.Example.Domain.Commands
{
    public class TestCommand : Command<TestCommandResult>
    {
        public string TestName { get; set; }

        public TestCommand(string testName)
        {
            TestName = testName;
        }
    }
}