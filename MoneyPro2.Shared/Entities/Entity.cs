using Flunt.Notifications;

namespace Money2.Shared.Entities;

public abstract class Entity : Notifiable<Notification>
{
    protected Entity()
    {
        Id = Guid.NewGuid();
    }

    public Guid Id { get; private set; }
}
