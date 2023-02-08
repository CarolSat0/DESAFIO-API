using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DESAFIO_API.Dto;
using DESAFIO_API.Model;
using DESAFIO_API.Repository;
using Microsoft.AspNetCore.Mvc;

namespace DESAFIO_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PedidoController : ControllerBase
    {
        private readonly PedidoRepository _repository;

        public PedidoController(PedidoRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public IActionResult Cadastrar(CadastroPedidoDTO dto)
        {
            var pedido = new Pedido(dto);
            _repository.Cadastrar(pedido);
            return Ok(pedido);
        }

        [HttpGet("{id}")]
        public IActionResult ObterPorId(int id)
        {
            var pedido = _repository.ObterPorId(id);

            if(pedido is not null)
                return Ok(pedido);
            else
                return NotFound(new { Mensagem = "Pedido não encontrado"});
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, AtualizarPedidoDTO dto)
        {
            var pedido = _repository.ObterPorId(id);

            if(pedido is not null)
            {
                pedido.MapearAtualizarPedidoDTO(dto);
                _repository.AtualizarPedido(pedido);
                return Ok(pedido);
            }
            else{
                return NotFound(new { Mensagem = "Pedidp não encontrado"});
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            var pedido = _repository.ObterPorId(id);
            if(pedido is not null)
            {
                _repository.DeletarPedido(pedido);
                return NoContent();
            }
            else
            {
                return NotFound(new { Mensagem = "Pedido não encontrado"});
            }
        }

        [HttpPatch("AtualizarData/{id}")]
        public IActionResult AtualizarData(int id, AtualizarDataPedidoDTO dto)
        {
            var pedido = _repository.ObterPorId(id);
            if(pedido is not null)
            {
                _repository.AtualizarData(pedido, dto);
                return Ok(pedido);
            }
            else
            {
                return NotFound(new { Mensagem = "Pedido não encontrado"});
            }
        }
    }
}