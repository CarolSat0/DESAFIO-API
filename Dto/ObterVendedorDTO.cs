using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DESAFIO_API.Model;

namespace DESAFIO_API.Dto
{
    public class ObterVendedorDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Login { get; set; }

        public ObterVendedorDTO(Vendedor vendedor)
        {
            Id = vendedor.Id;
            Nome = vendedor.Nome;
            Login = vendedor.Login;
        }
    }
}