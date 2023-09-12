using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class DetallesCompras
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id_DetallesCompras { get; set; }
        public int Precio { get; set; }
        public int Cantidad { get; set; }

        [ForeignKey ("Productos")]
        public int IdProductos { get; set;}

        [ForeignKey ("Compras")]
        public int IdCompras { get; set; }

        //[ForeignKey("Usuario")]
        //public int IdUsuario { get; set; }
    }

}
