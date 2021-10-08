using MVCRazorCRUD.Context;
using MVCRazorCRUD.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace MVCRazorCRUD.Models
{
    public class Professor : UsuarioBase , IProfessor
    {
        public string Cargo { get; set; }

        public void AtualizarProfessor(Professor professor)
        {
            var connection = Conexao.GetConnect();
            connection.Open();
            var query = "update professores set professorNome = @nome, professorEmail = @email, professorEndereco = @end, professorTelefone = @tel, professorCargo = @cargo where professorId = @id";
            var command = new SqlCommand(query, connection);
            command.Parameters.Add("@nome", SqlDbType.VarChar).Value = professor.Nome;
            command.Parameters.Add("@email", SqlDbType.VarChar).Value = professor.Email;
            command.Parameters.Add("@end", SqlDbType.VarChar).Value = professor.Endereco;
            command.Parameters.Add("@tel", SqlDbType.VarChar).Value = professor.Telefone;
            command.Parameters.Add("@cargo", SqlDbType.VarChar).Value = professor.Cargo;
            command.Parameters.Add("@id", SqlDbType.Int).Value = professor.Id;
            // Agora vamos executar a query
            command.ExecuteNonQuery();
            // Fechamos a conexão
            connection.Close();
        }

        public List<Professor> BuscarPorId(int id)
        {
            var connection = Conexao.GetConnect();
            connection.Open();
            var query = "select * from professores where professorId = @id";
            var command = new SqlCommand(query, connection);
            command.Parameters.Add("@id", SqlDbType.Int).Value = id;
            var dataSet = new DataSet();
            var adapter = new SqlDataAdapter(command);
            adapter.Fill(dataSet);

            var rows = dataSet.Tables[0].Rows;
            List<Professor> listaProfessores = new List<Professor>();

            foreach (DataRow item in rows)
            {
                var colunas = item.ItemArray;

                Professor professor = new Professor();

                professor.Id = int.Parse(colunas[0].ToString());
                professor.Nome = colunas[1].ToString();
                professor.Email = colunas[2].ToString();
                professor.Endereco = colunas[3].ToString();
                professor.Telefone = colunas[4].ToString();
                professor.Cargo = colunas[5].ToString();
                listaProfessores.Add(professor);
            }
            connection.Close();
            return listaProfessores;
        }

        public Professor CadastrarProfessor(Professor professor)
        {
            try
            {
                // Definir a conexão - Precisamos criar a classe de conexão
                var connection = Conexao.GetConnect();
                connection.Open();
                var query = "insert into professores (professorNome, professorEmail, professorEndereco, professorTelefone, professorCargo) values (@nome, @email, @end, @tel, @cargo)";
                // Agora vamos juntar a query com a conexão
                var command = new SqlCommand(query, connection);
                // Agora vamos atribuir os valores para as variáveis - formato CamelCase
                command.Parameters.Add("@nome", SqlDbType.VarChar).Value = professor.Nome;
                command.Parameters.Add("@email", SqlDbType.VarChar).Value = professor.Email;
                command.Parameters.Add("@end", SqlDbType.VarChar).Value = professor.Endereco;
                command.Parameters.Add("@tel", SqlDbType.VarChar).Value = professor.Telefone;
                command.Parameters.Add("@cargo", SqlDbType.VarChar).Value = professor.Cargo;
                // Agora vamos executar a query
                command.ExecuteNonQuery();
                // Fechamos a conexão
                connection.Close();
                // retornamos o aluno cadastrado
                return professor;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<Professor> ListarProfessor()
        {
            try
            {
                // Definir a conexão - Precisamos criar a classe de conexão
                var connection = Conexao.GetConnect();
                connection.Open();
                //query
                var query = "select * from professores";
                var command = new SqlCommand(query, connection);
                var dataSet = new DataSet();
                var adapter = new SqlDataAdapter(command);
                adapter.Fill(dataSet);

                var rows = dataSet.Tables[0].Rows;

                List<Professor> listaDeProfessores = new List<Professor>();

                foreach (DataRow item in rows)
                {
                    Professor professor = new Professor();
                    var colunas = item.ItemArray;
                    professor.Id = int.Parse(colunas[0].ToString());
                    professor.Nome = colunas[1].ToString();
                    professor.Email = colunas[2].ToString();
                    professor.Endereco = colunas[3].ToString();
                    professor.Telefone = colunas[4].ToString();
                    professor.Cargo = colunas[5].ToString();

                    listaDeProfessores.Add(professor);
                }
                connection.Close();
                return listaDeProfessores;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public void RemoverProfessor(int id)
        {
            // Definir a conexão - Precisamos criar a classe de conexão
            var connection = Conexao.GetConnect();
            connection.Open();
            //query
            var query = "delete from professores where professorId = @id";
            // Agora vamos juntar a query com a conexão
            var command = new SqlCommand(query, connection);
            command.Parameters.Add("@id", SqlDbType.Int).Value = id;
            // Aqui executamos a query no banco de dados
            command.ExecuteNonQuery();
        }
    }
}
