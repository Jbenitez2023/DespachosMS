using System.ComponentModel.DataAnnotations;

namespace InvoicmentStatusService.Models
{
    public class InvoicementStatus
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
