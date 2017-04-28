using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lanchonete.Models
{
    //[Table("Lanches")]
    public class Lanche
    {
        public int LancheID{ get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public float Preco { get; set; }
        public int CategoriaID { get; set; }

        public virtual Categoria Categoria { get; set; }
        public virtual ICollection<Pedido> Pedidos { get; set; }
    }
}