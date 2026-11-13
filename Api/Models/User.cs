using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace canvasApi.Models;

public class User : IdentityUser
{
    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    public Canvas? Canvas { get; set; }
}
