using System.ComponentModel.DataAnnotations;

namespace InvoicementTypeService.Models
{
    public class invoicementType
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string  Name { get; set; }
    }
}
