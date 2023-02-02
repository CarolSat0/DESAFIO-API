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
    public class VendedorController : ControllerBase
    {
        private readonly VendedorRepository _repository;

        public VendedorController(VendedorRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public IActionResult Cadastrar(CadastrarVendedorDTO dto)
        {
            var vendedor = new Vendedor(dto);
            _repository.Cadastrar(vendedor);
            return Ok(vendedor);
        }

        [HttpGet("{id}")]
        public IActionResult ObterPorId(int id)
        {
            var vendedor = _repository.ObterPorId(id);

            if(vendedor is not null)
                return Ok(vendedor);
            else
                return NotFound(new { Mensagem = "Vendedor não encontrado"});
        }
    }
}