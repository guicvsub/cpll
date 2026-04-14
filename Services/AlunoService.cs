using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cpll.Models;
using cpll.Repositories;

namespace cpll.Services
{
    internal class AlunoService
    {
        private readonly AlunoRepository _repo = new AlunoRepository();

        public void CriarAluno(Aluno aluno)
        {
            if (string.IsNullOrEmpty(aluno.Nome))
                throw new System.Exception("Nome é obrigatório");

            _repo.Inserir(aluno);
        }

        public List<Aluno> ObterTodos()
        {
            return _repo.Listar();
        }

        public void AtualizarAluno(Aluno aluno)
        {
            if (string.IsNullOrEmpty(aluno.Nome))
                throw new System.Exception("Nome é obrigatório");

            _repo.Atualizar(aluno);
        }

        public void ExcluirAluno(int id)
        {
            _repo.Excluir(id);
        }
    }
}
