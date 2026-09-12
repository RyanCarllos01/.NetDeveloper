using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExemploExplorando.Models
{
    public class Pessoa
    {
        private string _nome; // isso se chama campo, ou seja, uma variável dentro de uma classe
        public string Nome {
            get => _nome.ToUpper();
            

            set
            {
                if(value == "")
                {
                    throw new ArgumentException("O nome não pode ser vazio");
                }

                _nome = value;
            }
              }

        private int _idade; // isso se chama campo, ou seja, uma variável dentro de uma classe
        public int Idade
         { 
            get => _idade;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("A idade não pode ser menor que zero");
                }
                _idade = value;
            } 
            }

        public void Apresentar() // isso se chama método 
        {
            Console.WriteLine($"Nome: {Nome}, Idade: {Idade}");
        }
    }
}