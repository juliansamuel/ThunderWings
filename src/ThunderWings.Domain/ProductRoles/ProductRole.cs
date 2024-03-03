namespace ThunderWings.Domain.ProductRoles;

public class ProductRole
{
    public ProductRole(ProductRoleId id, string name)
    {
        Id = id;
        Name = name;
    }

    public ProductRoleId Id { get; private set; }

    public string Name { get; private set; }
}