using System;
using System.Collections.Generic;
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

        public void CadastrarPassageiro() 
        {

        }

        public void LocalizarPassageiro() 
        {

        }

        public void EditarPassageiro() 
        {

        }

        public void ImprimirPassageiro() //Por Registro: Anterior, atual, próximo
        {

        }

        public bool ValidarCpf() //Numero de campos
        {
            return true; //false
        }


    }
}
