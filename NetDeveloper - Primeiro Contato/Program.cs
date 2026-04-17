//using NetDeveloper.Models;


using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using Models;

//menu interativo

string opcao;
bool exibirMenu = true;
while (exibirMenu)
{
    Console.Clear();
    Console.WriteLine("Digite a sua opção");
    Console.WriteLine("1 - Cadastrar cliente");
    Console.WriteLine("2 - Buscar Cliente");
    Console.WriteLine("3 - Apagar cliente");
    Console.WriteLine("4 - Encerrar");

    opcao = Console.ReadLine();

    switch(opcao)
    {
        case "1":
        Console.WriteLine("Cadastro de cliente");
        break;

         case "2":
        Console.WriteLine("Busca de cliente");
        break;

         case "3":
        Console.WriteLine("Apagar cliente");
        break;

         case "4":
        Console.WriteLine("Encerrar");
        //Environment.Exit(0);
        exibirMenu = false; // quando vou encerrar ele vai parar de exibir o menu
        break;
        
        default:
        Console.WriteLine("Opção inválida");
        break;
    }
}



// do while, executa o código primeiro 
// int soma = 0, numero = 0;

// do
// {
//     Console.WriteLine("Digite um número(0 para parar)");
//     numero = Convert.ToInt32(Console.ReadLine());

//     soma += numero;

// }while (numero != 0);

// Console.WriteLine($"Total da soma dos números digitados é: {soma}");
// //while

// int numero = 5;
// int contador = 1;

// while (contador <= 10)
// {
//     Console.WriteLine($"{contador} Execução: {numero} X {contador} = {numero * contador}");
//     contador++;
// // pode usar o break para parar a execução antes se precisar
// // if(contador == 5){
// //     break ; 
// // }
// }





// vamos fazer contar tabuada do 5 
// int numero = 5;

// for (int contador = 0; contador <= 10; contador++)
// {
//     Console.WriteLine($"{numero} X {contador} = {numero * contador}");
// }












// Calculadora calc = new Calculadora();

// // calc.Somar(10,30);
// // calc.Subtrair(10, 50);
// // calc.Multiplicar(15, 45);
// // calc.Dividir(2,2);
// // calc.Potencia (3, 3);
// // calc.Seno(30);
// // calc.Coseno(30);
// // calc.Tangente(30);
// calc.RaizQuadrada(9);
// // Incremento e Decremento

// int numeroIncremento = 10;

// Console.WriteLine (numeroIncremento);

// Console.WriteLine("Incrementando o 10");
// //numeroIncremento = numeroIncremento + 1;
// numeroIncremento++; // pra incrementar em 1 se for mais de um usar o exemplo acima

// Console.WriteLine (numeroIncremento);

// int numeroDecremento = 10;

// Console.WriteLine (numeroDecremento);

// Console.WriteLine("Decrementando o 10");
// //numeroDecremento = numeroDecremento - 1;
// numeroDecremento--; // pra incrementar em 1 se for mais de um usar o exemplo acima

// Console.WriteLine (numeroDecremento);





// operador not
// só colocar um ponto de exclamação na variavel 
// bool choveu = true;
// bool estaTarde = false;

// if(!choveu && !estaTarde)
// {
//     Console.WriteLine("Vou pedalar");
// }
// else
// {
//     Console.WriteLine("Vou pedalar um outro dia");
// }

//operador and na prática
// bool possuiPresencaMinima = true;
// double media = 6.5;

// if (possuiPresencaMinima && media >= 7 )
// {
//     Console.WriteLine("Aprovado");
// }
// else
// {
//     Console.WriteLine("Reprovado");
// }
//operador or na prática
// bool ehMaiorDeIdade = false;
// bool possuiAutorizacaoDoResponsavel = true;

// if (ehMaiorDeIdade || possuiAutorizacaoDoResponsavel)
// {
//     Console.WriteLine("Entrada liberada");
// }
// else
// {
//     Console.WriteLine("Entrada não liberada");
// }

