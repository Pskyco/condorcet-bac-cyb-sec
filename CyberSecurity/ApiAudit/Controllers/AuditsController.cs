using ApiAudit.Entities;
using ApiAudit.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiAudit.Controllers;

[ApiController]
[Route("audits")]
public class AuditsController : ControllerBase
{
    private readonly ApplicationDbContext _dbContext;
    private readonly ILogger<AuditsController> _logger;

    public AuditsController(ApplicationDbContext dbContext, ILogger<AuditsController> logger)
    {
        _dbContext = dbContext;
        _logger = logger;
    }

    [HttpGet, Route("errors")]
    public async Task<IActionResult> CreateError()
    {
        int i = 0;

        while (i != 100)
        {
            i++;
            _logger.LogError($"Random error with guid {Guid.NewGuid()}");
            _logger.LogDebug($"Random error with guid {Guid.NewGuid()}");
            _logger.LogCritical($"Random error with guid {Guid.NewGuid()}");
            _logger.LogInformation($"Random error with guid {Guid.NewGuid()}");
            _logger.LogTrace($"Random error with guid {Guid.NewGuid()}");
            _logger.LogWarning($"Random error with guid {Guid.NewGuid()}");
        }

        return Ok();
    }

    [HttpGet]
    public async Task<IActionResult> GetList(CancellationToken cancellationToken)
    {
        return Ok(await _dbContext.Set<Person>().ToListAsync(cancellationToken));
    }

    [HttpGet]
    [Route("{id:guid}")]
    public async Task<IActionResult> GetSingle(Guid id)
    {
        var matching = await _dbContext.Set<Person>().FindAsync(id);

        if (matching == null)
            return NotFound();

        return Ok(matching);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Person person, CancellationToken cancellationToken)
    {
        var entity = new Person()
        {
            Gender = person.Gender,
            BirthDate = person.BirthDate,
            FirstName = person.FirstName,
            LastName = person.LastName
        };

        await _dbContext.AddAsync(entity, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);

        // return CreatedAtAction("GetSingle", entity.Id);
        return Ok(entity.Id);
    }

    [HttpPut]
    [Route("{id:guid}")]
    public async Task<IActionResult> Post(Guid id, [FromBody] Person person, CancellationToken cancellationToken)
    {
        var matching = await _dbContext.Set<Person>().FindAsync(id);

        if (matching == null)
            return NotFound();

        matching.Gender = person.Gender;
        matching.BirthDate = person.BirthDate;
        matching.FirstName = person.FirstName;
        matching.LastName = person.LastName;

        await _dbContext.SaveChangesAsync(cancellationToken);

        return Ok();
    }

    [HttpDelete]
    [Route("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
    {
        var matching = await _dbContext.Set<Person>().FindAsync(id);

        if (matching == null)
            return NotFound();

        _dbContext.Remove(matching);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return Ok();
    }
}