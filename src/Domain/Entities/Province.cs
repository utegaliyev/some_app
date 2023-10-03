namespace some_app.Domain.Entities;

public class Province : BaseEntity
{
    public string Name { get; set; }

    public int CountryId { get; set; }
    
    public virtual Country Country { get; set; }    
}