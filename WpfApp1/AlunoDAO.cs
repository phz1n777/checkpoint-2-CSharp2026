using MySql.Data.MySqlClient;
using MiniCrudEscola.Models;
using System.Collections.Generic;

namespace MiniCrudEscola.Data
{
    public class AlunoDAO
    {
        private Conexao conexao = new Conexao();

        public void Inserir(Aluno aluno)
        {
            using (var conn = conexao.GetConnection())
            {
                conn.Open();

                string sql = "INSERT INTO Alunos (Nome, Idade) VALUES (@Nome, @Idade)";
                MySqlCommand cmd = new MySqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@Nome", aluno.Nome);
                cmd.Parameters.AddWithValue("@Idade", aluno.Idade);

                cmd.ExecuteNonQuery();
            }
        }

        public List<Aluno> Listar()
        {
            List<Aluno> lista = new List<Aluno>();

            using (var conn = conexao.GetConnection())
            {
                conn.Open();

                string sql = "SELECT * FROM Alunos";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    lista.Add(new Aluno
                    {
                        Id = reader.GetInt32("Id"),
                        Nome = reader.GetString("Nome"),
                        Idade = reader.GetInt32("Idade")
                    });
                }
            }

            return lista;
        }

        public void Atualizar(Aluno aluno)
        {
            using (var conn = conexao.GetConnection())
            {
                conn.Open();

                string sql = "UPDATE Alunos SET Nome=@Nome, Idade=@Idade WHERE Id=@Id";
                MySqlCommand cmd = new MySqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@Id", aluno.Id);
                cmd.Parameters.AddWithValue("@Nome", aluno.Nome);
                cmd.Parameters.AddWithValue("@Idade", aluno.Idade);

                cmd.ExecuteNonQuery();
            }
        }

        public void Remover(int id)
        {
            using (var conn = conexao.GetConnection())
            {
                conn.Open();

                string sql = "DELETE FROM Alunos WHERE Id=@Id";
                MySqlCommand cmd = new MySqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@Id", id);

                cmd.ExecuteNonQuery();
            }
        }
    }
}