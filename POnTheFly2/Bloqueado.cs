using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POnTheFly2
{
    internal class Bloqueado
    {
        public string Cnpj { get; set; }
        public Bloqueado()
        {

        }

        public void CadastrarBloqueado(SqlConnection sqlConnection, ConexaoBanco conexaoBanco, CompanhiaAerea companhiaAerea)
        {
            Console.WriteLine("Digite o Cnpj: ");
            this.Cnpj = Console.ReadLine();

            while (companhiaAerea.ValidarCnpj(this.Cnpj) == false || this.Cnpj.Length < 14)
            {
                Console.WriteLine("Cnpj inválido, insira novamente: ");
                this.Cnpj = Console.ReadLine();
            }

            if (conexaoBanco.ExistirBloqueado(sqlConnection, this.Cnpj) == true)
            {
                Console.WriteLine("Esse Cnpj já existe na lista de bloqueados!");
                Console.WriteLine("Impossivel inserir novamente!");
            }

            else
            {
                conexaoBanco.InserirBloqueado(sqlConnection, this.Cnpj);
            }
        }

        public void LocalizarBloqueado(SqlConnection sqlConnection, ConexaoBanco conexaoBanco)
        {
            Console.WriteLine("Digite o Cnpj: ");
            this.Cnpj = Console.ReadLine();

            if (conexaoBanco.ExistirBloqueado(sqlConnection, this.Cnpj) == false)
            {
                Console.WriteLine("Não há nenhuma bloqueio desse CNPJ!");
            }

            else if (conexaoBanco.ExistirBloqueado(sqlConnection, this.Cnpj) == true)
            {
                conexaoBanco.ConsultarBloqueado(sqlConnection, this.Cnpj);
            }
        }

        public void RetirarBloqueado(SqlConnection sqlConnection, ConexaoBanco conexaoBanco)
        {
            Console.WriteLine("Digite o Cnpj: ");
            this.Cnpj = Console.ReadLine();

            if (conexaoBanco.ExistirBloqueado(sqlConnection, this.Cnpj) == false)
            {
                Console.WriteLine("Cnpj não localizado!");
            }

            else if (conexaoBanco.ExistirBloqueado(sqlConnection, this.Cnpj) == true)
            {
                conexaoBanco.DeletarBloqueado(sqlConnection, Cnpj);
            }
        }
    }
}
