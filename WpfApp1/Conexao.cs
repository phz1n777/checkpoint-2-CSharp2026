using MySql.Data.MySqlClient;

namespace MiniCrudEscola.Data
{
    public class Conexao
    {
        private string connectionString = "server=oracle.fiap.com.br;database=Escola;uid=552746;pwd=281204;";

        public MySqlConnection GetConnection()
        {
            return new MySqlConnection(connectionString);
        }
    }
}