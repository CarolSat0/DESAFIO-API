using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DESAFIO_API.Context;
using DESAFIO_API.Model;

namespace DESAFIO_API.Repository
{
    public class PedidoRepository
    {
        private readonly VendasContext _context;

        public PedidoRepository(VendasContext context)
        {
            _context = context;
        }

        public void Cadastrar(Pedido pedido)
        {
            _context.Pedidos.Add(pedido);
            _context.SaveChanges();
        }

        public Pedido ObterPorId(int id)
        {
            var pedido = _context.Pedidos.Find(id);
            return pedido;
        }
    }
}