using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DESAFIO_API.Dto;

namespace DESAFIO_API.Model
{
    public class Servico
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }

        public Servico()
        {

        }

        public Servico(CadastroServicoDTO dto)
        {
            Nome = dto.Nome;
            Descricao = dto.Descricao;
        }

        public void MapearAtualizarServicoDTO(AtualizarServicoDTO dto)
        {
            Nome = dto.Nome;
            Descricao = dto.Descricao;
        }
    }
}