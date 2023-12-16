namespace BaltaDesafioBlazor.Domain.Entities;

public class Locality : Entity
{
    protected Locality()
    {
    }

    public Locality(string id, string city, string state) : base(id)
    {
        Update(city, state);
    }

    private void Update(string city, string state)
    {
        City = city.Trim();
        State = state.Trim();
    }

    public string City { get; private set; } = null!;
    public string State { get; private set; } = null!;

    public void Update(string id, string city, string state)
    {
        Update(id);
        Update(city, state);
    }
}
