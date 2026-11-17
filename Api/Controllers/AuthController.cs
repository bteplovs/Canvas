using Api.Models;
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

    [Authorize]
    [HttpGet("/me")]
    public async Task<ActionResult<UserResponse>> Me()
    {
        var user = await userManager.GetUserAsync(User);
        if (user == null) return Unauthorized();

        return Ok(new UserResponse(
            user.Id,
            user.FirstName,
            user.LastName,
            user.Email!,
            user.UserName!
        ));
    }
}
