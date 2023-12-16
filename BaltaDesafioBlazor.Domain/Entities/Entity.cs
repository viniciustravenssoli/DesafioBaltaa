namespace BaltaDesafioBlazor.Domain.Entities;

public abstract class Entity
{
    protected Entity()
    {
    }

    protected Entity(string id)
    {
        Update(id);
    }

    public string Id { get; private set; } = null!;

    internal void Update(string id)
    {
        Id = id.Trim();
    }
}
