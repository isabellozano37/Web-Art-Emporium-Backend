
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        
        [ForeignKey ("Productos")]
        public int IdProductos { get; set; }        

        public ICollection <Compras> compras { get; set; }

    }
}
