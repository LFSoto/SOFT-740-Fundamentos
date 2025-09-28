using CalculadoraLib;
using Moq;
namespace CalculadoraTests;

[TestFixture]
public class CalculadoraUnitTests
{
    Mock<ITimeProvider> _timeMockHoraHabil = new Mock<ITimeProvider>();
    Mock<ITimeProvider> _timeMockHoraNoHabil = new Mock<ITimeProvider>();

    [SetUp]
    public void Setup()
    {
        _timeMockHoraHabil.Setup(tp => tp.Now).Returns(new DateTime(2025, 9, 28, 9, 30, 00));
        _timeMockHoraNoHabil.Setup(tp => tp.Now).Returns(new DateTime(2025, 9, 27, 21, 30, 00));
    }

    #region HoraHabil

    [Test]
    public void SumarDeberiaRetornarResultadoCorrecto()
    {
        //Arrange
        Calculadora calc = new Calculadora(_timeMockHoraHabil.Object);

        int resultado = calc.Sumar(2, 3);

        Assert.That(resultado, Is.EqualTo(5));
    }

    [Test]
    public void RestarDeberiaRetornarResultadoCorrecto()
    {
        //Arrange
        Calculadora calc = new Calculadora(_timeMockHoraHabil.Object);

        int resultado = calc.Restar(2, 3);

        Assert.That(resultado, Is.EqualTo(-1));
    }

    [Test]
    public void MultiplicarDeberiaRetornarResultadoCorrecto()
    {
        //Arrange
        Calculadora calc = new Calculadora(_timeMockHoraHabil.Object);

        int resultado = calc.Multiplicar(2, 3);

        Assert.That(resultado, Is.EqualTo(6));
    }

    [Test]
    public void DividirDeberiaRetornarResultadoCorrecto()
    {
        //Arrange
        Calculadora calc = new Calculadora(_timeMockHoraHabil.Object);

        double resultado = calc.Dividir(10, 4);

        Assert.That(resultado, Is.EqualTo(2.5));
    }

    [Test]
    public void DividirDeberiaRetornarError()
    {
        //Arrange
        Calculadora calc = new Calculadora(_timeMockHoraHabil.Object);

        Assert.Throws<DivideByZeroException>(() => calc.Dividir(5, 0));
    }

    #endregion

    #region HoraNoHabil

    [Test]
    public void SumarDeberiaRetornarErrorPorHorario()
    {
        //Arrange
        Calculadora calc = new Calculadora(_timeMockHoraNoHabil.Object);

        Assert.Throws<InvalidOperationException>(() => calc.Sumar(2, 3));
    }

    [Test]
    public void RestarDeberiaRetornarErrorPorHorario()
    {
        //Arrange
        Calculadora calc = new Calculadora(_timeMockHoraNoHabil.Object);

        Assert.Throws<InvalidOperationException>(() => calc.Restar(2, 3));
    }

    [Test]
    public void MultiplicarDeberiaRetornarErrorPorHorario()
    {
        //Arrange
        Calculadora calc = new Calculadora(_timeMockHoraNoHabil.Object);

        Assert.Throws<InvalidOperationException>(() => calc.Multiplicar(2, 3));
    }

    [Test]
    public void DividirDeberiaRetornarErrorPorHorario()
    {
        //Arrange
        Calculadora calc = new Calculadora(_timeMockHoraNoHabil.Object);

        Assert.Throws<InvalidOperationException>(() => calc.Dividir(10, 4));
    }

    [Test]
    public void DividirDeberiaErrorPorHorario()
    {
        //Arrange
        Calculadora calc = new Calculadora(_timeMockHoraNoHabil.Object);

        Assert.Throws<InvalidOperationException>(() => calc.Dividir(5, 0));
    }

    #endregion
}