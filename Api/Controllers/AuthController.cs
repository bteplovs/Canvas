using Api.Models;
using Api.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController(UserManager<User> userManager, SignInManager<User> signInManager) : ControllerBase
{

    [HttpPost("/register")]
    public async Task<IActionResult> Register([FromBody] CreateUserRequest req)
    {
        var user = new User
        {
            Email = req.Email,
            UserName = req.Username,
            FirstName = req.FirstName,
            LastName = req.LastName
        };

        var result = await userManager.CreateAsync(user, req.Password);
        if (!result.Succeeded) {
            return BadRequest(result.Errors.Select(e => e.Description));
        }

        return Created();
    }

    [HttpPost("/login")]
    public async Task<IActionResult> Login([FromBody] LoginUserRequest req)
    {
        var user = await userManager.FindByEmailAsync(req.Email);
        if (user == null) return Unauthorized();

        var result = await signInManager.PasswordSignInAsync(user, req.Password, isPersistent: false, lockoutOnFailure: true);

        return result.Succeeded ? Ok() : Unauthorized();
    }

    [Authorize]
    [HttpPost("/logout")]
    public async Task<IActionResult> Logout()
    {
        await signInManager.SignOutAsync();
        return Ok();
    }

}

// TODO:
// 1. Add dtos for login, reg, auth response. (save in js secure cookie).
// 2. Token service for issuing JWT token (Itokenservice, TokenService)
// 3. Create /me endpoint to call on page refresh to check if token is still valid. (FE job)
