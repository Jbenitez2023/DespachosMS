using System.ComponentModel.DataAnnotations;

namespace TipoPagosService.Models
{
    public class PayType
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
