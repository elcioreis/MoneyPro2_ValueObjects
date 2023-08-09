using Flunt.Notifications;

namespace MoneyPro2.Shared.Entities;

public abstract class Entity : Notifiable<Notification>
{
    protected Entity()
    {
        Id = Guid.NewGuid();
    }

    public Guid Id { get; private set; }
}
