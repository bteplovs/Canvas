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
        // Accept login Request
        //
        // Validate credentials (unique, correct etc)
        // Return JWT token in response

        System.Console.WriteLine("Login");
        return Ok();
    }

    [HttpPost("/register")]
    public async Task<IActionResult> Register([FromBody] CreateUserRequest req)
    {

        // Validate input. and return error if incorrect, only valid data enters services.
        //

        var user = await authService.CreateUserAsync(req);

        // Create JWT token from here!

        return Created();
    }
}

// TODO:
// 1. Add dtos for login, reg, auth response. (save in js secure cookie).
// 2. Token service for issuing JWT token (Itokenservice, TokenService)
// 3. Create /me endpoint to call on page refresh to check if token is still valid. (FE job)
