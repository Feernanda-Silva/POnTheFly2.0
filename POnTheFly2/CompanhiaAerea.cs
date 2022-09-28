using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POnTheFly2
{
    internal class CompanhiaAerea
    {
        public string Cnpj { get; set; }
        public string RazaoSocial { get; set; }
        public DateTime DataAbertura { get; set; }
        public DateTime UltimoVoo { get; set; }
        public DateTime DataCadastro { get; set; }
        public char Situacao { get; set; }

        public CompanhiaAerea()
        {

        }

        public void CadastrarCia(ConexaoBanco conexaoBanco, SqlConnection sqlConnection)
        { 

            Console.WriteLine("Digite o CNPJ da Companhia Aérea: ");
            this.Cnpj = Console.ReadLine();

            while (ValidarCnpj(this.Cnpj) == false || this.Cnpj.Length < 14)
            {
                Console.WriteLine("Digite um Cnpj válido!");
                this.Cnpj = Console.ReadLine();
            }

            while(conexaoBanco.ExistirCnpj(sqlConnection, this.Cnpj) == true)
            {
                Console.WriteLine("Cnpj já cadastrado, faça o cadastro com outro cnpj");
                Console.WriteLine("Cnpj: ");
                this.Cnpj = Console.ReadLine();
            }

            Console.WriteLine("Situação:");
            this.Situacao = Char.Parse(Console.ReadLine());

            while (this.Situacao != 'A' && this.Situacao != 'I')
            {
                Console.WriteLine("Opção invalida, digite novamente");
                Console.WriteLine("Situação(A - Ativo / I - Inativo): ");
                this.Situacao = char.Parse(Console.ReadLine());
            }

            this.UltimoVoo = DateTime.Now;
            this.DataCadastro = DateTime.Now;

            Console.WriteLine("Digite a data de abertura da Companhia: ");
            this.DataAbertura = DateTime.Parse(Console.ReadLine());
            System.TimeSpan tempoAbertura = DateTime.Now.Subtract(DataAbertura);

            Console.WriteLine("Digite a Razão Social (até 50 dígitos) : ");
            this.RazaoSocial = Console.ReadLine();

            if (tempoAbertura.TotalDays < 180 )
            {
                Console.WriteLine("Impossivel cadastrar, o tempo de abertura da empresa é menor que 6 meses ");

            }

            else if (RazaoSocial.Length > 50)
            {
                Console.WriteLine("Impossivel cadastrar, Razão Social excede o numero de caracteres");
            }

            else
            {
                conexaoBanco.InserirCia(sqlConnection,this.Cnpj, this.RazaoSocial, this.DataAbertura, this.UltimoVoo,this.DataCadastro, this.Situacao);
               
            }
            
        }
    

        public void LocalizarCia( ConexaoBanco conexaoBanco, SqlConnection sqlConnection)
        {
            Console.WriteLine("Digite o CNPJ da Companhia Aérea: ");
            this.Cnpj = Console.ReadLine();

            if (conexaoBanco.ExistirCnpj(sqlConnection, this.Cnpj) == false)
            {
                Console.WriteLine("Cnpj não localizado!");
             
            }

            else if(conexaoBanco.ExistirCnpj(sqlConnection, this.Cnpj) == true)
            {
                conexaoBanco.ConsultarCia(sqlConnection, this.Cnpj);
            }


        }

        public void EditarCia(ConexaoBanco conexaoBanco, SqlConnection sqlConnection)
        {
            Console.WriteLine("Digite o Cnpj: ");
            string cnpj = Console.ReadLine();

            if (conexaoBanco.ExistirCnpj(sqlConnection, cnpj) == false)
            {
                Console.WriteLine("Cnpj não localizado!");
            }

            else if (conexaoBanco.ExistirCnpj(sqlConnection, cnpj) == true)
            {
                Console.WriteLine("Escolha o campo para editar: ");
                Console.WriteLine("1-Razao Social");
                Console.WriteLine("2-Data Abertura");
                Console.WriteLine("3-Data Cadastro");
                Console.WriteLine("4-Ultimo Voo");
                Console.WriteLine("5-Situação");
                int op = int.Parse(Console.ReadLine());

                conexaoBanco.AtualizarCia(sqlConnection, cnpj, op);
            }
        }

        public void ImprimirCia()
        {

        }

        public bool ValidarCnpj(string cnpj)
        {
            int[] multiplicador1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

            int soma;
            int resto;
            string digito;
            string tempCnpj;

            cnpj = cnpj.Trim();
            cnpj = cnpj.Replace(".", "").Replace("-", "").Replace("/", "");

            if (cnpj.Length != 14)
                return false;


            tempCnpj = cnpj.Substring(0, 12);
            soma = 0;

            for (int i = 0; i < 12; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];

            resto = (soma % 11);

            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = resto.ToString();
            tempCnpj = tempCnpj + digito;
            soma = 0;

            for (int i = 0; i < 13; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];

            resto = (soma % 11);

            if (resto < 2)
                resto = 0;
            else

                resto = 11 - resto;

            digito = digito + resto.ToString();
            return cnpj.EndsWith(digito);
        }




    }
}
