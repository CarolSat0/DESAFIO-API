using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DESAFIO_API.Dto;


namespace DESAFIO_API.Model
{
    public class ItemPedido
    {
        public int Id {get; set;}
        public int Quantidade { get; set; }
        public float Valor { get; set; }
        public int PedidoId { get; set; }
        public Pedido Pedido { get; set; }
        public int ServicoId { get; set; }
        public Servico Servico { get; set; }

        public ItemPedido()
        {
            
        }

        public ItemPedido(CadastroItemPedidoDTO dto)
        {
            Quantidade = dto.Quantidade;
            Valor = dto.Valor;
            PedidoId = dto.PedidoId;
            ServicoId = dto.ServicoId;
        }

        public void MapearAtualizarItemPedidoDTO(AtualizarItemPedidoDTO dto)
        {
            Quantidade = dto.Quantidade;
            Valor = dto.Valor;
            PedidoId = dto.PedidoId;
            ServicoId = dto.ServicoId;
        }
    }
}