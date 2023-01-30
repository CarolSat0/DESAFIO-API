using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DESAFIO_API.Model;
using Microsoft.EntityFrameworkCore;

namespace DESAFIO_API.Context
{
    public class VendasContext : DbContext
    {
        public VendasContext(DbContextOptions<VendasContext> options): base(options)
        {

        }
        //transforma as classes em tabela no banco de dados
        public DbSet<Cliente> Clientes {get; set;}
        public DbSet<ItemPedido> ItemPedidos {get; set;}
        public DbSet<Pedido> Pedidos {get; set;}
        public DbSet<Servico> Servicos {get; set;}
        public DbSet<Vendedor> Vendedores {get; set;}
    }
}