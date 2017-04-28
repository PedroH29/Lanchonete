using Lanchonete.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lanchonete.DAL
{
    public class Initializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<Contexto>
    {
        protected override void Seed(Contexto contexto)
        {
            var categorias = new List<Categoria>
            {
            new Categoria{Nome="lanche",Descricao="solido",},

            };
            categorias.ForEach(s => contexto.Categorias.Add(s));
            contexto.SaveChanges();

            var Lanches = new List<Lanche>
            {
            new Lanche{CategoriaID=1,Nome="xtudo",Descricao="grande",Preco=20},

            };

            Lanches.ForEach(s => contexto.Lanches.Add(s));
            contexto.SaveChanges();




            var Clientes = new List<Cliente>
            {
            new Cliente {ClienteID=1, Nome="joao",Telefone="123456",Email="df@,m"},

            };
            Clientes.ForEach(s => contexto.Clientes.Add(s));
            contexto.SaveChanges();



           var  Pedidos = new List<Pedido>
        {
           new Pedido{LancheID=1, ClienteID=1,Tipo=Tipo.Retirada,Data=DateTime.Parse("2017-01-1")},
        //    new Reserva{HospedeID=2,QuartoID=104,CheckIn=DateTime.Parse("2017-05-15"),CheckOut=DateTime.Parse("2017-05-30")},
          };
           

         
            Pedidos.ForEach(s => contexto.Pedidos.Add(s));
            contexto.SaveChanges();


        }
    }
}