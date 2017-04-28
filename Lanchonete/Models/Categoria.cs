using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lanchonete.Models
{
 //  [Table("Categorias")]
    public class Categoria
    {
        public int CategoriaID { get; set; }

        public string Nome { get; set; }

        public string Descricao { get; set; }

       public virtual ICollection<Lanche> Lanches { get; set; }
    }
}