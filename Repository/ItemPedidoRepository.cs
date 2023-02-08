using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DESAFIO_API.Context;
using DESAFIO_API.Dto;
using DESAFIO_API.Model;
using Microsoft.EntityFrameworkCore;

namespace DESAFIO_API.Repository
{
    public class ItemPedidoRepository
    {
        private readonly VendasContext _context;

        public ItemPedidoRepository(VendasContext context)
        {
            _context = context;
        }

        public ItemPedido Cadastrar(ItemPedido itemPedido)
        {
            _context.ItemPedidos.Add(itemPedido);
            _context.SaveChanges();

            return itemPedido;
        }

        public ItemPedido ObterPorId(int id)
        {
            var itempedido = _context.ItemPedidos.Include(x => x.Pedido)
                                                 .Include(x => x.Servico)
                                                 .FirstOrDefault(x => x.Id == id);
            return itempedido;
        }

        public ItemPedido AtualizarItemPedido(ItemPedido itempedido)
        {
            _context.ItemPedidos.Update(itempedido);
            _context.SaveChanges();

            return itempedido;
        }

        public void DeletarItemPedido(ItemPedido itempedido)
        {
            _context.ItemPedidos.Remove(itempedido);
            _context.SaveChanges();
        }

        public void AtualizarQuantidade(ItemPedido itempedido, AtualizarQuantidadeItemPedidoDTO dto)
        {
            itempedido.Quantidade = dto.Quantidade;
            AtualizarItemPedido(itempedido);
        }

        public void AtualizarValor(ItemPedido itempedido, AtualizarValorItemPedidoDTO dto)
        {
            itempedido.Valor = dto.Valor;
            AtualizarItemPedido(itempedido);
        }
    }
}