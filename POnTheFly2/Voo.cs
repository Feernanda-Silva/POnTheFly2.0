using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POnTheFly2
{
    internal class Voo
    {
        public string IdVoo { get; set; }
        public char Situacao { get; set; }
        public DateTime DataVoo { get; set; }
        public DateTime DataCadastro { get; set; }
        public string Destino { get; set; }
        public int AssentosOcupados { get; set; }
        public string Inscricao { get; set; }

        public Voo()
        {

        }

        public void CadastrarVoo(SqlConnection sqlConnection, ConexaoBanco conexaoBanco)
        {
            Console.WriteLine("IdVoo: ");
            int numero = int.Parse(Console.ReadLine());
            while (numero < 1000 || numero > 9999)
            {
                Console.WriteLine("Digite um numero de IdVoo valido ( 4 digitos - 1000 até 9999");
                numero = int.Parse(Console.ReadLine());
            }

            this.IdVoo = "V" + numero;

            while (conexaoBanco.ExistirVoo(sqlConnection, this.Inscricao) == true)
            {
                Console.WriteLine("Impossivel cadastrar um Voo!");
                Console.WriteLine("IdVoo já existe existe!");
                Console.WriteLine("Digite novamente: ");
                Console.WriteLine("IdVoo: ");
                this.IdVoo = Console.ReadLine();
            }

            Console.WriteLine("Nome do Aeroporto de Destino: ");
            string aeroporto = Console.ReadLine();
            Console.WriteLine("Sigla do Aeroporto: ");
            string sigla = Console.ReadLine();
            this.Destino = sigla + "-" + aeroporto;

            while(conexaoBanco.ExistirDestino(sqlConnection, this.Destino) == false)
            {
                Console.WriteLine("Impossivel destino, digite um destino existente: ");
                Console.WriteLine("Nome do Aeroporto de Destino: ");
                aeroporto = Console.ReadLine();
                Console.WriteLine("Sigla do Aeroporto: ");
                sigla = Console.ReadLine();
                this.Destino = sigla + "-" + aeroporto;
            }

            Console.WriteLine("Inscrição Aeronave: ");
            this.Inscricao = Console.ReadLine();

            while (conexaoBanco.ExistirAeronave(sqlConnection, this.Inscricao) == false)
            {
                Console.WriteLine("Impossivel cadastrar um Voo!");
                Console.WriteLine("Inscrição de Aeronave não existe!");
                Console.WriteLine("Digite novamente: ");
                Console.WriteLine("Inscrição: ");
                this.Inscricao = Console.ReadLine();
            }

            Console.WriteLine("Data e Hora do Voo (dd/MM/yyyy hh:mm): ");
            this.DataVoo = DateTime.Parse(Console.ReadLine());
            if (DataVoo <= DateTime.Now)
            {
                Console.WriteLine("Essa data é inválida, informe novamente: ");
                this.DataVoo = DateTime.Parse(Console.ReadLine());
            }

            this.DataCadastro = DateTime.Now;

            Console.WriteLine("Situação (A-Ativo / I- Inativo): ");
            this.Situacao = char.Parse(Console.ReadLine());
            while (this.Situacao != 'A' && this.Situacao != 'I')
            {
                Console.WriteLine("Opção invalida, digite novamente");
                Console.WriteLine("Situação(A - Ativo / I - Inativo): ");
                this.Situacao = char.Parse(Console.ReadLine());
            }





        }

        public void LocalizarVoo()
        {

        }

        public void EditarVoo()
        {

        }

        public void ImprimirVoo()
        {

        }

    }
}
