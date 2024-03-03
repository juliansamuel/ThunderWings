namespace ThunderWings.Domain.Manufacturers;

public class Manufacturer
{
    public Manufacturer(ManufacturerId id, string name)
    {
        Id = id;
        Name = name;
    }

    public ManufacturerId Id { get; private set; }

    public string Name { get; private set; }
}