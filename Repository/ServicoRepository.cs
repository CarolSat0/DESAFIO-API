using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DESAFIO_API.Context;
using DESAFIO_API.Dto;
using DESAFIO_API.Model;

namespace DESAFIO_API.Repository
{
    public class ServicoRepository
    {
        private readonly VendasContext _context;

        public ServicoRepository(VendasContext context)
        {
            _context = context;
        }

        public void Cadastrar(Servico servico)
        {
            _context.Servicos.Add(servico);
            _context.SaveChanges();
        }

        public Servico ObterPorId(int id)
        {
            var servico = _context.Servicos.Find(id);
            return servico;
        }

        public List<ObterServicoDTO> ObterPorNome(string nome)
        {
            var servicos = _context.Servicos.Where(x => x.Nome.Contains(nome))
                                                .Select(x => new ObterServicoDTO(x))
                                                .ToList();
            return servicos;
        }

        public Servico AtualizarServico(Servico servico)
        {
            _context.Servicos.Update(servico);
            _context.SaveChanges();

            return servico;
        }

        public void DeletarServico(Servico servico)
        {
            _context.Servicos.Remove(servico);
            _context.SaveChanges();
        }

        public void AtualizarNome(Servico servico, AtualizarNomeServicoDTO dto)
        {
            servico.Nome = dto.Nome;
            AtualizarServico(servico);
        }
        public void AtualizarDescricao(Servico servico, AtualizarDescricaoServicoDTO dto)
        {
            servico.Descricao = dto.Descricao;
            AtualizarServico(servico);
        }
    }
}