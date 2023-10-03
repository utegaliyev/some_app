namespace some_app.Domain.Entities;

public class PersonalInfo
{
    public Guid Id { get; set; }
 
    public int ProvinceId { get; set; }
    
    public virtual Province Province { get; set; }
}