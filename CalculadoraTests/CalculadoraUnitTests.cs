using NUnit.Framework;
using CalculadoraLib;
namespace CalculadoraTests;

[TestFixture]
public class CalculadoraUnitTests
{
    private Calculadora _calc;

    [SetUp]
    public void Setup()
    {
        _calc = new Calculadora();
    }


    [Test]
    public void Sumar_DeberiaRetornarResultadoCorrecto()
    {
        var resultado = _calc.Sumar(2, 3);
        Assert.That(5, Is.EqualTo(resultado));
        
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
        Assert.Throws<DivideByZeroException>(() => _calc.Dividir(10,0));
    }

    
}