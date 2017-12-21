using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace QikCMS.Core.Model
{
    //[Table("Blogs")]
    public class Post : BaseModel
    {
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string Title { get; set; }

        [Required]
        [MaxLength(255)]
        public string Slug { get; set; }

        [Required]
        public string Content { get; set; }

        [MaxLength(250)]
        public string MetaDescription { get; set; }

        public bool IsArchived { get; set; }

        public bool IsPublished { get; set; }

        public bool IsFeatured { get; set; }

        public DateTime? PublishedDate { get; set; }

        [Required]
        public DateTime? LastModifiedOn { get; set; } = DateTime.UtcNow;

        public virtual List<PostTag> Tags { get; set; }
    }
}
