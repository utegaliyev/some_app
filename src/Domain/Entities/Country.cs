namespace some_app.Domain.Entities;

public class Country : BaseEntity
{
    public string Name { get; set; }

    public virtual ICollection<Province> Provinces { get; set; }
}