//aprendendo o switch case, identificar se é uma vogal ou não 
// Console.WriteLine("Digita uma letra");
// string letra = Console.ReadLine(); // o readline permite que digite algo 
// // fazendo o melhor heheh
// switch (letra) // declarando a variavel
// {
// case "a": // o case é tipo o if, se for um desses case vai 
// case "e": // retornar o primeiro writeline
// case "i":
// case "o":
// case "u":
// Console.WriteLine("Vogal");
// break; // para sair do switch

// default: // é como se fosse o else
// Console.WriteLine("Não é uma vogal");
// break;
// }





// tem como melhorar o if que estamos vendo abaixo
// if (letra == "a" || // esse || é o sinal de ou 
// letra == "e" ||
// letra == "i" ||
// letra == "o" ||
// letra == "u")
// {
//     Console.WriteLine("Vogal");
// }
// else
// {
//      Console.WriteLine("Não é uma vogal");
// }

// se fosse if seria bem mais trabalhoso olha como é comédia
// if (letra =="a")
// {
//     Console.WriteLine("Vogal");
// }
// else if (letra =="e")
// {
//     Console.WriteLine("Vogal");
// }
// else if (letra =="i")
// {
//     Console.WriteLine("Vogal");
// }
// else if (letra =="o")
// {
//     Console.WriteLine("Vogal");
// }
// else if (letra =="u")
// {
//     Console.WriteLine("Vogal");
// }
// else{
//     Console.WriteLine("não é uma vogal");
// }

//operador condicional na prática
/*
int quantidadeEmEstoque = 3;
int quantidadeCompra = 0;
bool possivelVenda = quantidadeCompra > 0 && quantidadeEmEstoque >= quantidadeCompra;

Console.WriteLine($"Quantidade em estoque: {quantidadeEmEstoque}");
Console.WriteLine($"Quantidade compra: {quantidadeCompra}");
Console.WriteLine($"É possivel realizar a venda? {possivelVenda}");
if(quantidadeCompra == 0)
{Console.WriteLine("Venda inválida");}


else if(possivelVenda)
{
    Console.WriteLine("Venda realizada");

}
else
{
    Console.WriteLine("Desculpe. não temos a quantidade em estoque.");
}

*/








// // convertendo de maneira segura
// string a = "15-";
// int b = 0;
// int.TryParse(a, out b);
// Console.WriteLine(b);
// ordem dos operadores
// double a = 4 / (2 + 2);

// Console.WriteLine(a);

// cast implicito
//int a =5;
//double b = a;
//Console.WriteLine(b);


// Conversão para String
//int inteiro = 5;
//string a = inteiro.ToString();
//Console.WriteLine(a);
// Convertendo tipo de variáveis
// se chama cast - Casting
// int a = Convert.ToInt32("5");

// Tem como fazer assim também 
//int a = int.Parse("5"); //converte string para inteiro
//Console.WriteLine(a);

/*
DateTime dataAtual = DateTime.Now.AddDays(5); //sempre pega a data e hora atual da máquina
Console.WriteLine(dataAtual.ToString("dd/MM/yyyy")); */
/*
string apresentacao = "Olá, seja bem vindo";
int quantidade =1;
Console.WriteLine("Valor da variável quantidade:" + quantidade);
quantidade = 10;
Console.WriteLine("Valor da variável quantidade:" + quantidade);
double altura = 1.80;
decimal preco = 1.80M;
bool condicao = true;

Console.WriteLine(apresentacao);
Console.WriteLine("Valor da variável quantidade:" + quantidade);
Console.WriteLine("Valor da variável altura:" + altura.ToString("0.00"));
Console.WriteLine("Valor da variável preco:" + preco);
Console.WriteLine("Valor da variável condicao:" + condicao);
*/


/*
Pessoa pessoa1 = new Pessoa();

pessoa1.Nome = "Ryan";
pessoa1.Idade = 26;
pessoa1.Apresentar();

Pessoa pessoaFisicaRepresentacao = new Pessoa();

*/