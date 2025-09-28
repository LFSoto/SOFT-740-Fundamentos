using CalculadoraLib;
using Moq;
using NUnit.Framework;
using System;
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
    public void Sumar_DeberiaRetornarResultadoInorrecto()
    {
        // Arrange
        var timeMock = new Mock<ITimeProvider>();
        timeMock.Setup(tp => tp.Now).Returns(new DateTime(2025, 1, 1, 19, 0, 0));
        var calc = new Calculadora(timeMock.Object);

        var resultado = _calc.Sumar(5, 3);
        var expected = 8;
        Assert.That(expected, Is.EqualTo(resultado));
    }

    [Test]
    public void RestarDeberiaRetornarResultadoCorrecto()
    {
        // Arrange
        var timeMock = new Mock<ITimeProvider>();
        timeMock.Setup(tp => tp.Now).Returns(new DateTime(2025, 1, 1, 8, 0, 0));
        var calc = new Calculadora(timeMock.Object);

        var resultado = calc.Restar(10, 3);
        var expected = 7;
        Assert.That(expected, Is.EqualTo(resultado));
    }
    [Test]
    public void RestarDeberiaRetornarResultadoInorrecto()
    {
        // Arrange
        var timeMock = new Mock<ITimeProvider>();
        timeMock.Setup(tp => tp.Now).Returns(new DateTime(2025, 1, 1, 19, 0, 0));
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
        timeMock.Setup(tp => tp.Now).Returns(new DateTime(2025, 1, 1, 10, 0, 0));
        var calc = new Calculadora(timeMock.Object);

        var resultado =  calc.Multiplicar(1, 3);
        var expected = 3;
        Assert.That(expected, Is.EqualTo(resultado));
    }
    [Test]
    public void MultiplicarDeberiaRetornarResultadoIncorrecto()
    {
        // Arrange
        var timeMock = new Mock<ITimeProvider>();
        timeMock.Setup(tp => tp.Now).Returns(new DateTime(2025, 1, 1, 19, 0, 0));
        var calc = new Calculadora(timeMock.Object);

        var resultado = calc.Multiplicar(1, 3);
        var expected = 3;
        Assert.That(expected, Is.EqualTo(resultado));
    }
    [Test]
    public void DivisionDeberiaRetornarResultadoCorrecto()
    {
        Assert.Throws<DivideByZeroException>(() => _calc.Dividir(10, 0));

        // Arrange
        var timeMock = new Mock<ITimeProvider>();
        timeMock.Setup(tp => tp.Now).Returns(new DateTime(2025, 1, 1, 10, 0, 0));
        var calc = new Calculadora(timeMock.Object);

        var resultado = calc.Dividir(10, 2);
        var expected = 5;
        Assert.That(expected, Is.EqualTo(resultado));

    }
    [Test]
    public void Division_Entre_Cero_DeberiaRetornarResultadoIncorrecto()
    {
        Assert.Throws<DivideByZeroException>(() => _calc.Dividir(10, 0));

        // Arrange
        var timeMock = new Mock<ITimeProvider>();
        timeMock.Setup(tp => tp.Now).Returns(new DateTime(2025, 1, 1, 10, 0, 0));
        var calc = new Calculadora(timeMock.Object);

        var resultado = calc.Dividir(5, 0);
        var expected = 0;
        Assert.That(expected, Is.EqualTo(resultado));

    }
    [Test]
    public void Division_DeberiaRetornarResultadoIncorrectoHORA()
    {
        Assert.Throws<DivideByZeroException>(() => _calc.Dividir(10, 0));

        // Arrange
        var timeMock = new Mock<ITimeProvider>();
        timeMock.Setup(tp => tp.Now).Returns(new DateTime(2025, 1, 1, 20, 0, 0));
        var calc = new Calculadora(timeMock.Object);

        var resultado = calc.Dividir(10, 5);
        var expected = 5;
        Assert.That(expected, Is.EqualTo(resultado));

    }
}