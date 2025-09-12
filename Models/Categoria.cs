using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PD1.Models
{
    public class Categoria
    {
        public int CategoriaID { get; set; }

        [Required, StringLength(100)]
        public string NombreCategoria { get; set; }

        [StringLength(500)]
        public string Descripcion { get; set; }

        public DateTime FechaCreacion { get; set; }

        public ICollection<Producto> Productos { get; set; }
    }
}