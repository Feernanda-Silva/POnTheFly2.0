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

            Console.WriteLine("Cadastro efetuado com sucesso!");
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

            Console.WriteLine("Cadastro efetuado com sucesso!");
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

            Console.WriteLine("Remoção efetuada com sucesso!");
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
            cmd.Parameters.AddWithValue("@RazaoSocial", System.Data.SqlDbType.VarChar).Value = razaoSocial;
            cmd.Parameters.AddWithValue("@DataAbertura", System.Data.SqlDbType.DateTime).Value = dataAbertura;
            cmd.Parameters.AddWithValue("@DataCadastro", System.Data.SqlDbType.DateTime).Value = dataCadastro;
            cmd.Parameters.AddWithValue("@UltimoVoo", System.Data.SqlDbType.DateTime).Value = ultimoVoo;
            cmd.Parameters.AddWithValue("@Situacao", System.Data.SqlDbType.Char).Value = situacao;
            
            cmd.Connection = sqlConnection;
            cmd.ExecuteNonQuery();

            Console.WriteLine("Cadastro efetuado com sucesso!");
        }

        public void ConsultarCia(SqlConnection sqlConnection, string cnpj)
        {

            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "SELECT Companhia_Aerea.Cnpj,Companhia_Aerea.RazaoSocial,Companhia_Aerea.DataAbertura,Companhia_Aerea.DataCadastro,Companhia_Aerea.UltimoVoo,Companhia_Aerea.Situacao FROM Companhia_Aerea WHERE Companhia_Aerea.Cnpj = @Cnpj;";
            cmd.Parameters.AddWithValue("@Cnpj", System.Data.SqlDbType.VarChar).Value = cnpj;

            cmd.Connection = sqlConnection;
            cmd.ExecuteNonQuery();

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    Console.WriteLine("Cnpj: {0}", reader.GetString(0));
                    Console.WriteLine("Razao Social: {0}", reader.GetString(1));
                    Console.WriteLine("DataAbertura: {0}", reader.GetDateTime(2));
                    Console.WriteLine("Data Cadastro: {0}", reader.GetDateTime(3));
                    Console.WriteLine("Ultima Voo: {0}", reader.GetDateTime(4));
                    Console.WriteLine("Situação: {0}", reader.GetString(5));
                    

                }
            }
        }

        public void AtualizarCia(SqlConnection sqlConnection, string cnpj, int op)
        {
            if (op == 1)
            {
                Console.WriteLine("Razão Social: ");
                string razaoSocial = Console.ReadLine();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "UPDATE Companhia_Aerea SET RazaoSocial= @RazaoSocial WHERE Cnpj= @Cnpj;";
                cmd.Parameters.AddWithValue("@Cnpj", System.Data.SqlDbType.VarChar).Value = cnpj;
                cmd.Parameters.AddWithValue("@RazaoSocial", System.Data.SqlDbType.VarChar).Value = razaoSocial;

                cmd.Connection = sqlConnection;
                cmd.ExecuteNonQuery();

                Console.WriteLine("Edição efetuada com sucesso!");
            }

            else if (op == 2)
            {
                Console.WriteLine("Data de Abertura: ");
                DateTime dataAbertura = DateTime.Parse(Console.ReadLine());

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "UPDATE Companhia_Aerea SET DataAbertura= @DataAbertura WHERE Cnpj= @Cnpj;";
                cmd.Parameters.AddWithValue("@Cnpj", System.Data.SqlDbType.DateTime).Value = cnpj;
                cmd.Parameters.AddWithValue("@DataAbertura", System.Data.SqlDbType.DateTime).Value = dataAbertura;

                cmd.Connection = sqlConnection;
                cmd.ExecuteNonQuery();

                Console.WriteLine("Edição efetuada com sucesso!");
            }

            else if (op == 3)
            {
                Console.WriteLine("Data Cadastro: ");
                DateTime dataCadastro= DateTime.Parse(Console.ReadLine()); ;

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "UPDATE Companhia_Aerea SET DataCadastro= @DataCadastro WHERE Cnpj= @Cnpj;";
                cmd.Parameters.AddWithValue("@Cnpj", System.Data.SqlDbType.DateTime).Value = cnpj;
                cmd.Parameters.AddWithValue("@DataCadastro", System.Data.SqlDbType.DateTime).Value = dataCadastro;
                cmd.Connection = sqlConnection;
                cmd.ExecuteNonQuery();

                Console.WriteLine("Edição efetuada com sucesso!");
            }

            else if (op == 4)
            {
                Console.WriteLine("Data Ultimo Voo: ");
                DateTime ultimoVoo = DateTime.Parse(Console.ReadLine());

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "UPDATE Companhia_Aerea SET UltimoVoo= @UltimoVoo WHERE Cnpj= @Cnpj;";
                cmd.Parameters.AddWithValue("@Cnpj", System.Data.SqlDbType.VarChar).Value = cnpj;
                cmd.Parameters.AddWithValue("@UltimoVoo", System.Data.SqlDbType.DateTime).Value = ultimoVoo;

                cmd.Connection = sqlConnection;
                cmd.ExecuteNonQuery();

                Console.WriteLine("Edição efetuada com sucesso!");
            }

            else if (op == 5)
            {
                Console.WriteLine("Situação: ");
                char situacao = Char.Parse(Console.ReadLine());

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "UPDATE Companhia_Aerea SET Situacao= @Situacao WHERE Cnpj= @Cnpj;";
                cmd.Parameters.AddWithValue("@Cnpj", System.Data.SqlDbType.VarChar).Value = cnpj;
                cmd.Parameters.AddWithValue("@Situacao", System.Data.SqlDbType.Char).Value = situacao;

                cmd.Connection = sqlConnection;
                cmd.ExecuteNonQuery();

                Console.WriteLine("Edição efetuada com sucesso!");
            }

           
        }

        //Para Companhia Aerea Bloqueadas
        public void InserirBloqueado(SqlConnection sqlConnection, string Cnpj)
        {
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "INSERT INTO Bloqueados (Cnpj) VALUES(@Cnpj);";
            cmd.Parameters.AddWithValue("@Cnpj", System.Data.SqlDbType.VarChar).Value = Cnpj;

            cmd.Connection = sqlConnection;
            cmd.ExecuteNonQuery();

            Console.WriteLine("Cadastro efetuado com sucesso!");
        }

        public void ConsultarBloqueado(SqlConnection sqlConnection, string cnpj)
        {
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "SELECT Cnpj From Bloqueados WHERE Bloqueados.Cnpj = @Cnpj;";
            cmd.Parameters.AddWithValue("@Cnpj", System.Data.SqlDbType.VarChar).Value = cnpj;

            cmd.Connection = sqlConnection;
            cmd.ExecuteNonQuery();


            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    Console.WriteLine("Cnpj bloqueado: {0}", reader.GetString(0));
                }
            }
        }

        public void DeletarBloqueado(SqlConnection sqlConnection, string cnpj)
        {
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "DELETE FROM Bloqueados WHERE Cnpj = @Cnpj";
            cmd.Parameters.AddWithValue("@Cnpj", System.Data.SqlDbType.VarChar).Value = cnpj;

            cmd.Connection = sqlConnection;
            cmd.ExecuteNonQuery();

            Console.WriteLine("Remoção efetuada com sucesso!");
        }

        public bool ExistirBloqueado(SqlConnection sqlConnection, string cnpj)
        {
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "SELECT Cnpj FROM Bloqueados WHERE Cnpj = @Cnpj";
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
        public void InserirVoo(SqlConnection sqlConnection, string idVoo, char situacao, DateTime dataVoo, DateTime dataCadastro, string destino, 
            int assentosOcupados, string inscricao)
        {
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "INSERT INTO Voo (IdVoo,Situacao,DataVoo, DataCadastro, Destino, AssentosOcupados, Inscricao) VALUES(@IdVoo, @Situacao, " +
                "@DataVoo, @DataCadastro,@Destino, @AssentosOcupados, @Inscricao);";
            cmd.Parameters.AddWithValue("@IdVoo", System.Data.SqlDbType.VarChar).Value = idVoo;
            cmd.Parameters.AddWithValue("@Situacao", System.Data.SqlDbType.Char).Value = situacao;
            cmd.Parameters.AddWithValue("@DataVoo", System.Data.SqlDbType.DateTime).Value = dataVoo;
            cmd.Parameters.AddWithValue("@DataCadastro", System.Data.SqlDbType.DateTime).Value = dataCadastro;
            cmd.Parameters.AddWithValue("@Destino", System.Data.SqlDbType.VarChar).Value = destino;
            cmd.Parameters.AddWithValue("@AssentosOcupados", System.Data.SqlDbType.Int).Value = assentosOcupados;
            cmd.Parameters.AddWithValue("@Inscricao", System.Data.SqlDbType.VarChar).Value = inscricao;
           
            cmd.Connection = sqlConnection;
            cmd.ExecuteNonQuery();

            Console.WriteLine("Cadastro efetuado com sucesso!");
        }
    

        public void ConsultarVoo()
        {

        }

        public void AtualizarVoo()
        {

        }

        public bool ExistirVoo(SqlConnection sqlConnection, string idVoo)
        {
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "SELECT IdVoo FROM Voo WHERE IdVoo= @IdVoo";
            cmd.Parameters.AddWithValue("@IdVoo", System.Data.SqlDbType.VarChar).Value = idVoo;

            cmd.Connection = sqlConnection;
            cmd.ExecuteNonQuery();

            bool possuiIdVooCadastrado = false;
            using (SqlDataReader reader = cmd.ExecuteReader())
            {

                while (reader.Read())
                {
                    if (reader.IsDBNull(0))
                    {
                        possuiIdVooCadastrado = false;
                    }

                    else
                    {
                        possuiIdVooCadastrado = true;
                    }
                }
            }
            return possuiIdVooCadastrado;
        }
        public void InserirDestino(SqlConnection sqlConnection, string sigla, string nome)
        {
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "INSERT INTO Destino(Sigla,Nome) VALUES(@Sigla, @Nome);";
            cmd.Parameters.AddWithValue("@Sigla", System.Data.SqlDbType.VarChar).Value = sigla;
            cmd.Parameters.AddWithValue("@Nome", System.Data.SqlDbType.VarChar).Value = nome;

            cmd.Connection = sqlConnection;
            cmd.ExecuteNonQuery();

            Console.WriteLine("Cadastro efetuado com sucesso!");
        }

        public void ConsultarDestino(SqlConnection sqlConnection, string sigla)
        {

        }

        public bool ExistirDestino(SqlConnection sqlConnection, string destino)
        {
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "SELECT Sigla FROM Destino WHERE Sigla= @Destino";
            cmd.Parameters.AddWithValue("@Destino", System.Data.SqlDbType.VarChar).Value = destino; 

            cmd.Connection = sqlConnection;
            cmd.ExecuteNonQuery();

            bool possuiSiglaCadastrada = false;
            using (SqlDataReader reader = cmd.ExecuteReader())
            {

                while (reader.Read())
                {
                    if (reader.IsDBNull(0))
                    {
                        possuiSiglaCadastrada = false;
                    }

                    else
                    {
                        possuiSiglaCadastrada = true;
                    }
                }
            }
            return possuiSiglaCadastrada;
        }

        //Para Aeronave

        public void InserirAeronave(string cnpj, string inscricao, int capacidade, DateTime ultimaVenda,
                DateTime dataCadastro, char situacao, SqlConnection sqlConnection)
        {
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "INSERT INTO Aeronave (Cnpj,Inscricao,Capacidade, UltimaVenda,DataCadastro,Situacao) VALUES (@Cnpj, @Inscricao, @Capacidade,@UltimaVenda,@DataCadastro, @Situacao);";
            cmd.Parameters.AddWithValue("@Cnpj", System.Data.SqlDbType.VarChar).Value = cnpj;
            cmd.Parameters.AddWithValue("@Inscricao", System.Data.SqlDbType.Char).Value = inscricao;
            cmd.Parameters.AddWithValue("@Capacidade", System.Data.SqlDbType.Char).Value = capacidade;
            cmd.Parameters.AddWithValue("@UltimaVenda", System.Data.SqlDbType.DateTime).Value = ultimaVenda;
            cmd.Parameters.AddWithValue("@DataCadastro", System.Data.SqlDbType.DateTime).Value = dataCadastro;
            cmd.Parameters.AddWithValue("@Situacao", System.Data.SqlDbType.DateTime).Value = situacao;

            cmd.Connection = sqlConnection;
            cmd.ExecuteNonQuery();

            Console.WriteLine("Cadastro efetuado com sucesso!");
        }

        public void ConsultarAeronave(SqlConnection sqlConnection, string inscricao)
        {

            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "SELECT Aeronave.Inscricao,Aeronave.Capacidade,Aeronave.UltimaVenda,Aeronave.Situacao,Aeronave.DataCadastro,Aeronave.Cnpj FROM Aeronave WHERE Aeronave.Inscricao = @Inscricao;";
            cmd.Parameters.AddWithValue("@Inscricao", System.Data.SqlDbType.VarChar).Value = inscricao;

            cmd.Connection = sqlConnection;
            cmd.ExecuteNonQuery();

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    Console.WriteLine("Inscricao: {0}", reader.GetString(0));
                    Console.WriteLine("Capacidade: {0}", reader.GetInt32(1));
                    Console.WriteLine("Ultima Venda: {0}", reader.GetDateTime(2));
                    Console.WriteLine("Situação: {0}", reader.GetString(3));
                    Console.WriteLine("Data Cadastro: {0}", reader.GetDateTime(4));
                    Console.WriteLine("Cnpj: {0}", reader.GetString(5));


                }
            }
        }

        public void AtualizarAeronave(SqlConnection sqlConnection, string inscricao, int op)
        {
            if (op == 1)
            {
                Console.WriteLine("Capacidade: ");
                int capacidade = int.Parse(Console.ReadLine());

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "UPDATE Aeronave SET Capacidade= @Capacidade WHERE Inscricao= @Inscricao;";
                cmd.Parameters.AddWithValue("@Inscricao", System.Data.SqlDbType.VarChar).Value = inscricao;
                cmd.Parameters.AddWithValue("@Capacidade", System.Data.SqlDbType.Int).Value = capacidade;

                cmd.Connection = sqlConnection;
                cmd.ExecuteNonQuery();

                Console.WriteLine("Edição efetuada com sucesso!");
            }

            else if (op == 2)
            {
                Console.WriteLine("Ultima Venda: ");
                DateTime ultimaVenda = DateTime.Parse(Console.ReadLine());

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "UPDATE Aeronave SET UltimaVenda= @UltimaVenda WHERE Inscricao= @Inscricao;";
                cmd.Parameters.AddWithValue("@Inscricao", System.Data.SqlDbType.VarChar).Value = inscricao;
                cmd.Parameters.AddWithValue("@UltimaVenda", System.Data.SqlDbType.DateTime).Value = ultimaVenda;

                cmd.Connection = sqlConnection;
                cmd.ExecuteNonQuery();

                Console.WriteLine("Edição efetuada com sucesso!");
            }

            else if (op == 3)
            {
                Console.WriteLine("Situação: ");
                char situacao = Char.Parse(Console.ReadLine());

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "UPDATE Aeronave SET Situacao= @Situacao WHERE Inscricao= @Inscricao;";
                cmd.Parameters.AddWithValue("@Inscricao", System.Data.SqlDbType.VarChar).Value = inscricao;
                cmd.Parameters.AddWithValue("@Situacao", System.Data.SqlDbType.Char).Value = situacao;

                cmd.Connection = sqlConnection;
                cmd.ExecuteNonQuery();

                Console.WriteLine("Edição efetuada com sucesso!");
            }

            else if (op == 4)
            {
                Console.WriteLine("Data Cadastro: ");
                DateTime dataCadastro = DateTime.Parse(Console.ReadLine());

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "UPDATE Aeronave SET DataCadastro= @DataCadastro WHERE Inscricao= @Inscricao;";
                cmd.Parameters.AddWithValue("@Inscricao", System.Data.SqlDbType.VarChar).Value = inscricao;
                cmd.Parameters.AddWithValue("@DataCadastro", System.Data.SqlDbType.DateTime).Value = dataCadastro;

                cmd.Connection = sqlConnection;
                cmd.ExecuteNonQuery();

                Console.WriteLine("Edição efetuada com sucesso!");
            }

     
        }

        public bool ExistirAeronave(SqlConnection sqlConnection, string inscricao)
        {
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "SELECT Inscricao FROM Aeronave WHERE Inscricao= @Inscricao";
            cmd.Parameters.AddWithValue("@Inscricao", System.Data.SqlDbType.VarChar).Value = inscricao;

            cmd.Connection = sqlConnection;
            cmd.ExecuteNonQuery();

            bool possuiIdVooCadastrado = false;
            using (SqlDataReader reader = cmd.ExecuteReader())
            {

                while (reader.Read())
                {
                    if (reader.IsDBNull(0))
                    {
                        possuiIdVooCadastrado = false;
                    }

                    else
                    {
                        possuiIdVooCadastrado = true;
                    }
                }
            }
            return possuiIdVooCadastrado;

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
