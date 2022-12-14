using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POnTheFly2
{
    internal class Passagem
    {
        public string IdPassagem { get; set; }

        public char Situacao { get; set; }
        public float Valor { get; set; }
        public DateTime DataUltimaOp { get; set; }
        public string IdVoo { get; set; }

        public void CadastrarPassagem(SqlConnection sqlConnection, ConexaoBanco conexaoBanco)
        {
            Console.WriteLine("IdPassagem: ");
            int numero = int.Parse(Console.ReadLine());
            while (numero < 1000 || numero > 9999)
            {
                Console.WriteLine("Digite um numero de IdVoo valido ( 4 digitos - 1000 até 9999");
                numero = int.Parse(Console.ReadLine());
            }

            this.IdPassagem = "PA" + numero;

            while (conexaoBanco.ExistirPassagem(sqlConnection, this.IdPassagem) == true)
            {
                Console.WriteLine("Impossivel cadastrar uma Passagem!");
                Console.WriteLine("IdPassagem já existe existe!");
                Console.WriteLine("Digite novamente: ");
                Console.WriteLine("IdVoo: ");
                this.IdPassagem = Console.ReadLine();
            }

            Console.WriteLine("IdVoo: ");
            this.IdVoo = Console.ReadLine();

            while (conexaoBanco.ExistirVoo(sqlConnection, this.IdVoo) == false)
            {
                Console.WriteLine("IdVoo não existe!");
                Console.WriteLine("Digite novamente: ");
                this.IdVoo = Console.ReadLine();
            }

            Console.WriteLine("Valor: ");
            this.Valor = float.Parse(Console.ReadLine());

            while (this.Valor > 10000)
            {
                Console.WriteLine("Digite um valor válido (Valores até 9.999,99");
                Console.WriteLine("Valor: ");
                this.Valor = float.Parse(Console.ReadLine());
            }

            //No momento do cadastro a passagem,deve ser livre, pois quando
            //o passageiro comprar mudara para Reservada ou Paga - Usar um Update em Passagem.Situacao 
            this.Situacao = 'L';

            this.DataUltimaOp = DateTime.Now;

            conexaoBanco.InserirPassagem(sqlConnection, this.IdPassagem, this.Situacao,
                this.Valor, this.DataUltimaOp, this.IdVoo);
        }

        public void LocalizarPassagem(SqlConnection sqlConnection, ConexaoBanco conexaoBanco)
        {
            Console.WriteLine("IdPassagem: ");
            this.IdPassagem = Console.ReadLine();

            if (conexaoBanco.ExistirPassagem(sqlConnection, this.IdPassagem) == false)
            {
                Console.WriteLine("Esse IdPassagem não foi localizado!");

            }

            else if (conexaoBanco.ExistirPassagem(sqlConnection, this.IdPassagem) == true)
            {
                conexaoBanco.ConsultarPassagem(sqlConnection, IdPassagem);
            }
        }

        public void EditarPassagem(SqlConnection sqlConnection, ConexaoBanco conexaoBanco)
        {
            Console.WriteLine("Digite o IdPassagem: ");
            this.IdPassagem = Console.ReadLine();

            if (conexaoBanco.ExistirPassagem(sqlConnection, this.IdPassagem) == false)
            {
                Console.WriteLine("IdPassagem não localizado!");
            }

            else if (conexaoBanco.ExistirPassagem(sqlConnection, this.IdPassagem) == true)
            {
                Console.WriteLine("Escolha o campo para editar: ");
                Console.WriteLine("1-Situação");
                Console.WriteLine("2-Valor");
                Console.WriteLine("3-Data Ultima Operação");
                Console.WriteLine("4-IdVoo");

                int op = int.Parse(Console.ReadLine());
                conexaoBanco.AtualizarPassagem(sqlConnection, this.IdPassagem, op);
            }
        }

        public void ImprimirPassagem(SqlConnection sqlConnection, ConexaoBanco conexaoBanco)
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
                        pagina = conexaoBanco.ContarPassagem(sqlConnection) - 1;
                        break;
                }

                conexaoBanco.ImprimirPassagem(sqlConnection, pagina);

            } while (opc > 0 && opc < 5);
        }
    }

}
