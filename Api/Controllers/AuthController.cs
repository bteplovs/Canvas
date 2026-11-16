using Api.Models;
using Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController(IAuthService authService) : ControllerBase
{

    [HttpPost("/login")]
    public async Task<IActionResult> Login([FromBody] LoginUserRequest req)
    {
        // Validate credentials (unique, correct, not empty etc)

        // check against saved in db
        var loggedInUser = await authService.Login(req);
        if (loggedInUser == null) { return Unauthorized(); }

        // Generate and return JWT token in response

        return Ok();
    }

    [HttpPost("/register")]
    public async Task<IActionResult> Register([FromBody] CreateUserRequest req)
    {

        // Validate input. and return error if incorrect, only valid data enters services.
        //
        var createdUser = await authService.CreateUserAsync(req);
        // Create JWT token from here!

        return Created();
    }
}

// TODO:
// 1. Add dtos for login, reg, auth response. (save in js secure cookie).
// 2. Token service for issuing JWT token (Itokenservice, TokenService)
// 3. Create /me endpoint to call on page refresh to check if token is still valid. (FE job)
