using System.ComponentModel.DataAnnotations;

namespace InvoicementTypeService.Dtos
{
    public class InvoicementTypeRequestDto
    {
        [Required]
        public string Name { get; set; }
    }
}
