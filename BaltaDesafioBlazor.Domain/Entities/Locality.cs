namespace BaltaDesafioBlazor.Domain.Entities;

public class Locality : Entity
{
    protected Locality()
    {
    }

    public Locality(string id, string city, string state) : base(id)
    {
        City = city;
        State = state;
    }

    public string City { get; private set; } = null!;
    public string State { get; private set; } = null!;
}
