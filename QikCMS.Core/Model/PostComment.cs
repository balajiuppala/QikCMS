using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace QikCMS.Core.Model
{
    public class PostComment:BaseModel
    {
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int? PostId { get; set; }

        public virtual Post Post { get; set; }

        [Required]
        [StringLength(250)]
        public string Author { get; set; }

        [Required]
        public string Comments { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(300)]
        public string Email { get; set; }

        public DateTime? PostedOn { get; set; }

        [StringLength(500)]
        public string UserAgent { get; set; }

        [StringLength(100)]
        public string IpAddress { get; set; }

        public bool IsApproved { get; set; } = false;
    }
}
