﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POnTheFly2
{
    internal class Aeronave
    {
        public string Inscricao { get; set; }
        public int Capacidade { get; set; }
        public DateTime UltimaVenda { get; set; }
        public DateTime DataCadastro { get; set; }
        public char Situacao { get; set; }
        public string Cnpj { get; set; }

        public Aeronave()
        {

        }

        public String GeraNumero()
        {
            Random rand = new Random();
            int[] numero = new int[100];
            int aux = 0;
            int i;
            String convert = "";
            for (i = 0; i < numero.Length; i++)
            {
                int rnd = 0;
                do
                {
                    rnd = rand.Next(100, 999);
                } while (numero.Contains(rnd));
                numero[i] = rnd;
                aux = numero[i];
                convert = aux.ToString();
                
            }
            return convert;
        }
        public void CadastrarAeronave(ConexaoBanco conexaoBanco, SqlConnection sqlConnection)
        { 

            Console.WriteLine("Cnpj da Companhia Aerea: ");
            this.Cnpj = Console.ReadLine();

            while (conexaoBanco.ExistirCnpj(sqlConnection, this.Cnpj) == false)
            {
                Console.WriteLine("Cnpj não existe! Insira uma companhia aerea existente.");
                Console.WriteLine("Cnpj: ");
                this.Cnpj = Console.ReadLine();
            }

            Console.WriteLine("Digite a sigla do estado: "); 
            this.Inscricao = Console.ReadLine()+"-"+ GeraNumero();
            Console.WriteLine("Inscrição: "+this.Inscricao);

            Console.Write("Capacidade: ");
            this.Capacidade = int.Parse(Console.ReadLine());
            if (this.Capacidade < 100 || this.Capacidade > 999)
            {
                while (true)
                {
                    Console.WriteLine("Capacidade informada inválida!");
                    Console.WriteLine("Digite novamente: ");
                    this.Capacidade = int.Parse(Console.ReadLine());
                }
            }
            this.UltimaVenda = DateTime.Now;
            this.DataCadastro = DateTime.Now;

            Console.WriteLine("Situação (A-Ativo / I- Inativo): ");
            this.Situacao = char.Parse(Console.ReadLine());
            while (this.Situacao != 'A' && this.Situacao != 'I')
            {
                Console.WriteLine("Opção invalida, digite novamente");
                Console.WriteLine("Situação(A - Ativo / I - Inativo): ");
                this.Situacao = char.Parse(Console.ReadLine());
            }

            conexaoBanco.InserirAeronave(this.Cnpj, this.Inscricao, this.Capacidade, this.UltimaVenda,
                this.DataCadastro, this.Situacao, sqlConnection);
        }

        public void LocalizarAeronave(ConexaoBanco conexaoBanco, SqlConnection sqlConnection)
        {
            Console.WriteLine("Digite a Inscrição da Aeronave: ");
            this.Inscricao = Console.ReadLine();

            if (conexaoBanco.ExistirAeronave(sqlConnection, this.Inscricao) == false)
            {
                Console.WriteLine("Inscricao não localizada!");

            }

            else if (conexaoBanco.ExistirAeronave(sqlConnection, this.Inscricao) == true)
            {
                conexaoBanco.ConsultarAeronave(sqlConnection, this.Inscricao);
            }
        }

        public void EditarAeronave()
        {

        }

        public void ImprimirAeronave()
        {

        }
    }
}
