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
    public class DetallesCompras
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id_DetallesCompras { get; set; }

        public int Precio_Total { get; set; }

        [ForeignKey ("Compras")]
        public int IdCompras { get; set; }

        [JsonIgnore]
        public virtual Compras Compras { get; set; }

        [ForeignKey("Productos")]
        public int IdProducto { get; set; }

        [JsonIgnore]
        public virtual  Productos Productos { get; set; }

    }

}
