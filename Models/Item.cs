using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace testCoreApp.Models
{
    public class Item
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string name { get; set; }
        [Required]
        public decimal price { get; set; }
        public DateTime createdDate { get; set; } = DateTime.Now;

        [Required]
        [DisplayName("Category")]
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
    }
}
