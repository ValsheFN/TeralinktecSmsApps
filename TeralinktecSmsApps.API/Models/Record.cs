using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TeralinktecSmsApps.API.Data;

namespace TeralinktecSmsApps.API.Models
{
    public abstract class Record
    {
        public Record()
        {
            Id = Guid.NewGuid().ToString();
            CreationDate = DateTime.Now;
            UpdateDate = DateTime.Now;
        }

        [Key]
        public string Id { get; set; } = null!;
        public DateTime? CreationDate { get; set; }
        public DateTime? UpdateDate { get; set; }

        //Foreign Keys
        public virtual ApplicationUser? CreatedByUser { get; set; }
        [ForeignKey(nameof(CreatedByUser))]
        public string? CreatedByUserId { get; set; }
        public virtual ApplicationUser? UpdatedByUser { get; set; }
        [ForeignKey(nameof(UpdatedByUser))]
        public string? UpdatedByUserId { get; set; }
    }
}
