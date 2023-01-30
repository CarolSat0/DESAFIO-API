using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DESAFIO_API.Repository;
using Microsoft.AspNetCore.Mvc;

namespace DESAFIO_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class itemPedidoController : ControllerBase
    {
        private readonly ItemPedidoRepository _repository;

        public itemPedidoController(ItemPedidoRepository repository)
        {
            _repository = repository;
        }
    }
}