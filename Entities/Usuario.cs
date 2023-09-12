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
    public class Clientes
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id_Clientes { get; set; }
        public string Nombre_Cientes { get; set; }
        public string Apellidos_Clientes { get; set; }
        public string Direccion_Clientes { get; set; }
        public string Telefono { get; set; }
        public String Email { get; set; }

        [ForeignKey("Roll")]
        public int IdRoll { get; set; }

        [JsonIgnore]
        public virtual Roll Roll { get; set; }
    }
}




