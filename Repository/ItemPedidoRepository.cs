using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DESAFIO_API.Context;
using DESAFIO_API.Model;

namespace DESAFIO_API.Repository
{
    public class ItemPedidoRepository
    {
        private readonly VendasContext _context;

        public ItemPedidoRepository(VendasContext context)
        {
            _context = context;
        }

        public void Cadastrar(ItemPedido itemPedido)
        {
            _context.ItemPedidos.Add(itemPedido);
            _context.SaveChanges();
        }

        public ItemPedido ObterPorId(int id)
        {
            var itempedido = _context.ItemPedidos.Find(id);
            return itempedido;
        }

        public void DeletarItemPedido(ItemPedido itempedido)
        {
            _context.ItemPedidos.Remove(itempedido);
            _context.SaveChanges();
        }

        public ItemPedido AtualizarItemPedido(ItemPedido itempedido)
        {
            _context.ItemPedidos.Update(itempedido);
            _context.SaveChanges();

            return itempedido;
        }
    }
}