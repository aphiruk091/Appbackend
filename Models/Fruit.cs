using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace appbackend.Models
{
     [Table("Fruits")]
    public class Fruit
    {
         [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; } = String.Empty;
        [StringLength(400)]
        public string Picture { get; set; } = String.Empty;
    }
}