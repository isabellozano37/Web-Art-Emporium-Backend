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
    public class Tipos
    {
        public int IdTipos { get; set; }
        public string Oleo { get; set;}
        public string Acuarela { get; set;}
        public string Bustos { get; set;}
        public string Ceramicas { get; set;}

        [ForeignKey ("Categorias")]
        public int IdCategorias { get; set; }

        [JsonIgnore]
        public virtual Categorias categoria { get; set; }


    }
}
