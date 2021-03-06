﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lanchonete.Models
{
    public class Cliente
    {
            public int ClienteID { get; set; }

            public string Nome { get; set; }

            public string Telefone { get; set; }

            public string Email { get; set; }

         public virtual ICollection<Pedido> Pedidos { get; set; }

            public virtual ICollection<Pedido> Pedido { get; set; }
        }
}