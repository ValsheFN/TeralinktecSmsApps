using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using TeralinktecSmsApps.API.Models;

namespace TeralinktecSmsApps.API.Data
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
            CreatedContact = new List<Contact>();
            UpdatedContact = new List<Contact>();
        }

        [Column(TypeName = "decimal(18,2)")]
        public decimal CostPerSms { get; set; } = 500;
        public int SmsCredit { get; set; } = 0;
        public bool AdminApproval { get; set; } = false;

        public virtual List<Contact> CreatedContact { get; set; }
        public virtual List<Contact> UpdatedContact { get; set; }
    }
}
