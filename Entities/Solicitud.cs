using Entities.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Entities
{
    public class Solicitud
    {
        public readonly string Descripcion;

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id_Solicitud { get; set; }
        public string Imagen { get; set; }
        public string Nombre { get; set; }
        public string Descripción { get; set; }
        public string Precio { get; set; }
        public string Estado { get; set; }

        //[ForeignKey("Tipos")]
        public int IdTipos { get; set; }

        //[JsonIgnore]
        //public virtual Tipos Tipos { get; set; }

        [ForeignKey("Usuario")]
        public int IdUsuario { get; set; }

        [JsonIgnore]
        public virtual Usuario Usuario { get; set; }




    }
}
