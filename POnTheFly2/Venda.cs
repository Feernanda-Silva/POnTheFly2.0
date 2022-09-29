using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POnTheFly2
{
    internal class Venda
    {
        public string IdVenda { get; set; }
        public DateTime DataVenda { get; set; }
        public float ValorTotal { get; set; }
        public string Cpf { get; set; }


        public void CadastrarVenda(SqlConnection sqlConnection, ConexaoBanco conexaoBanco)
        {
           this.DataVenda = DateTime.Now;

            Console.WriteLine("Digite o CPF do passageiro: ");
            this.Cpf = Console.ReadLine();

            while (conexaoBanco.ExistirCpf(sqlConnection, this.Cpf) == false )
            {
                Console.WriteLine("O CPF não existe no cadastro de passageiros");
            }

            conexaoBanco.ExibirPassageiro(sqlConnection, this.Cpf);

            /*Console.WriteLine("Digite a quantidade de passagemq que deseja comprar: ");
            int quantidade = Console.ReadLine;
            float valorPassagem = 
            this.ValorTotal = quantidade * 
            // Valor Total com base na classe Passagem

            conexaoBanco.InserirVenda()*/
        }

        public void LocalizarVenda()
        {

        }

        public void CancelarVenda()
        {

        }

        public void ImprimirVenda()
        {

        }

    

    }
}
