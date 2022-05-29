namespace ApiAudit.Exceptions;

public class CustomException : Exception
{
    public Guid ClientId { get; set; }
    public Guid EnterpriseId { get; set; }
}