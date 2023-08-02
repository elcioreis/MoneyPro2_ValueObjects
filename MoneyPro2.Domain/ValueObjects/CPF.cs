using Flunt.Notifications;
using Flunt.Validations;
using Money2.Shared.Functions;
using Money2.Shared.ValueObjects;

namespace Money2.Domain.ValueObjects;

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
