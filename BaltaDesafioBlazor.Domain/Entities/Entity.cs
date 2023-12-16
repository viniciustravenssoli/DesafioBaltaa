namespace BaltaDesafioBlazor.Domain.Entities;

public abstract class Entity
{
    protected Entity()
    {
    }

    protected Entity(string id)
    {
        Id = id;
    }

    public string Id { get; private set; } = null!;
}
