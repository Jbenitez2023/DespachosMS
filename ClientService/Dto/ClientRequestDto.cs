using System.ComponentModel.DataAnnotations;

namespace ClientService.Dto
{
    public class ClientRequestDto
    {
        [Required]
        public string Rut { get; set; } = "";
        [Required]
        public string RazonSocial { get; set; } = "";
        [Required]
        public string? RutRepresentante { get; set; }
        [Required]
        public string? NombresRepresentante { get; set; }
        [Required]
        public string? ApellidosRepresentante { get; set; }
        [Required]
        public string? TelefonoRepresentante { get; set; }
        [Required]
        public string? CorreoRepresentante { get; set; }
    }
}
