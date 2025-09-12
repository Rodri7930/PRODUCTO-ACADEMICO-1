using System;
using System.ComponentModel.DataAnnotations;

namespace PD1.Models
{
    public class Cliente
    {
        public int ClienteID { get; set; }

        [Required, StringLength(100)]
        public string NombreCliente { get; set; }

        [EmailAddress, StringLength(100)]
        public string Email { get; set; }

        [StringLength(20)]
        public string Telefono { get; set; }

        [StringLength(200)]
        public string Direccion { get; set; }

        public DateTime FechaRegistro { get; set; }
    }
}