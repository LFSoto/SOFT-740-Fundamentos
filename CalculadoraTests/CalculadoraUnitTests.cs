using CalculadoraLib;
using Moq;
using NUnit.Framework;
using System.Runtime.ConstrainedExecution;
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
    public void Sumar_Retorna_Resultado_Correcto()
    {
        var timeMock = new Mock<ITimeProvider>();
        timeMock.Setup(tp => tp.Now).Returns(new DateTime(2025, 1, 1, 10, 0, 0));
        var calc = new Calculadora(timeMock.Object);

        var resultado = calc.Sumar(2, 3);
        Assert.That(resultado, Is.EqualTo(5));
    }

    [Test]
    public void Restar_Retorna_Resultado_Correcto()
    {
        var timeMock = new Mock<ITimeProvider>();
        timeMock.Setup(tp => tp.Now).Returns(new DateTime(2025, 1, 1, 13, 0, 0));
        var calc = new Calculadora(timeMock.Object);

        var resultado = calc.Restar(10, 6);
        Assert.That(resultado, Is.EqualTo(4));
    }

    [Test]
    public void Multiplicar_Retorna_Resultado_Correcto()
    {
        var timeMock = new Mock<ITimeProvider>();
        timeMock.Setup(tp => tp.Now).Returns(new DateTime(2025, 1, 1, 17, 0, 0));
        var calc = new Calculadora(timeMock.Object);

        var resultado = calc.Multiplicar(5, 2);
        Assert.That(resultado, Is.EqualTo(10));
    }

    [Test]
    public void Dividir_Retorna_Resultado_Correcto()
    {
        var timeMock = new Mock<ITimeProvider>();
        timeMock.Setup(tp => tp.Now).Returns(new DateTime(2025, 1, 1, 17, 0, 0));
        var calc = new Calculadora(timeMock.Object);

        var resultado = calc.Dividir(15, 3);
        Assert.That(resultado, Is.EqualTo(5));
    }

    [Test]
    public void Dividir_Entre_Cero_Retorna_Error()
    {
       Assert.Throws<DivideByZeroException>(() => _calc.Dividir(15, 0));
    }
}