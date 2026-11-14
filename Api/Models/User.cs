using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Api.Models;

public class User : IdentityUser
{
    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    public Canvas? Canvas { get; set; }
}

public record CreateUserRequest(string FirstName, string LastName, string Email, string Username, string Password);

public record LoginUserRequest(string Email, string Password);

public record AuthResponse(string TokenType, string AccessToken, int ExpiresIn);
