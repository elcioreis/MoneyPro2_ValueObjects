using Flunt.Notifications;
using Flunt.Validations;
using Money2.Shared.ValueObjects;

namespace Money2.Domain.ValueObjects;

public class Email : ValueObject
{
    public Email(string address)
    {
        Address = address.Trim().ToLower();

        AddNotifications(
            new Contract<Notification>()
                .Requires()
                .IsEmail(Address, "Email", "E-mail inválido")
        );
    }

    public string Address { get; private set; } = string.Empty;

    public override string ToString()
    {
        return this.Address;
    }
}
