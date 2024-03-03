namespace ThunderWings.Domain.Countries;

public class Country
{
    public Country(CountryId id, string name)
    {
        Id = id;
        Name = name;
    }

    public CountryId Id { get; private set; }

    public string Name { get; private set; } = string.Empty;
}