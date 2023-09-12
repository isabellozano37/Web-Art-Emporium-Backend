using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Entities.Entities
{
    public class Productos
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdProductos { get; set; }
        public string Imagen { get; set; }
        public string Nombre { get; set; }
        public string Descripción { get; set;}
        public string Precio { get; set; }

        [ForeignKey ("Solicitud")]
        public int IdSolicitud { get; set; }

        [ForeignKey("Categorias")]
        public int IdCategorias { get; set; }

        [JsonIgnore]
        public virtual Solicitud Solicitud { get; set; }
        public virtual Categoria Categorias { get; set; }

    }
}
