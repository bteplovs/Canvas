using System.Security.Claims;
using Api.Models;
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
    public async Task<CanvasResponse> GetAllCanvas(string userId)
    {
        return Ok(await );
    }

    [HttpGet("canvases/{canvasId}")]
    public async Task<CanvasResponse> GetCanvas(string userId, int canvasId)
    {
        return Ok();
    }

    [HttpPost]
    public async Task<CanvasResponse> CreateCanvas()
    {
         return Ok();
    }

    [HttpPut("canvases/{canvasId}/update")]
    public async Task<IActionResult> UpdateCanvas(int canvasId)
    {
        return Ok();
    }

    [HttpPut("canvases/{canvasId}/primary")]
    public async Task<IActionResult> SetCanvasPrimary(int canvasId)
    {
        return Ok();
    }

    [HttpDelete("canvases/{canvasId}/delete")]
    public async Task<IActionResult> DeleteCanvas(int canvasId)
    {
        return Ok();
    }
}
