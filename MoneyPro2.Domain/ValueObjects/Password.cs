using Flunt.Notifications;
using Flunt.Validations;
using MoneyPro2.Shared.Functions;
using MoneyPro2.Shared.ValueObjects;
using System.Text.RegularExpressions;

namespace MoneyPro2.Domain.ValueObjects;

public class Password : ValueObject
{
    private readonly Regex _strongPassword = new Regex(
        "^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$"
    );

    public Password() { }

    public Password(string plain)
    {
        _Plain = plain;

        AddNotifications(
            new Contract<Notification>()
                .Requires()
                .IsTrue(
                    _strongPassword.IsMatch(plain),
                    "Password",
                    "A senha deve ter maiúsculas, minúsculas, números, caracteres especiais e ao menos 8 caracteres"
                )
        );
    }

    private string _Plain { get; set; } = string.Empty;
    public string MD5
    {
        get { return Tools.GenerateMD5(_Plain); }
        private set { }
    }
}
