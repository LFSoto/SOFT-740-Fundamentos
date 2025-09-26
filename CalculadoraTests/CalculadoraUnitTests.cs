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
        timeMock.Setup(tp => tp.Now).Returns(new DateTime(2025, 1, 1, 10, 0, 0));
        var calc = new Calculadora(timeMock.Object);

        var resultado = calc.Sumar(2, 3);
        var expected = 5;
        Assert.That(expected, Is.EqualTo(resultado));
    }

    [Test]
    public void RestarDeberiaRetornarResultadoCorrecto() 
    {
        var resultado = _calc.Restar(10, 3);
        var expected = 7;
        Assert.That(expected, Is.EqualTo(resultado));
    }

    [Test]
    public void Division_Entre_Cero_DeberiaRetornarResultadoCorrecto() 
    {
        Assert.Throws<DivideByZeroException>(() => _calc.Dividir(10, 0));
        
    }

    [Test]
    public void Restar_DeberiaRetornarResultadoCorrecto()
    {
        var resultado = _calc.Restar(2, 1);
        Assert.AreEqual(1, resultado);

    }

    [Test]
    public void Multiplicar_DeberiaRetornarResultadoCorrecto()
    {
        var resultado = _calc.Multiplicar(2, 3);
        Assert.AreEqual(6, resultado);

    }

    [Test]
    public void Dividir_DeberiaRetornarResultadoCorrecto()
    {
        var resultado = _calc.Dividir(6, 2);
        Assert.AreEqual(3, resultado);

    }


    [Test]
    public void ManejoError_Dividir_DeberiaRetornarResultadoCorrecto()
    {
        var resultado = _calc.Sumar(2, 3);
        Assert.AreEqual(5, resultado);
    }
}