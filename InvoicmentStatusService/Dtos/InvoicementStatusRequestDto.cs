using System.ComponentModel.DataAnnotations;

namespace InvoicmentStatusService.Dtos
{
    public class InvoicementStatusRequestDto
    {
        [Required]
        public string Name { get; set; }
    }
}
