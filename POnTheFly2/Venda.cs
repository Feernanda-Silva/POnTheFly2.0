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
            conexaoBanco.AssentosOcupados(sqlConnection, idPassagem);

            Console.WriteLine("Escolha a opção desejada!");
            Console.WriteLine("1-Reservar passagem");
            Console.WriteLine("2-Pagar passagem"); 
            int op = int.Parse(Console.ReadLine());

            while (op != 1 && op !=2)
            {
                Console.WriteLine("Digite uma opção valida");
                op = int.Parse(Console.ReadLine()); 
            }

            conexaoBanco.EditarSituacao(sqlConnection, idPassagem, op); 
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

        public void ImprimirVenda(SqlConnection sqlConnection, ConexaoBanco conexaoBanco)
        {
            int opc;
            int pagina = 0;

            do
            {

                Console.WriteLine("1-Primeiro");
                Console.WriteLine("2-Próximo");
                Console.WriteLine("3-Anterior");
                Console.WriteLine("4-Ultimo");
                opc = int.Parse(Console.ReadLine());

                switch (opc)
                {
                    case 1:
                        pagina = 0; //por posição
                        break;
                    case 2:
                        pagina = pagina + 1;
                        break;
                    case 3:
                        pagina = pagina - 1;
                        break;
                    case 4:
                        pagina = conexaoBanco.ContarVenda(sqlConnection) - 1;
                        break;
                }

                conexaoBanco.ImprimirVenda(sqlConnection, pagina);

            } while (opc > 0 && opc < 5);
        }

    }
}
