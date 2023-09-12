using Microsoft.Identity.Client;
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
    public class Categoria
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
<<<<<<< HEAD
        public int Id_Categoria { get; set; }
=======
        public int Id_Categoria{ get; set; }
>>>>>>> fc4ec375b969eedd98601f3784d67c6791eae93b
        public string Pintura { get; set; }
        public string Escultura { get; set; }

        public ICollection<Productos> Productos { get; set; }
        public ICollection<Tipos> Tipos { get; set; }



    }
}
