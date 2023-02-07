using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DESAFIO_API.Model;

namespace DESAFIO_API.Dto
{
    public class ObterItemPedidoDTO
    {
        public int Id {get; set;}
        public int Quantidade { get; set; }
        public float Valor { get; set; }
        public int PedidoId { get; set; }
        public int ServicoId { get; set; }

        public ObterItemPedidoDTO(ItemPedido itempedido)
        {
            Id = itempedido.Id;
            Quantidade = itempedido.Quantidade;
            Valor = itempedido.Valor;
            PedidoId = itempedido.PedidoId;
            ServicoId = itempedido.ServicoId;
        }
    }
}