using System.Security.Claims;
using Api.Models;
using Api.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[Authorize]
[ApiController]
[Route("api")]
public class CanvasController(ICanvasService canvasService) : ControllerBase
{
    private string UserId => User.FindFirstValue(ClaimTypes.NameIdentifier)!;

    [HttpGet("users/{userId}/canvases")]
    public async Task<ActionResult<List<CanvasResponse>>> GetAllCanvas(string userId)
    {
        return Ok(await canvasService.GetAllAsync(userId));
    }

    [HttpGet("canvases/{canvasId}")]
    public async Task<ActionResult<CanvasResponse>> GetCanvas(int canvasId)
    {
        var canvas = await canvasService.GetAsync(UserId, canvasId);
        return canvas is null ? NotFound() : Ok(canvas);
    }

    [HttpPost("canvases")]
    public async Task<ActionResult<CanvasResponse>> CreateCanvas(CreateCanvasRequest req)
    {
        var canvas = await canvasService.CreateAsync(UserId, req);
        return CreatedAtAction(nameof(GetCanvas), new { canvasId = canvas.Id }, canvas);
    }

    [HttpPut("canvases/{canvasId}/update")]
    public async Task<IActionResult> UpdateCanvas(int canvasId, [FromBody] UpdateCanvasRequest req)
    {
        var updated = await canvasService.UpdateAsync(UserId, canvasId, req);
        return updated is null ? NotFound() : Ok(updated);
    }

    [HttpPut("canvases/{canvasId}/primary")]
    public async Task<IActionResult> SetCanvasPrimary(int canvasId)
    {
        var setPrimary = await canvasService.SetPrimaryAsync(UserId, canvasId);
        return setPrimary is false ? NotFound() : Ok();
    }

    [HttpDelete("canvases/{canvasId}/delete")]
    public async Task<IActionResult> DeleteCanvas(int canvasId)
    {
        var deleted = await canvasService.DeleteAsync(UserId, canvasId);
        return deleted is false ? NotFound() : NoContent();
    }
}
