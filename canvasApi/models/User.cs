
using System.ComponentModel.DataAnnotations;

namespace canvasApi.models

{
    public class User
    {
        [Key]
        public int Id { get; set; }

        public string Username { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string HashedPassword { get; set; } = string.Empty;
    }
}
