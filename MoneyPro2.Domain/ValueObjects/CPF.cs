using Flunt.Notifications;
using Flunt.Validations;
using MoneyPro2.Shared.Functions;
using MoneyPro2.Shared.ValueObjects;

namespace MoneyPro2.Domain.ValueObjects;

public class CPF : ValueObject
{
    public CPF(string valor)
    {
        Valor = valor.Trim().Replace(".", "").Replace("-", "");

        AddNotifications(
            new Contract<Notification>()
                .Requires()
                .IsTrue(Tools.CheckCPF(Valor), "CPF", "CPF inválido")
        );
    }

    public string Valor { get; private set; }
}
