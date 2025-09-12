using System;

namespace PD1.Models
{
    public class Proveedor
    {
        public int ProveedorID { get; set; }
        public string NombreProveedor { get; set; }
        public string ContactoEmail { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}