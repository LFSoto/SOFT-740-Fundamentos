using CalculadoraLib;
using Moq;
using NUnit.Framework;
using System;
namespace CalculadoraTests;


/// <summary>
/// Operaciones 1.a de la práctica - Pruebas Unitarias
/// Sumar, Restar, Dividir, Multiplicar
/// </summary>
[TestFixture]
public class CalculadoraUnitTests
{
    private Calculadora _calc;

    [SetUp]
    public void Setup()
    {
        var timeMock = new Mock<ITimeProvider>();
        timeMock.Setup(tp => tp.Now).Returns(new DateTime(2025, 1, 1, 10, 0, 0));
        _calc = new Calculadora(timeMock.Object);
    }

    [Test]
    public void Sumar_DeberiaRetornarResultadoCorrecto()
    {
        var resultado = _calc.Sumar(2, 3);
        var expected = 5;
        Assert.That(expected, Is.EqualTo(resultado));
    }

    [Test]
    public void Restar_DeberiaRetonarResultadoCorrecto()
    {
        var resultado = _calc.Restar(5, 3);
        var resultadoEsperado = 2;
        Assert.That(resultadoEsperado, Is.EqualTo(resultado));
    }

    [Test]
    public void Dividir_DeberiaRetonarResultadoCorrecto()
    {
        var resultadoDivision = _calc.Dividir(9, 3);
        var resultadoEperadoDivision = 3;
        Assert.That(resultadoEperadoDivision, Is.EqualTo(resultadoDivision));
    }

    /// <summary>
    /// Practica 1.b - Manejo de errores
    /// </summary>
    [Test]
    public void Dividir_Entre_Cero_DeberiaRetonarResultadoCorrecto()
    {
        Assert.Throws<DivideByZeroException>(() => _calc.Dividir(10, 0));
    }

    [Test]
    public void Multiplicar_DeberiaRetonarResultadoCorrecto()
    {
        var resultadoMultiplicacion = _calc.Multiplicar(5, 5);
        var resultadoEperadoMultiplicacion = 25;
        Assert.That(resultadoEperadoMultiplicacion, Is.EqualTo(resultadoMultiplicacion));
    }
}