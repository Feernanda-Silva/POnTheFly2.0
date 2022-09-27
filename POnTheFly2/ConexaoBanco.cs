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

        string conexaosql = "Data Source=localhost;Initial Catalog=ONG;User Id=sa;Password=fernanda123;";

        public SqlConnection ConectarBanco()
        {
            SqlConnection conexao = new SqlConnection(this.conexaosql);
            conexao.Open();
            return conexao;
        }


        //Metodos feitos para fazer ações no banco de INSERT, SELECT, UPDATE. 
        //Para Pessoa
        public void InserirPessoa()
        {

        }

        public void ConsultarPessoa()
        {

        }

        public void AtualizarPessoa()
        {

        }

        //Para Pessoas Restritas 
        public void InserirRestrito()
        {

        }

        public void ConsultarRestrito()
        {

        }

        public void DeletarRestrito()
        {

        }


        public bool ExistirCpf() //Se já existe no banco 
        {
            return true; // false
        }

        //Para Companhia Aerea
        public void InserirCia()
        {

        }

        public void ConsultarCia()
        {

        }

        public void AtualizarCia()
        {

        }

        //Para Companhia Aerea Bloqueadas
        public void InserirBloqueado()
        {

        }

        public void ConsultarBloqueado()
        {

        }

        public void DeletarBloqueado()
        {

        }

        public bool ExistirCnpj()
        {
            return true; // false
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
