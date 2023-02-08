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
    public class itemPedidoController : ControllerBase
    {
        private readonly ItemPedidoRepository _repository;

        public itemPedidoController(ItemPedidoRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public IActionResult Cadastrar(CadastroItemPedidoDTO dto)
        {
            var itempedido = new ItemPedido(dto);
            _repository.Cadastrar(itempedido);
            return Ok(itempedido);
        }

        [HttpGet("{id}")]
        public IActionResult ObterPorId(int id)
        {
            var itempedido = _repository.ObterPorId(id);

            if(itempedido is not null)
                return Ok(itempedido);
            else
                return NotFound(new { Mensagem = "Item pedido não encontrado"});
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, AtualizarItemPedidoDTO dto)
        {
            var itempedido = _repository.ObterPorId(id);

            if(itempedido is not null)
            {
                itempedido.MapearAtualizarItemPedidoDTO(dto);
                _repository.AtualizarItemPedido(itempedido);
                return Ok(itempedido);
            }
            else{
                return NotFound(new { Mensagem = "Item pedido não encontrado"});
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            var itempedido = _repository.ObterPorId(id);
            if(itempedido is not null)
            {
                _repository.DeletarItemPedido(itempedido);
                return NoContent();
            }
            else
            {
                return NotFound(new { Mensagem = "Item pedido não encontrado"});
            }
        }

        [HttpPatch("AtualizarQuantidade/{id}")]
        public IActionResult AtualizarQuantidade(int id, AtualizarQuantidadeItemPedidoDTO dto)
        {
            var itempedido = _repository.ObterPorId(id);
            if(itempedido is not null)
            {
                _repository.AtualizarQuantidade(itempedido, dto);
                return Ok(itempedido);
            }
            else
            {
                return NotFound(new { Mensagem = "Item Pedido não encontrado"});
            }
        }

        [HttpPatch("AtualizarValor/{id}")]
        public IActionResult AtualizarValor(int id, AtualizarValorItemPedidoDTO dto)
        {
            var itempedido = _repository.ObterPorId(id);
            if(itempedido is not null)
            {
                _repository.AtualizarValor(itempedido, dto);
                return Ok(itempedido);
            }
            else
            {
                return NotFound(new { Mensagem = "Item Pedido não encontrado"});
            }
        }
    }
}