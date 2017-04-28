using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Lanchonete.Models
{
    public enum Tipo
    {
        Retirada, Entrega
    }
    [Table("Pedidos")]
    public class Pedido
    {
        public int PedidoID { get; set; }

        public Tipo Tipo { get; set; }

        public DateTime Data { get; set; }

        public string Nome { get; set; }

        public int LancheID { get; set; }

        public int ClienteID { get; set; }

        public virtual Lanche Lanche { get; set; }
        public virtual Cliente Cliente { get; set; }
        
    }
}