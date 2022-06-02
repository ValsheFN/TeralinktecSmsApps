using System.ComponentModel.DataAnnotations;

namespace TeralinktecSmsApps.API.Models
{
    public class Contact : Record
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; } = null!;
        [Required]
        [EmailAddress]
        [StringLength(100)]
        public string Email { get; set; } = null!;
        [Required]
        [StringLength(20)]
        public string PhoneNumber { get; set; } = null!;
        [StringLength(150)]
        public string? Notes { get; set; }
    }
}
