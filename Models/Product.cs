using System.ComponentModel.DataAnnotations;

namespace WebAppy.Models
{
    public class Product
    {
        [Key]
       
        public int Id { get; set; }
        [Required]
        public string Description { get; set; }
        public int Price {  get; set; }
        public int DisplayOrder { get; set; }
       
        


    }
}
