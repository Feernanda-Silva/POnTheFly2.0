using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POnTheFly2
{
    internal class Restritos
    {

        public string Cpf { get; set; }

        public Restritos()
        {

        }
        public void CadastrarRestrito(SqlConnection sqlConnection, ConexaoBanco conexaoBanco, Passageiro passageiro)
        {
            Console.WriteLine("Digite o Cpf: ");
            this.Cpf = Console.ReadLine();

            while (passageiro.ValidarCpf(this.Cpf) == false || this.Cpf.Length < 11)
            {
                Console.WriteLine("CPF inválido, insira novamente: ");
                this.Cpf = Console.ReadLine();
            }

            if (conexaoBanco.ExistirRestrito(sqlConnection, this.Cpf) == true)
            {
                Console.WriteLine("Esse CPF já existe na lista de restritos!");
                Console.WriteLine("Impossivel inserir novamente!");
            }

            else
            {
                conexaoBanco.InserirRestrito(sqlConnection, this.Cpf);
            }

        }

        public void LocalizarRestrito(SqlConnection sqlConnection, ConexaoBanco conexaoBanco)
        {
            Console.WriteLine("Digite o Cpf: ");
            this.Cpf = Console.ReadLine();

            if (conexaoBanco.ExistirRestrito(sqlConnection, Cpf) == false)
            {
                Console.WriteLine("CPF não localizado!");
            }

            else if (conexaoBanco.ExistirRestrito(sqlConnection, Cpf) == true)
            {
                conexaoBanco.ConsultarRestrito(sqlConnection, Cpf);
            }
        }

        public void RetirarRestrito()
        { 

        }


    }
}
