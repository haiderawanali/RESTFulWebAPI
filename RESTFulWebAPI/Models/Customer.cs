using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RESTFulWebAPI.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int CustomerTypeId { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public DateTime LastUpdated { get; set; }

        [ForeignKey("CustomerTypeId")]
        public CustomerType CustomerType { get; set; }
    }
}
