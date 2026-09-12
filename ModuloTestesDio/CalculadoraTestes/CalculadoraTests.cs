using Calculadora.Services;
namespace CalculadoraTests;

public class CalculadoraTests

{
    private CalculadoraImp _calc;

    public CalculadoraTests()
    {
        _calc = new CalculadoraImp();
    }
    [Fact]
    public void DeveSomar5Com10ERetornar15()
    {
        //Arrange , serve para montar o cenário, disponibilizar os dados para criar o cenário
        int num1 = 5;
        int num2 = 10;
        //Act, chama ele pra executar a ação que quer testar, no caso somar
        int resultado = _calc.Somar(num1, num2);
        //Assert, serve pra validar se o resultado que você esparava veio certa
        // o 15 é o resultado esperado, e o resultado é o que veio do método
        Assert.Equal(15, resultado);
    }

    [Fact]
    public void DeveSomar10Com10ERetornar20()
    {
        //Arrange , serve para montar o cenário, disponibilizar os dados para criar o cenário
        int num1 = 10;
        int num2 = 10;
        //Act, chama ele pra executar a ação que quer testar, no caso somar
        int resultado = _calc.Somar(num1, num2);
        //Assert, serve pra validar se o resultado que você esparava veio certa
        // o 20 é o resultado esperado, e o resultado é o que veio do método
        Assert.Equal(20, resultado);
    }

    [Fact]
    public void DeveVerificarse4EhParERetornarVerdadeiro()
    {
        //Arrange
        int numero = 4;
        //Act
        bool resultado = _calc.EhPar(numero);
        //Assert
        // pra verdadeiro ou falso seria bom utilizar o Assert.True
        Assert.True(resultado);
    }
// testando 5 números pares diferentes de uma classe
    [Theory]
    //Arrange
    [InlineData(new int[] { 2, 4 })]
    [InlineData(new int[] { 6, 8, 10})]
   
    public void DeveVerificarSeOsNumerosSaoParesERetornarVerdadeiro(int[] numero)
    {

        //Act /Assert
        Assert.All(numero, num => Assert.True(_calc.EhPar(num)));
    }

}
