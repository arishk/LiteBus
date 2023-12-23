using LiteBus.Commands.Abstractions;
using LiteBus.Messaging.Abstractions;

namespace LiteBus.Commands.UnitTests.UseCases.CommandWithTag;

[HandlerTag(Tags.Tag2)]
public sealed class CommandWithTagHandler2 : ICommandHandler<CommandWithTag>
{
    public Task HandleAsync(CommandWithTag message, CancellationToken cancellationToken = default)
    {
        message.ExecutedTypes.Add(GetType());

        return Task.CompletedTask;
    }
}