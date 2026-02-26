using Microsoft.AspNetCore.Mvc;
using Nimbus.TestRepoBeta.Services;

namespace Nimbus.TestRepoAlpha.Controllers;

/// <summary>
/// Main API controller for the Alpha service.
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class AlphaController : ControllerBase
{
    private readonly BetaService _betaService;

    public AlphaController(BetaService betaService)
    {
        _betaService = betaService;
    }

    [HttpPost("workflow")]
    public async Task<IActionResult> RunWorkflow([FromBody] WorkflowRequest request, CancellationToken ct)
    {
        var result = await _betaService.RunWorkflowAsync(request.Input, ct);

        if (!result.Success)
        {
            return BadRequest(new { error = result.Error });
        }

        return Ok(new { processed = result.ItemsProcessed });
    }
}

public class WorkflowRequest
{
    public string Input { get; set; } = string.Empty;
}
