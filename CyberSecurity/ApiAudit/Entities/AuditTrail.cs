namespace ApiAudit.Entities;

public class AuditTrail
{
    public Guid Id { get; set; }
    public string ActionType { get; set; }
    public string EntityType { get; set; }
    public string AuditData { get; set; }
    public Guid AuditObjectId { get; set; }
    public DateTime AuditDateTime { get; set; }
    public Guid AuditUserId { get; set; }
}