using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cpll.Models;
using cpll.Services;

namespace cpll.Controllers
{
    internal class AlunoController
    {
        private readonly AlunoService _service = new AlunoService();

        public void Criar(string nome, string email, int idade)
        {
            var aluno = new Aluno
            {
                Nome = nome,
                Email = email,
                Idade = idade
            };

            _service.CriarAluno(aluno);
        }

        public List<Aluno> Listar()
        {
            return _service.ObterTodos();
        }

        public void Atualizar(int id, string nome, string email, int idade)
        {
            var aluno = new Aluno
            {
                Id = id,
                Nome = nome,
                Email = email,
                Idade = idade
            };

            _service.AtualizarAluno(aluno);
        }

        public void Excluir(int id)
        {
            _service.ExcluirAluno(id);
        }
    }
}
