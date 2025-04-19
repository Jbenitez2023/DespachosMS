using System.ComponentModel.DataAnnotations;

namespace DispatchService.Models
{
    public class DispatchAnnexes
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int IdDespacho { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Anexo { get; set; }
        public virtual Dispatch Dispatch { get; set; }
    }
}
