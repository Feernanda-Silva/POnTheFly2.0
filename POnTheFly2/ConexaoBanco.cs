using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POnTheFly2
{
    internal class ConexaoBanco
    {

        string conexaosql = "Data Source=localhost;Initial Catalog=OnTheFly;User Id=sa;Password=fernanda123;";

        public SqlConnection ConectarBanco()
        {
            SqlConnection conexao = new SqlConnection(this.conexaosql);
            conexao.Open();
            return conexao;
        }


        //Metodos feitos para fazer ações no banco de INSERT, SELECT, UPDATE. 
        //Para Pessoa
        public void InserirPessoa(string cpf, string nome, DateTime dataNascimento, char sexo,
            DateTime dataUltimaCompra, DateTime dataCadastro, char situacao, SqlConnection sqlConnection)

        {
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "INSERT INTO Passageiro(Cpf,Nome, Situacao, DataCadastro, UltimaCompra, Sexo, DataNascimento)" +
                " VALUES(@CPF, @Nome, @Situacao,@DataCadastro,@UltimaCompra, @Sexo, @DataNascimento);";
            cmd.Parameters.AddWithValue("@Cpf", System.Data.SqlDbType.VarChar).Value = cpf;
            cmd.Parameters.AddWithValue("@Nome", System.Data.SqlDbType.Char).Value = nome;
            cmd.Parameters.AddWithValue("@Situacao", System.Data.SqlDbType.Char).Value = situacao;
            cmd.Parameters.AddWithValue("@DataCadastro", System.Data.SqlDbType.DateTime).Value = dataCadastro;
            cmd.Parameters.AddWithValue("@UltimaCompra", System.Data.SqlDbType.DateTime).Value = dataUltimaCompra;
            cmd.Parameters.AddWithValue("@Sexo", System.Data.SqlDbType.DateTime).Value = sexo;
            cmd.Parameters.AddWithValue("@DataNascimento", System.Data.SqlDbType.DateTime).Value = dataNascimento;

            cmd.Connection = sqlConnection;
            cmd.ExecuteNonQuery();
        }

        public void ConsultarPessoa(SqlConnection sqlConnection, string cpf)
        {
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "SELECT Passageiro.Cpf,Passageiro.Nome,Passageiro.Situacao,Passageiro.DataCadastro,Passageiro.UltimaCompra,Passageiro.Sexo,Passageiro.DataNascimento FROM Passageiro WHERE Passageiro.Cpf = @Cpf;";

            cmd.Parameters.AddWithValue("@CPF", System.Data.SqlDbType.VarChar).Value = cpf;

            cmd.Connection = sqlConnection;
            cmd.ExecuteNonQuery();

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    Console.WriteLine("Cpf: {0}", reader.GetString(0));
                    Console.WriteLine("Nome: {0}", reader.GetString(1));
                    Console.WriteLine("Situação: {0}", reader.GetString(2));
                    Console.WriteLine("Data Cadastro: {0}", reader.GetDateTime(3));
                    Console.WriteLine("Ultima Compra: {0}", reader.GetDateTime(4));
                    Console.WriteLine("Sexo: {0}", reader.GetString(5));
                    Console.WriteLine("Data Nascimento: {0}", reader.GetDateTime(6));

                }
            }
        }


        public void AtualizarPessoa(SqlConnection sqlConnection, string cpf, int op)
        {

            if (op == 1)
            {
                Console.WriteLine("Nome: ");
                string nome = Console.ReadLine();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "UPDATE Passageiro SET Nome = @Nome WHERE Passageiro.Cpf = @CPF;";
                cmd.Parameters.AddWithValue("@Cpf", System.Data.SqlDbType.VarChar).Value = cpf;
                cmd.Parameters.AddWithValue("@Nome", System.Data.SqlDbType.VarChar).Value = nome;

                cmd.Connection = sqlConnection;
                cmd.ExecuteNonQuery();

                Console.WriteLine("Edição efetuada com sucesso!");
            }

            else if (op == 2)
            {
                Console.WriteLine("Data de Nascimento: ");
                DateTime dataNascimento = DateTime.Parse(Console.ReadLine());

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "UPDATE Passageiro SET DataNascimento = @DataNascimento WHERE Passageiro.Cpf = @CPF;";
                cmd.Parameters.AddWithValue("@Cpf", System.Data.SqlDbType.VarChar).Value = cpf;
                cmd.Parameters.AddWithValue("@DataNascimento", System.Data.SqlDbType.DateTime).Value = dataNascimento;

                cmd.Connection = sqlConnection;
                cmd.ExecuteNonQuery();

                Console.WriteLine("Edição efetuada com sucesso!");
            }

            else if (op == 3)
            {
                Console.WriteLine("Sexo: ");
                char sexo = Char.Parse(Console.ReadLine());

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "UPDATE Passageiro SET Sexo = @Sexo WHERE Passageiro.Cpf= @CPF;";
                cmd.Parameters.AddWithValue("@Cpf", System.Data.SqlDbType.VarChar).Value = cpf;
                cmd.Parameters.AddWithValue("@Sexo", System.Data.SqlDbType.Char).Value = sexo;

                cmd.Connection = sqlConnection;
                cmd.ExecuteNonQuery();

                Console.WriteLine("Edição efetuada com sucesso!");
            }

            else if (op == 4)
            {
                Console.WriteLine("Data Ultima Compra: ");
                DateTime ultimaCompra = DateTime.Parse(Console.ReadLine());

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "UPDATE Passageiro SET UltimaCompra = @UltimaCompra WHERE Passageiro.Cpf= @CPF;";
                cmd.Parameters.AddWithValue("@Cpf", System.Data.SqlDbType.VarChar).Value = cpf;
                cmd.Parameters.AddWithValue("@UltimaCompra", System.Data.SqlDbType.VarChar).Value = ultimaCompra;

                cmd.Connection = sqlConnection;
                cmd.ExecuteNonQuery();

                Console.WriteLine("Edição efetuada com sucesso!");
            }

            else if (op == 5)
            {
                Console.WriteLine("Data Cadastro: ");
                DateTime dataCadastro = DateTime.Parse(Console.ReadLine());

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "UPDATE Passageiro SET DataCadastro = @DataCadastro WHERE Passageiro.Cpf= @CPF;";
                cmd.Parameters.AddWithValue("@Cpf", System.Data.SqlDbType.VarChar).Value = cpf;
                cmd.Parameters.AddWithValue("@DataCadastro", System.Data.SqlDbType.DateTime).Value = dataCadastro;

                cmd.Connection = sqlConnection;
                cmd.ExecuteNonQuery();

                Console.WriteLine("Edição efetuada com sucesso!");
            }

            else
            {
                Console.WriteLine("Situação: ");
                char situacao = Char.Parse(Console.ReadLine());

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "UPDATE Passageiro SET Situacao = @Situacao WHERE Passageiro.Cpf= @CPF;";
                cmd.Parameters.AddWithValue("@Cpf", System.Data.SqlDbType.VarChar).Value = cpf;
                cmd.Parameters.AddWithValue("@Situacao", System.Data.SqlDbType.Char).Value = situacao;

                cmd.Connection = sqlConnection;
                cmd.ExecuteNonQuery();

                Console.WriteLine("Edição efetuada com sucesso!");
            }

        }

        //Para Pessoas Restritas 
        public void InserirRestrito(SqlConnection sqlConnection, string cpf)
        {
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "INSERT INTO Restritos (Cpf) VALUES(@CPF);";
            cmd.Parameters.AddWithValue("@Cpf", System.Data.SqlDbType.VarChar).Value = cpf;

            cmd.Connection = sqlConnection;
            cmd.ExecuteNonQuery();
        }


        public void ConsultarRestrito(SqlConnection sqlConnection, string cpf)
        {
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "SELECT Cpf From Restritos WHERE Restritos.Cpf = @Cpf;";
            cmd.Parameters.AddWithValue("@Cpf", System.Data.SqlDbType.VarChar).Value = cpf;

            cmd.Connection = sqlConnection;
            cmd.ExecuteNonQuery();


            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    Console.WriteLine("Cpf Restrito pela PF: {0}", reader.GetString(0));
                }
            }
        }

        public void DeletarRestrito(SqlConnection sqlConnection, string cpf)
        {
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "DELETE FROM Restritos WHERE Cpf = @CPF";
            cmd.Parameters.AddWithValue("@CPF", System.Data.SqlDbType.VarChar).Value = cpf;

            cmd.Connection = sqlConnection;
            cmd.ExecuteNonQuery();
        }

        public bool ExistirRestrito(SqlConnection sqlConnection, string cpf)
        {
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "SELECT CPF FROM Restritos WHERE CPF = @CPF";
            cmd.Parameters.AddWithValue("@CPF", System.Data.SqlDbType.VarChar).Value = cpf;

            cmd.Connection = sqlConnection;
            cmd.ExecuteNonQuery();

            bool possuiCpfCadastrado = false;
            using (SqlDataReader reader = cmd.ExecuteReader())
            {

                while (reader.Read())
                {
                    if (reader.IsDBNull(0))
                    {
                        possuiCpfCadastrado = false;
                    }

                    else
                    {
                        possuiCpfCadastrado = true;
                    }
                }
            }
            return possuiCpfCadastrado;
        }



        public bool ExistirCpf(SqlConnection sqlConnection, string cpf) //Se já existe no banco 
        {
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "SELECT CPF FROM Passageiro WHERE CPF = @CPF";
            cmd.Parameters.AddWithValue("@CPF", System.Data.SqlDbType.VarChar).Value = cpf;

            cmd.Connection = sqlConnection;
            cmd.ExecuteNonQuery();

            bool possuiCpfCadastrado = false;
            using (SqlDataReader reader = cmd.ExecuteReader())
            {

                while (reader.Read())
                {
                    if (reader.IsDBNull(0))
                    {
                        possuiCpfCadastrado = false;
                    }

                    else
                    {
                        possuiCpfCadastrado = true;
                    }
                }
            }
            return possuiCpfCadastrado;
        }


        //Para Companhia Aerea
        public void InserirCia(SqlConnection sqlConnection, string cnpj, string razaoSocial, 
            DateTime dataAbertura, DateTime ultimoVoo, DateTime dataCadastro, char situacao)
        {
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "INSERT INTO Companhia_Aerea (Cnpj, RazaoSocial, DataAbertura, DataCadastro, UltimoVoo, Situacao)" +
                " VALUES(@Cnpj, @RazaoSocial, @DataAbertura,@DataCadastro,@UltimoVoo, @Situacao);";
            cmd.Parameters.AddWithValue("@Cnpj", System.Data.SqlDbType.VarChar).Value = cnpj;
            cmd.Parameters.AddWithValue("@RazaoSocial", System.Data.SqlDbType.Char).Value = razaoSocial;
            cmd.Parameters.AddWithValue("@DataAbertura", System.Data.SqlDbType.Char).Value = dataAbertura;
            cmd.Parameters.AddWithValue("@DataCadastro", System.Data.SqlDbType.DateTime).Value = dataCadastro;
            cmd.Parameters.AddWithValue("@UltimoVoo", System.Data.SqlDbType.DateTime).Value = ultimoVoo;
            cmd.Parameters.AddWithValue("@Situacao", System.Data.SqlDbType.DateTime).Value = situacao;
            
            cmd.Connection = sqlConnection;
            cmd.ExecuteNonQuery();
        }

        public void ConsultarCia()
        {

        }

        public void AtualizarCia()
        {

        }

        //Para Companhia Aerea Bloqueadas
        public void InserirBloqueado(SqlConnection sqlConnection, string Cnpj)
        {
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "INSERT INTO Bloqueado (Cnpj) VALUES(@Cnpj);";
            cmd.Parameters.AddWithValue("@Cnpj", System.Data.SqlDbType.VarChar).Value = Cnpj;

            cmd.Connection = sqlConnection;
            cmd.ExecuteNonQuery();
        }

        public void ConsultarBloqueado()
        {

        }

        public void DeletarBloqueado()
        {

        }

        public bool ExistirCnpj(SqlConnection sqlConnection, string cnpj)
        {

            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "SELECT Cnpj FROM Companhia_Aerea WHERE Cnpj = @Cnpj";
            cmd.Parameters.AddWithValue("@Cnpj", System.Data.SqlDbType.VarChar).Value = cnpj;

            cmd.Connection = sqlConnection;
            cmd.ExecuteNonQuery();

            bool possuiCnpjCadastrado = false;
            using (SqlDataReader reader = cmd.ExecuteReader())
            {

                while (reader.Read())
                {
                    if (reader.IsDBNull(0))
                    {
                        possuiCnpjCadastrado = false;
                    }

                    else
                    {
                        possuiCnpjCadastrado = true;
                    }
                }
            }
            return possuiCnpjCadastrado;
        }
    

        // Para Voo
        public void InserirVoo()
        {

        }

        public void ConsultarVoo()
        {

        }

        public void AtualizarVoo()
        {

        }

        public void ExistirVoo()
        {

        }

        //Para Aeronave

        public void InserirAeronave()
        {

        }

        public void ConsultarAeronave()
        {

        }

        public void AtualizarAeronave()
        {

        }

        public void ExistirAeronave()
        {


        }

        //Para Passagem 
        public void InserirPassagem()
        {

        }

        public void ConsultarPassagem()
        {

        }

        public void AtualizarPassagem()
        {

        }

        public void ExistirPassagem()
        {


        }

        //Para Venda
        public void InserirVenda()
        {

        }

        public void ConsultarVenda()
        {

        }

        public void AtualizarVenda()
        {

        }

        public void ExistirVenda()
        {


        }

        //Para item venda 

        public void InserirItemVenda()
        {

        }

        public void ConsultarItemVenda()
        {

        }

    }
}
