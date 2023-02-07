using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DESAFIO_API.Dto
{
    public class AtualizarItemPedidoDTO
    {
        public int Quantidade { get; set; }
        public float Valor { get; set; }
        public int PedidoId { get; set; }
        public int ServicoId { get; set; }
    }
}