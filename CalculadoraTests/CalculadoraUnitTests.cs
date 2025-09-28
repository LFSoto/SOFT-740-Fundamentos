using CalculadoraLib;
using Moq;
using NUnit.Framework;
namespace CalculadoraTests;

[TestFixture]
public class CalculadoraUnitTests
{
    private Calculadora _calc;
    private Mock<ITimeProvider> timeMock;

    [SetUp]
    public void Setup()
    {
        timeMock = new Mock<ITimeProvider>();
        _calc = new Calculadora(timeMock.Object);
    }
    [Test]
    public void Sumar_DeberiaRetornarResultadoCorrecto()
    {
        // Arrange
        var timeMock = new Mock<ITimeProvider>();
        timeMock.Setup(tp => tp.Now).Returns(new DateTime(2025, 1, 1, 10, 0, 0));
        var calc = new Calculadora(timeMock.Object);
        //Act
        var resultado = calc.Sumar(2, 3);
        var expected = 5;
        //Assert
        Assert.That(expected, Is.EqualTo(resultado));
    }

    [Test]
    public void RestarDeberiaRetornarResultadoCorrecto() 
    {
        // Arrange
        var timeMock = new Mock<ITimeProvider>();
        timeMock.Setup(tp => tp.Now).Returns(new DateTime(2025, 1, 1, 10, 0, 0));
        var calc = new Calculadora(timeMock.Object);
        //Act
        var resultado = calc.Restar(10, 3);
        var expected = 7;
        //Assert
        Assert.That(expected, Is.EqualTo(resultado));
    }

    [Test]
    public void Division_Entre_Cero_DeberiaRetornarResultadoCorrecto() 
    {
        // Arrange
        var timeMock = new Mock<ITimeProvider>();
        timeMock.Setup(tp => tp.Now).Returns(new DateTime(2025, 1, 1, 10, 0, 0));
        var calc = new Calculadora(timeMock.Object);
        //Act & Assert
        Assert.Throws<DivideByZeroException>(() => calc.Dividir(10, 0));
        
    }

    [Test]
    public void Division_DeberiaRetornarResultadoCorrecto() 
    {
        // Arrange
        var timeMock = new Mock<ITimeProvider>();
        timeMock.Setup(tp => tp.Now).Returns(new DateTime(2025, 1, 1, 10, 0, 0));
        var calc = new Calculadora(timeMock.Object);
        //Act
        var resultado = calc.Dividir(10, 2);
        var expected = 5;
        //Assert
        Assert.That(expected, Is.EqualTo(resultado));
    }

    [Test]
    public void Multiplicar_DeberiaRetornarResultadoCorrecto() 
    {
        // Arrange
        var timeMock = new Mock<ITimeProvider>();
        timeMock.Setup(tp => tp.Now).Returns(new DateTime(2025, 1, 1, 10, 0, 0));
        var calc = new Calculadora(timeMock.Object);
        //Act
        var resultado = calc.Multiplicar(4, 5);
        var expected = 20;
        //Assert
        Assert.That(expected, Is.EqualTo(resultado));
    }
}