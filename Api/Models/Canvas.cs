using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Models;

public class Canvas
{
    [Key]
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public bool IsPrimary { get; set; }

    public string Data { get; set; } = string.Empty;

    [Required]
    [ForeignKey(nameof(User))]
    public string UserId { get; set; } = string.Empty;

    public User User { get; set; } = null!;
}

public record CanvasResponse(int Id, string UserId);

public record CreateCanvasRequest(int Id, string Name, string Data);

public record UpdateCanvasRequest(int Id, string? Data, string? Name);
