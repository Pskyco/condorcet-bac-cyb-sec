namespace ApiAudit.Entities.Common;

public class Auditable : IAuditable
{
    public DateTime CreationDateTime { get; set; }
    public Guid CreationUserId { get; set; }
    public DateTime? LastUpdateDateTime { get; set; }
    public Guid? LastUpdaterUserId { get; set; }

    public void Update(Guid userId)
    {
        LastUpdateDateTime = DateTime.Now;
        LastUpdaterUserId = userId;
    }
    
    public void Insert(Guid userId)
    {
        CreationDateTime = DateTime.Now;
        CreationUserId = userId;
    }
}