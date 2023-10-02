using System.ComponentModel.DataAnnotations;

namespace Bulky.Models
{
    public class Category
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [MaxLength(30)]
        [Display(Name = "Category Name")]
        public string Name { get; set; }


#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        [Display(Name = "DisplayOrder")]
        [Range(1, 100, ErrorMessage = "Display Order must be between 1,100")]
        public int DisplayOrder { get; set; }
    }
}
