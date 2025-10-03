using CalculadoraLib;
using Moq;
using NUnit.Framework;
using System.Threading.Channels;
namespace CalculadoraTests;

[TestFixture]
public class CalculadoraUnitTests
{//pruebas unitarias para validar la funcionalidad de los componentes.

    private Calculadora _calc;

    [SetUp]//se ejecuta antes de cada test.
    public void Setup()
    {
        var timeMock = new Mock<ITimeProvider>();
        _calc = new Calculadora(timeMock.Object);
    }
    [Test]
    public void Sumar_DeberiaRetornarResultadoCorrecto()
    {
        // Arrange
        var timeMock = new Mock<ITimeProvider>();
        timeMock.Setup(tp => tp.Now).Returns(new DateTime(2025, 1, 1, 10, 0, 0));
        var calc = new Calculadora(timeMock.Object);

        var resultado = calc.Sumar(2, 3);
        Assert.That(resultado, Is.EqualTo(5));//Valor actual, valor esperado
    }

    [Test]
    public void Restar_DeberiaRetornarResultadoCorrecto() 
    {
        // Arrange
        var timeMock = new Mock<ITimeProvider>();
        timeMock.Setup(tp => tp.Now).Returns(new DateTime(2025, 1, 1, 10, 0, 0));
        var calc = new Calculadora(timeMock.Object);

        var resultado = calc.Restar(10, 5); // Acá se ocupa llamar a calc, no _calc -> calc es la que modificamos con el mock
        Assert.That(resultado, Is.EqualTo(5));//Valor actual, valor esperado

    }
    [Test]
    public void Multiplicar_DeberiaRetornarResultadoCorrecto()
    {
        // Arrange
        var timeMock = new Mock<ITimeProvider>();
        timeMock.Setup(tp => tp.Now).Returns(new DateTime(2025, 1, 1, 10, 0, 0));
        var calc = new Calculadora(timeMock.Object);

        var resultado = calc.Multiplicar(3, 5);
        Assert.That(resultado, Is.EqualTo(15)); //Valor actual, valor esperado
    }
    [Test]
    public void Dividir_DeberiaRetornarResultadoCorrecto()
    {
        // Arrange
        var timeMock = new Mock<ITimeProvider>();
        timeMock.Setup(tp => tp.Now).Returns(new DateTime(2025, 1, 1, 10, 0, 0));
        var calc = new Calculadora(timeMock.Object);

        var resultado = _calc.Dividir(10, 2);
        Assert.That(resultado, Is.EqualTo(5)); //Valor actual, valor esperado
    }


    [Test]
    public void Division_Entre_Cero_DeberiaRetornarResultadoCorrecto() 
    {
        Assert.Throws<DivideByZeroException>(() => _calc.Dividir(10, 0));
        
    }
}