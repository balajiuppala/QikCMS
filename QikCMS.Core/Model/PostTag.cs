using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QikCMS.Core.Model
{
    public class PostTag : BaseModel
    {
        [Key]
        [MaxLength(120)]
        public string Name { get; set; }

        [Key]
        [Required]
        public int BlogId { get; set; }

        public virtual Post Blog { get; set; }

        
    }

    //public class BlogTags
    //{
    //    [Key]
    //    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    //    public int Id { get; set; }

    //    [Required]
    //    public int BlogId { get; set; }

    //    public Blog Blog { get; set; }

    //    [Required]
    //    public int TagId { get; set; }

    //    public BlogTag BlogTag { get; set; }
    //}
}