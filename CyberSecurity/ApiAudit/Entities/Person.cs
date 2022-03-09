using ApiAudit.Entities.Common;
using ApiAudit.Entities.Enums;

namespace ApiAudit.Entities;

public class Person : Auditable
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime BirthDate { get; set; }
    public Gender Gender { get; set; }
}