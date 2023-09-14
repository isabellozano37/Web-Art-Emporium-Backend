
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Entities.Entities
{
    public class Compras
        {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id_Compras { get; set; }
        public DateTime FechaPedido { get; set; }
        public DateTime FechaEntrega { get; set; }

        [ForeignKey ("Usuario")]
        public int IdUsuario { get; set; }

        [JsonIgnore]
        public virtual Usuario Usuario { get; set; }

        [JsonIgnore]
        public ICollection <DetallesCompras> DetallesCompras { get; set; }

    }
}
