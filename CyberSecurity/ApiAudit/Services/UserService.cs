namespace ApiAudit.Services;

public class UserService : IUserService
{
    /*rivate readonly IHttpContextAccessor _context;*/

    // private Guid? _userId;

    public UserService(/*IHttpContextAccessor context*/)
    {
        // _context = context;
    }
    
    public Guid GetCurrentUserId()
    {
        // if we were using IS4 with authentificated client
        // return _context.HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier);

        // if (_userId.HasValue)
        //     return _userId.Value;
        //
        // _userId = Guid.NewGuid();
        // return _userId.Value;
        
        return Guid.NewGuid();
    }
}