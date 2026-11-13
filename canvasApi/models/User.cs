using System.ComponentModel.DataAnnotations;

namespace canvasApi.Models;

public class User
{
    [Key]
    public string Id { get; set; } = string.Empty;

    public string Username { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    public string HashedPassword { get; set; } = string.Empty;
}
