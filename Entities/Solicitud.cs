using Entities.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Entities
{
    public class Solicitud
    {
        public int Id_Solicitud { get; set; }
        public string Categoria { get; set; }
        public string Imagen { get; set; }
        public string Nombre { get; set; }
        public string Descripción{ get; set; }
        public string Precio { get; set; }

        [ForeignKey("Producto")]
        public int IdProducto { get; set; }

        [ForeignKey("Usuario")]
        public int IdUsuario { get; set; }

        [JsonIgnore]
        public virtual Productos producto { get; set; }
        public virtual Usuario usuario { get; set; }


    }
}
