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
    public class ClienteController : ControllerBase
    {
        private readonly ClienteRepository _repository;

        public ClienteController(ClienteRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public IActionResult Cadastrar(CadastroClienteDTO dto)
        {
            var cliente = new Cliente(dto);
            _repository.Cadastrar(cliente);
            return Ok(cliente);
        }

        [HttpGet("{id}")]
        public IActionResult ObterPorId(int id)
        {
            var cliente = _repository.ObterPorId(id);

            if(cliente is not null)
                return Ok(cliente);
            else
                return NotFound(new { Mensagem = "Cliente não encontrado"});
        }

        [HttpGet("ObterPorNome/{nome}")]
        public IActionResult ObterPorNome(string nome)
        {
            var clientes = _repository.ObterPorNome(nome);
            return Ok(clientes);
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, AtualizarClienteDTO dto)
        {
            var cliente = _repository.ObterPorId(id);

            if(cliente is not null)
            {
                cliente.MapearAtualizarClienteDTO(dto);
                _repository.AtualizarCliente(cliente);
                return Ok(cliente);
            }
            else{
                return NotFound(new { Mensagem = "Cliente não encontrado"});
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            var cliente = _repository.ObterPorId(id);
            if(cliente is not null)
            {
                _repository.DeletarCliente(cliente);
                return NoContent();
            }
            else
            {
                return NotFound(new { Mensagem = "Cliente não encontrado"});
            }
        }

        [HttpPatch("AtualizarSenha/{id}")]
        public IActionResult AtualizarSenha(int id, AtualizarSenhaClienteDTO dto)
        {
            var cliente = _repository.ObterPorId(id);
            if(cliente is not null)
            {
                _repository.AtualizarSenha(cliente, dto);
                return Ok(cliente);
            }
            else
            {
                return NotFound(new { Mensagem = "Cliente não encontrado"});
            }
        }

        [HttpPatch("AtualizarNome/{id}")]
        public IActionResult AtualizarNome(int id, AtualizarNomeClienteDTO dto)
        {
            var cliente = _repository.ObterPorId(id);
            if(cliente is not null)
            {
                _repository.AtualizarNome(cliente, dto);
                return Ok(cliente);
            }
            else
            {
                return NotFound(new { Mensagem = "Cliente não encontrado"});
            }
        }
    }
}
