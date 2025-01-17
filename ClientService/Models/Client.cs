using System.ComponentModel.DataAnnotations;

namespace ClientService.Models
{
    public class Client
    {
        [Key]
        [Display(Name = "ID")]
        public int Id { get; set; }
        public string Rut { get; set; } = "";
        [Display(Name = "Razon social")]
        public string RazonSocial { get; set; } = "";

        [Display(Name = "Rut representante")]
        public string? RutRepresentante { get; set; }
        [Display(Name = "Nombres representante")]
        public string? NombresRepresentante { get; set; }

        [Display(Name = "Apellidos representante")]
        public string? ApellidosRepresentante { get; set; }

        [Display(Name = "Teléfono representante")]
        public string? TelefonoRepresentante { get; set; }

        [Display(Name = "Correo representante")]
        public string? CorreoRepresentante { get; set; }
    }
}
