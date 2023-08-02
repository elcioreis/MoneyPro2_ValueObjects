using Flunt.Notifications;
using Flunt.Validations;
using Money2.Shared.ValueObjects;
using System.Text.RegularExpressions;

namespace Money2.Domain.ValueObjects;

public class UserName : ValueObject
{
    private readonly Regex _allowed = new Regex("^(?=.*?[A-Z]|[a-z]|[0-9]|[@$%^&*-.]).{2,}$");

    public UserName(string username)
    {
        Username = username;

        AddNotifications(
            new Contract<Notification>()
                .Requires()
                .IsTrue(
                    (Username.Length >= 2) && (Username.Length <= 20),
                    "Username",
                    "O username deve ter entre 2 e 20 caracteres"
                )
                .IsTrue(
                    _allowed.IsMatch(Username),
                    "Username",
                    "O username deve conter letras maiúsculas, minúsculas ou números"
                )
        );
    }

    public string Username { get; private set; } = null!;
}
