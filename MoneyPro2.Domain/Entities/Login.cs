using Flunt.Notifications;
using Money2.Domain.ValueObjects;

namespace MoneyPro2.Domain.Entities;
public class Login : Notifiable<Notification>
{
    public Login() { }

    public Login(UserName userName, Password password)
    {
        UserName = userName;
        Password = password;

        AddNotifications(UserName.Notifications);
        AddNotifications(Password.Notifications);
    }

    public UserName UserName { get; private set; } = null!;
    public Password Password { get; private set; } = null!;
}
