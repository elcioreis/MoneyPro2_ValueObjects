using Flunt.Notifications;
using Money2.Domain.ValueObjects;

namespace Money2.Domain.Entities;

public class User : Notifiable<Notification>
{
    public User() { }

    public User(UserName userName, Name name, Email email, CPF cpf, Password password)
    {
        Id = 0;
        UserName = userName;
        Name = name;
        Email = email;
        CPF = cpf;
        Password = password;

        AddNotifications(UserName.Notifications);
        AddNotifications(Name.Notifications);
        AddNotifications(Email.Notifications);
        AddNotifications(CPF.Notifications);
        AddNotifications(Password.Notifications);
    }

    public short Id { get; private set; }
    public UserName UserName { get; private set; } = null!;
    public Name Name { get; private set; } = null!;
    public Email Email { get; private set; } = null!;
    public CPF CPF { get; private set; } = null!;
    public Password Password { get; private set; } = null!;
}
