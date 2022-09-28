using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POnTheFly2
{
    internal class Destino
    {
        public  string Sigla { get; set; }
        public string Aeroporto { get; set; }


        public void CadastrarDestino(SqlConnection sqlConection, ConexaoBanco conexaoBanco)
        {
            Console.WriteLine("Sigla: ");
            this.Sigla = Console.ReadLine();

            Console.WriteLine("Nome do Aeroporto de Destino");
            this.Aeroporto = Console.ReadLine();

            conexaoBanco.InserirDestino(sqlConection, this.Sigla, this.Aeroporto);

        }

        public void LocalizarDestino(SqlConnection sqlConnection, ConexaoBanco conexaoBanco)
        {

        }
    }
}
