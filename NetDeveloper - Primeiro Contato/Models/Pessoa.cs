using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetDeveloper.Models
{
    public class Pessoa
    {
        public String Nome { get; set; }
        public int Idade { get; set; }

        public void Apresentar()
        {
            //Console.WriteLine($"Olá, meu nome é {Nome}" +
            //"tenho {Idade} anos de idade");
             Console.WriteLine($"Olá, meu nome é {Nome} \n tenho {Idade} anos de idade");
             

        }
    }
}