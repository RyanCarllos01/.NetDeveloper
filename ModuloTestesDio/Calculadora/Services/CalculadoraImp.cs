using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Calculadora.Services
{
    public class CalculadoraImp
    {
        public int Somar(int num1, int num2)
        {
            return num1 + num2;
        }

        // verificando se o número é par ou ímpar
        public bool EhPar(int num)
        {
            return num % 2 == 0;
        }
    }
}