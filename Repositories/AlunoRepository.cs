using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cpll.Data;
using cpll.Models;
using MySqlConnector;

namespace cpll.Repositories
{
    internal class AlunoRepository
    {
        private readonly ConnectionFactory _factory = new ConnectionFactory();

        public void Inserir(Aluno aluno)
        {
            using var conn = _factory.CreateConnection();
            conn.Open();

            var cmd = new MySqlCommand(
                "INSERT INTO alunos (nome, email, idade) VALUES (@nome, @email, @idade)", conn);

            cmd.Parameters.AddWithValue("@nome", aluno.Nome);
            cmd.Parameters.AddWithValue("@email", aluno.Email);
            cmd.Parameters.AddWithValue("@idade", aluno.Idade);

            cmd.ExecuteNonQuery();
        }

        public List<Aluno> Listar()
        {
            var lista = new List<Aluno>();

            using var conn = _factory.CreateConnection();
            conn.Open();

            var cmd = new MySqlCommand("SELECT * FROM alunos", conn);
            var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                lista.Add(new Aluno
                {
                    Id = reader.GetInt32("id"),
                    Nome = reader.GetString("nome"),
                    Email = reader.GetString("email"),
                    Idade = reader.GetInt32("idade")
                });
            }

            return lista;
        }

        public void Atualizar(Aluno aluno)
        {
            using var conn = _factory.CreateConnection();
            conn.Open();

            var cmd = new MySqlCommand(
                "UPDATE alunos SET nome=@nome, email=@email, idade=@idade WHERE id=@id", conn);

            cmd.Parameters.AddWithValue("@id", aluno.Id);
            cmd.Parameters.AddWithValue("@nome", aluno.Nome);
            cmd.Parameters.AddWithValue("@email", aluno.Email);
            cmd.Parameters.AddWithValue("@idade", aluno.Idade);

            cmd.ExecuteNonQuery();
        }

        public void Excluir(int id)
        {
            using var conn = _factory.CreateConnection();
            conn.Open();

            var cmd = new MySqlCommand("DELETE FROM alunos WHERE id=@id", conn);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
        }
    }
}
