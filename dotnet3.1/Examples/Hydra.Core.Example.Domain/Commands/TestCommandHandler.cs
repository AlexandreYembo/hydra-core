using System.Threading;
using System.Threading.Tasks;
using Hydra.Core.Mediator.Messages;
using MediatR;

namespace Hydra.Core.Example.Domain.Commands
{
    public class TestCommandHandler : CommandHandler,
                                        IRequestHandler<TestCommand, CommandResult<TestCommandResult>>
    {
        public Task<CommandResult<TestCommandResult>> Handle(TestCommand request, CancellationToken cancellationToken)
        {
           var result= new TestCommandResult{ Result = "Result Command"};
           var a = new CommandResult<TestCommandResult>(result);

            return Task.FromResult(a);
        }
    }
} 