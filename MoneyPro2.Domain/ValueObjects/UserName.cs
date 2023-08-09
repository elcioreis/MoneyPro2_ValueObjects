using Flunt.Notifications;
using Flunt.Validations;
using Money2.Shared.ValueObjects;
using System.Text.RegularExpressions;

namespace Money2.Domain.ValueObjects;

public class UserName : ValueObject
{
    private readonly Regex _allowed = new Regex("^([a-z0-9@.]){2,20}$");

    public UserName(string username)
    {
        Username = username.Trim().ToLower();

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
                    @"O username deve conter somente letras, números, ponto ou arroba"
                )
        );
    }

    public string Username { get; private set; } = null!;
}
