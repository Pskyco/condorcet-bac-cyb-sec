using ApiAudit.Entities.Common;
using ApiAudit.Entities.Enums;

namespace ApiAudit.Entities;

//[AuditIgnore]
public class Person : Auditable
{
    public Guid Id { get; set; }

    public string FirstName { get; set; }

    // [AuditOverride(null)]
    // [AuditOverride("******")]
    // [AuditIgnore]
    public string LastName { get; set; }

    public DateTime BirthDate { get; set; }

    public Gender Gender { get; set; }
}