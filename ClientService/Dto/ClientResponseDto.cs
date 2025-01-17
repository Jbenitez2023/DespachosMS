using System.ComponentModel.DataAnnotations;

namespace ClientService.Dto
{
    public class ClientResponseDto
    {
        public int Id { get; set; }
        public string Rut { get; set; } = "";
        public string RazonSocial { get; set; } = "";
        public string? RutRepresentante { get; set; }
        public string? NombresRepresentante { get; set; }
        public string? ApellidosRepresentante { get; set; }
        public string? TelefonoRepresentante { get; set; }
        public string? CorreoRepresentante { get; set; }
    }
}
