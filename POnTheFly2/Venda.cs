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
        public int IdVenda { get; set; }
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

            Console.WriteLine("Digite a quantidade de passagemq que deseja comprar: ");
            int quantidade = int.Parse(Console.ReadLine());
            if (quantidade > 4 || quantidade <= 0)
            {
                Console.WriteLine("Impossivel comprar mais que 4 passagens!");
            }

            Console.WriteLine("Digite o IdPassagem que deseja comprar: ");
            string idPassagem = Console.ReadLine();

            while (conexaoBanco.ExistirPassagem(sqlConnection, idPassagem) == false)
            {
                Console.WriteLine("IdPassagem inválido!");
                Console.WriteLine("Digite novamente: ");
                idPassagem = Console.ReadLine();
            }

            float valorPassagem = conexaoBanco.ConsultarValorPassagem(sqlConnection, idPassagem);
            this.ValorTotal = quantidade * valorPassagem;



            int idVenda = conexaoBanco.InserirVenda(sqlConnection, this.DataVenda, this.ValorTotal, this.Cpf);

            ItemVenda itemVenda = new ItemVenda();

            for (int i = 0; i < quantidade; i++)
            {
                itemVenda.CadastrarItemVenda(sqlConnection, conexaoBanco, idVenda, valorPassagem, idPassagem);
            }

            //Assentos Ocupados

            //UPDATE Situação da passagem (Paga/ Reservada) 
        }

        public void LocalizarVenda(SqlConnection sqlConnection, ConexaoBanco conexaoBanco)
        {
            Console.WriteLine("Digite o IdVenda: ");
            int idVenda = int.Parse(Console.ReadLine());

            if (conexaoBanco.ExistirVenda(sqlConnection, idVenda) == false)
            {
                Console.WriteLine("IdVenda não localizado!");
            }

            else if (conexaoBanco.ExistirVenda(sqlConnection, idVenda) == true)
            {
                conexaoBanco.ConsultarVenda(sqlConnection, idVenda);
            }
        }

        public void ImprimirVenda()
        {

        }

    }
}
