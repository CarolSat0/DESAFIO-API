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
    public class ServicoController : ControllerBase
    {
        private readonly ServicoRepository _repository;

        public ServicoController(ServicoRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public IActionResult Cadastrar(CadastroServicoDTO dto)
        {
            var servico = new Servico(dto);
            _repository.Cadastrar(servico);
            return Ok(servico);
        }

        [HttpGet("{id}")]
        public IActionResult ObterPorId(int id)
        {
            var servico = _repository.ObterPorId(id);

            if(servico is not null)
                return Ok(servico);
            else
                return NotFound(new { Mensagem = "Servico não encontrado"});
        }

        [HttpGet("ObterPorNome/{nome}")]
        public IActionResult ObterPorNome(string nome)
        {
            var servicos = _repository.ObterPorNome(nome);
            return Ok(servicos);
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, AtualizarServicoDTO dto)
        {
            var servico = _repository.ObterPorId(id);

            if(servico is not null)
            {
                servico.MapearAtualizarServicoDTO(dto);
                _repository.AtualizarServico(servico);
                return Ok(servico);
            }
            else{
                return NotFound(new { Mensagem = "Servico não encontrado"});
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            var servico = _repository.ObterPorId(id);
            if(servico is not null)
            {
                _repository.DeletarServico(servico);
                return NoContent();
            }
            else
            {
                return NotFound(new { Mensagem = "Servico não encontrado"});
            }
        }

        [HttpPatch ("AtualizarNome/{id}")]
        public IActionResult AtualizarNome(int id, AtualizarNomeServicoDTO dto)
        {
            var servico = _repository.ObterPorId(id);
            if(servico is not null)
            {
                _repository.AtualizarNome(servico, dto);
                return Ok(servico);
            }
            else
            {
                return NotFound(new { Mensagem = "Servico não encontrado"});
            }
        }

        [HttpPatch ("AtualizarDescricao/{id}")]
        public IActionResult AtualizarDescricao(int id, AtualizarDescricaoServicoDTO dto)
        {
            var servico = _repository.ObterPorId(id);
            if(servico is not null)
            {
                _repository.AtualizarDescricao(servico, dto);
                return Ok(servico);
            }
            else
            {
                return NotFound(new { Mensagem = "Servico não encontrado"});
            }
        }
    }
}