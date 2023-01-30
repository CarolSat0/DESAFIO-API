using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
    }
}