using Flunt.Notifications;
using Flunt.Validations;
using MoneyPro2.Shared.ValueObjects;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoneyPro2.Domain.ValueObjects;

public class Name : ValueObject
{
    public Name() { }

    public Name(string firstName, string lastName)
    {
        FirstName = firstName.Trim();
        LastName = lastName.Trim();

        AddNotifications(
            new Contract<Notification>()
                .Requires()
                .IsTrue(
                    FirstName.Length >= 2,
                    "FirstName",
                    "Nome deve conter ao menos 2 caracteres"
                )
                .IsTrue(
                    FirstName.Length <= 40,
                    "FirstName",
                    "Nome deve conter até 40 caracteres"
                )
                .IsTrue(
                    LastName.Length >= 2,
                    "LastName",
                    "Sobrenome deve conter ao menos 2 caracteres"
                )
                .IsTrue(
                    LastName.Length <= 40,
                    "LastName",
                    "Sobrenome deve conter até 40 caracteres"
                )
        );
    }

    [NotMapped]
    public string FirstName { get; private set; } = string.Empty;
    [NotMapped]
    public string LastName { get; private set; } = string.Empty;
    public string FullName
    {
        get { return $"{FirstName} {LastName}"; }
        private set { }
    }

    public override string ToString()
    {
        return FullName;
    }
}
