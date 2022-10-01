using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POnTheFly2
{
    internal class ItemVenda
    {
        public string IdItemVenda { get; set; }
        public int IdVenda { get; set; }    
        public float ValorUnitario { get; set; }
        public string IdPassagem { get; set; }

        public void CadastrarItemVenda(SqlConnection sqlConnection  ,ConexaoBanco conexaoBanco, int idVenda, float valorUnitario, string idPassagem)
        {   

            this.IdVenda = idVenda;
            this.ValorUnitario = valorUnitario;
            this.IdPassagem = idPassagem;

            conexaoBanco.InserirItemVenda(sqlConnection, idVenda, valorUnitario, idPassagem); 
        }
    }
}