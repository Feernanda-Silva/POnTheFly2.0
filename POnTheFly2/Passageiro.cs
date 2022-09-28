using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POnTheFly2
{
    internal class Passageiro
    {

        public string Cpf { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public char Sexo { get; set; }
        public DateTime DataUltimaCompra { get; set; }
        public DateTime DataCadastro { get; set; }
        public char Situacao { get; set; }

        public Passageiro()
        {

        }

        public void CadastrarPassageiro(ConexaoBanco conexaoBanco, SqlConnection sqlConnection)
        {
            Console.WriteLine("CADASTRO DE PASSAGEIRO");
            Console.WriteLine("Nome: ");
            this.Nome = Console.ReadLine();

            while (this.Nome.Length > 50)
            {
                Console.WriteLine("Digite um nome de até 50 digitos!");
                Console.WriteLine("Nome: ");
                this.Nome = Console.ReadLine();
            }

            //validação do tamanho e condição de cpf valido
            Console.WriteLine("CPF: ");
            this.Cpf = Console.ReadLine();
            while (ValidarCpf(this.Cpf) == false || this.Cpf.Length < 11)
            {
                Console.WriteLine("Cpf invalido, digite novamente");
                Console.WriteLine("CPF: ");
                this.Cpf = Console.ReadLine();
            }

            //validação da condição de não existir dois registros com cpfs iguais
            while (conexaoBanco.ExistirCpf(sqlConnection, this.Cpf) == true)
            {
                Console.WriteLine("Cpf já cadastrado, faça o cadastro com outro cpf");
                Console.WriteLine("CPF: ");
                this.Cpf = Console.ReadLine();
            }

            Console.WriteLine("Data de nascimento: ");
            this.DataNascimento = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Sexo (M/F/N): ");
            this.Sexo = char.Parse(Console.ReadLine());
            while (this.Sexo != 'M' && this.Sexo != 'F' && this.Sexo != 'N')
            {
                Console.WriteLine("Opção invalida, digite novamente");
                Console.WriteLine("Sexo (M/F/N): ");
                this.Sexo = char.Parse(Console.ReadLine());
            }


            this.DataUltimaCompra = DateTime.Now;

            this.DataCadastro = DateTime.Now;

            Console.WriteLine("Situação (A-Ativo / I- Inativo): ");
            this.Situacao = char.Parse(Console.ReadLine());
            while (this.Situacao != 'A' && this.Situacao != 'I')
            {
                Console.WriteLine("Opção invalida, digite novamente");
                Console.WriteLine("Situação(A - Ativo / I - Inativo): ");
                this.Situacao = char.Parse(Console.ReadLine());
            }

            conexaoBanco.InserirPessoa(this.Cpf, this.Nome, this.DataNascimento, this.Sexo, 
                this.DataUltimaCompra,this.DataCadastro, this.Situacao, sqlConnection); 
        }


        public void LocalizarPassageiro(ConexaoBanco conexaoBanco, SqlConnection sqlConnection)
        {
            Console.WriteLine("Digite o CPF: ");
            string Cpf = Console.ReadLine();

            if (conexaoBanco.ExistirCpf(sqlConnection, Cpf) == false)
            {
                Console.WriteLine("CPF não localizado!");
            }

            else if (conexaoBanco.ExistirCpf(sqlConnection,Cpf) == true)
            {
                conexaoBanco.ConsultarPessoa(sqlConnection, Cpf);
            }

        }

        public void EditarPassageiro(ConexaoBanco conexaoBanco, SqlConnection sqlConnection)
        {
            Console.WriteLine("Digite o Cpf: ");
            string cpf = Console.ReadLine();

            if (conexaoBanco.ExistirCpf(sqlConnection, cpf) == false)
            {
                Console.WriteLine("CPF não localizado!");
            }

            else if (conexaoBanco.ExistirCpf(sqlConnection, cpf) == true)
            {
                conexaoBanco.AtualizarPessoa(sqlConnection, cpf);
            }

        }

        public void ImprimirPassageiro() //Por Registro: Anterior, atual, próximo
        {

        }

        public bool ValidarCpf(string cpf) //Numero de campos
        {
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digito;
            int soma;
            int resto;
            cpf = cpf.Trim();
            cpf = cpf.Replace(".", "").Replace("-", "");
            if (cpf.Length != 11)
                return false;
            tempCpf = cpf.Substring(0, 9);
            soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = resto.ToString();
            tempCpf = tempCpf + digito;
            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = digito + resto.ToString();
            return cpf.EndsWith(digito);
        }

    }
}

