using NUnit.Framework;
using Moq;
using CalculadoraLib;
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
        var timeMock = new Mock<ITimeProvider>();
        timeMock.Setup(tp => tp.Now).Returns(new DateTime(2025,1,1,11,0,0));
        var calc = new Calculadora(timeMock.Object);


        var resultado = calc.Sumar(2, 3);
        var expected = 5;
        Assert.That(expected, Is.EqualTo(resultado));
        
    }

    [Test]
    public void Restar_DeberiaRetornarResultadoCorrecto()
    {
        var timeMock = new Mock<ITimeProvider>();
        timeMock.Setup(tp => tp.Now).Returns(new DateTime(2025,1,1,11,0,0));
        var calc = new Calculadora(timeMock.Object);

        var resultado = calc.Restar(2, 1);
        var expected = 1;
        Assert.That(expected,Is.EqualTo(resultado));

    }

    [Test]
    public void Multiplicar_DeberiaRetornarResultadoCorrecto()
    {
        var resultado = _calc.Multiplicar(2, 3);
        var expected = 6;
        Assert.That(expected,Is.EqualTo(resultado));

    }

    [Test]
    public void Dividir_DeberiaRetornarResultadoCorrecto()
    {
        var resultado = _calc.Dividir(6, 2);
        var expected = 3;
        Assert.That(expected,Is.EqualTo(resultado));

    }

    [Test]
    public void ManejoError_Dividir_DeberiaRetornarResultadoCorrecto()
    {
        Assert.Throws<DivideByZeroException>(() => _calc.Dividir(10,0));
    }


}