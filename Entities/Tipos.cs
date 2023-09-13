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
    public class Tipos
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdTipos { get; set; }
        public string Nombre_Tipo { get; set;}

        [ForeignKey ("Categoria")]
        public int IdCategoria { get; set; }

        [JsonIgnore]
        public virtual Categoria Categoria { get; set; }

        [JsonIgnore]
        public ICollection<Productos> Productos { get; set; }
    }
}
