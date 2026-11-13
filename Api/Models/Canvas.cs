using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace canvasApi.Models;

public class Canvas
{
    [Key]
    public int Id { get; set; }

    [Required]
    [ForeignKey(nameof(User))]
    public string UserId { get; set; } = string.Empty;

}
