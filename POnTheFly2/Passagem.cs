using System;
using System.Collections.Generic;
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
        public Venda IdVenda { get; set; }
        public Voo IdVoo { get; set; }

        public void CadastrarPassagem()
        {

        }

        public void LocalizarPassagem()
        {

        }

        public void EditarPassagem()
        {

        }

        public void ImprimirPassagem()
        {

        }
    }
}
