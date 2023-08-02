using Money2.Shared.Commands;

namespace Money2.Shared.Handlers;

public interface IHandler<T> where T : ICommand
{
    ICommandResult Handle(T command);
}
