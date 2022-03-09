namespace ApiAudit.Entities.Common;

public interface IAuditable
{
    public DateTime CreationDateTime { get; set; }
    public Guid CreationUserId { get; set; }
    public DateTime? LastUpdateDateTime { get; set; }
    public Guid? LastUpdaterUserId { get; set; }
}