using CalculadoraLib;
using Moq;
using NUnit.Framework;
namespace CalculadoraTests;

[TestFixture]
public class CalculadoraUnitTests
{
    private Calculadora _calc;

    [SetUp]
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
        timeMock.Setup(tp => tp.Now).Returns(new DateTime(2025, 9, 27, 10, 0, 0));
        var calc = new Calculadora(timeMock.Object);

        var resultado = calc.Sumar(2, 3);
        var expected = 5;
        Assert.That(expected, Is.EqualTo(resultado));
    }

    [Test]
    public void RestarDeberiaRetornarResultadoCorrecto() 
    {
        // Arrange
        var timeMock = new Mock<ITimeProvider>();
        timeMock.Setup(tp => tp.Now).Returns(new DateTime(2025, 9, 27, 12, 0, 0));
        var calc = new Calculadora(timeMock.Object);

        var resultado = calc.Restar(10, 3);
        var expected = 7;
        Assert.That(expected, Is.EqualTo(resultado));
    }

    [Test]
    public void MultiplicarDeberiaRetornarResultadoCorrecto()
    {
        // Arrange
        var timeMock = new Mock<ITimeProvider>();
        timeMock.Setup(tp => tp.Now).Returns(new DateTime(2025, 9, 27, 13, 0, 0));
        var calc = new Calculadora(timeMock.Object);

        var resultado = calc.Multiplicar(3, 5);
        var expected = 15;
        Assert.That(expected, Is.EqualTo(resultado));
    }

    [Test]
    public void Division_Normal_DeberiaRetornarResultadoCorrecto()
    {
        // Arrange
        var timeMock = new Mock<ITimeProvider>();
        timeMock.Setup(tp => tp.Now).Returns(new DateTime(2025, 9, 27, 13, 0, 0));
        var calc = new Calculadora(timeMock.Object);

        var resultado = calc.Dividir(20, 2);
        var expected = 10;
        Assert.That(expected, Is.EqualTo(resultado));
    }
    [Test]
    public void Division_Entre_Cero_DeberiaRetornarResultadoCorrecto() 
    {
        var timeMock = new Mock<ITimeProvider>();
        timeMock.Setup(tp => tp.Now).Returns(new DateTime(2025, 9, 27, 13, 0, 0));
        var calc = new Calculadora(timeMock.Object);
        Assert.Throws<DivideByZeroException>(() => calc.Dividir(10, 0));
        
    }
}