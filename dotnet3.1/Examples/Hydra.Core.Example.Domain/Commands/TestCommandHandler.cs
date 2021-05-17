using System;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation.Results;
using Hydra.Core.Example.Domain.Events.ExampleEvents;
using Hydra.Core.Mediator.Abstractions.Mediator;
using Hydra.Core.Mediator.Messages;
using MediatR;

namespace Hydra.Core.Example.Domain.Commands
{
    public class TestCommandHandler : CommandHandler,
                                        IRequestHandler<TestCommand, CommandResult<ValidationResult>>,
                                         IRequestHandler<TestCommand2, bool>
    {
        private readonly IMediatorHandler _mediatorHandler;

        public TestCommandHandler(IMediatorHandler mediatorHandler)
        {
            _mediatorHandler = mediatorHandler;
        }

        public async Task<CommandResult<ValidationResult>> Handle(TestCommand request, CancellationToken cancellationToken)
        {
           var result= new TestCommandResult{ Result = "Result Command"};
           var a = new CommandResult<TestCommandResult>(result);

            await _mediatorHandler.PublishEvent(new ExampleEvent(Guid.Empty));
            return null;
        }

        public async Task<bool> Handle(TestCommand2 request, CancellationToken cancellationToken)
        {
            var a = "a";

            return await Task.FromResult(true);
        }
    }

    public class TestCommandHandler2 : IRequestHandler<TestCommand2, bool>
    {
        public Task<bool> Handle(TestCommand2 request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
} 