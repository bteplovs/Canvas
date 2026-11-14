using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{

    [HttpPost]
    public async Task<IActionResult> Login()
    {

        // Accept login Request
        //
        // Validate credentials
        // Return JWT token in response

        System.Console.WriteLine("Login");
        return Ok();
    }

    [HttpPost]
    public async Task<IActionResult> Register()
    {
        System.Console.WriteLine("Login");
        return Ok();
    }
}

// TODO:
// 1. Add dtos for login, reg, auth response. (save in js secure cookie).
// 2. Token service for issuing JWT token (Itokenservice, TokenService)
// 3. Create /me endpoint to call on page refresh to check if token is still valid. (FE job)
