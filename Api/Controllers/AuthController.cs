using Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{

    [HttpPost]
    public async Task<IActionResult> Login([FromBody] LoginUserRequest req)
    {
        // Accept login Request
        //
        // Validate credentials (unique, correct etc)
        // Return JWT token in response

        System.Console.WriteLine("Login");
        return Ok();
    }

    [HttpPost]
    public async Task<IActionResult> Register([FromBody] CreateUserRequest req)
    {

        // Validate input. and return error if incorrect, only valid data enters services.


        // TODO: remove below and pass directly into service.

        var user = new User
        {
            Email = req.Email,
            UserName = req.Username,
            FirstName = req.FirstName,
            LastName = req.LastName,
            PasswordHash = req.Password
        };

        // Create service to hash password

        System.Console.WriteLine("Login");
        return Ok();
    }
}

// TODO:
// 1. Add dtos for login, reg, auth response. (save in js secure cookie).
// 2. Token service for issuing JWT token (Itokenservice, TokenService)
// 3. Create /me endpoint to call on page refresh to check if token is still valid. (FE job)
