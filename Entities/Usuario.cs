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
    public class Usuario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id_Usuario { get; set; }
        public string Nombre_Usuario { get; set; }
        public string Apellidos_Usuario { get; set; }
        public string Direccion_Usuario { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string Contraseña { get; set; }  

        [ForeignKey("Roll")]
        public int IdRoll { get; set; }

        [JsonIgnore]
        public virtual Roll Roll { get; set; }

        [JsonIgnore]
        public ICollection<Compras> compras { get; set; }
        public ICollection<Solicitud> Solicitud { get; set; }

    }
}




