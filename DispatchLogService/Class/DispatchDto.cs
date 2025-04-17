namespace DispatchLogService.Class
{
    public class DispatchDto
    {
        public int Id { get; set; }
        public string IdDespacho { get; set; }
        public int IdMensual { get; set; }
        public DateTime Fecha { get; set; }
        public DateTime FechaDespacho { get; set; }
        public int IdOperaciones { get; set; }
        public int IdDespachoFlujo { get; set; }
        public int IdCliente { get; set; }
        public int IdEstadoDespacho { get; set; }
        public DateTime? VencimientoDus { get; set; } /* debe ser 25 dias despues de la fecha de creacion */
        public string? referencia { get; set; }
        public string? Observaciones { get; set; }
        public string? ValorFactura { get; set; }
        public string? Iva { get; set; }
        public string? Total { get; set; }
        public bool? FacturaHYF { get; set; }
        public int? IdTipoServicios { get; set; }
        public string? GastosDespacho { get; set; }
        public bool? FacturaOrtiz { get; set; }
        public int? IdEstadoFacturacion { get; set; }
        public int? IdEstadoPago { get; set; }
        public string? NroFactura { get; set; }
        public int? IdTipoPago { get; set; }

        //--Anexos--//
        //--DUS--//
        public string? FacturaExportacion { get; set; } = "";
        public string? Mandato { get; set; } = "";
        public string? CRT { get; set; } = "";
        public string? AnexoDus { get; set; } = "";

        //--DIN--//
        public string? PagoTgr { get; set; } = "";
        public string? CertificadoOrigen { get; set; } = "";
        public string? CDASALUD { get; set; } = "";
        public string? AnexoDin { get; set; } = "";

        //--DIN/DTI--//
        public string? ConocimientoEmbarque { get; set; } = "";
        public string? ListaEmpaque { get; set; } = "";

        //--GLOBAL --//
        public string? MICDTA { get; set; } = "";
        public string? Factura { get; set; } = "";
        public string? AnexoFacturaHYF { get; set; } = "";
        public DateTime? FechaFacturacion { get; set; }

        public ICollection<DispatchAnnexesDto> dispatchAnnexesDtos { get; set; }
    }
}
