using MoneyPro2.Shared.Commands;

namespace MoneyPro2.Shared.Handlers;

public interface IHandler<T> where T : ICommand
{
    ICommandResult Handle(T command);
}
