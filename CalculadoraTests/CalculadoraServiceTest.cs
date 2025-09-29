using CalculadoraLib;
using Moq;
using NUnit.Framework;
using System;
namespace CalculadoraTests;

/// <summary>
/// Operaciones 3.3 de la práctica
/// Verificar las funcionalidad de las operaciones matematicas dentro de horario y fuenta de horario
/// Sumar, Restar, Dividir, Multiplicar
/// </summary>

[TestFixture]
public class CalculadoraServiceTests
{
    private Mock<IOperacionRepository> _repoMock;
    private Mock<ITimeProvider> _timeMock;
    private Calculadora _calc;
    private CalculadoraService _service;
    [SetUp]
    public void Setup()
    {
        _repoMock = new Mock<IOperacionRepository>();
        _timeMock = new Mock<ITimeProvider>();
        _calc = new Calculadora(_timeMock.Object);
        _service = new CalculadoraService(_calc, _repoMock.Object);
    }

    [Test]
    public void SumarYGuardar_DeberiaGuardarOperacionEnRepositorio()
    {
        // Arrange
        _timeMock.Setup(tp => tp.Now).Returns(new DateTime(2025, 1, 1, 10, 0, 0));
        _calc = new Calculadora(_timeMock.Object);
        _service = new CalculadoraService(_calc, _repoMock.Object);


        // Act
        var resultado = _service.SumarYGuardar(2, 3);

        // Assert
        Assert.AreEqual(5, resultado);

        // Verificamos que se haya llamado al método GuardarOperacion
        _repoMock.Verify(r => r.GuardarOperacion("2 + 3", 5), Times.Once);
    }

    [Test]
    public void SumarDentroDeHorario_DeberiaPermitirse()
    {

        // Arrange
        _timeMock.Setup(tp => tp.Now).Returns(new DateTime(2025, 1, 1, 10, 0, 0));
        _calc = new Calculadora(_timeMock.Object);

        // Act
        var resultado = _calc.Sumar(5, 4);
        var resultadoEsperado = 9;
        Assert.That(resultadoEsperado, Is.EqualTo(resultado));
    }


    [Test]
    public void SumarFueraDeHorario_NoDeberiaPermitirse()
    {

        // Arrange
        _timeMock.Setup(tp => tp.Now).Returns(new DateTime(2025, 1, 1, 7, 0, 0));
        _calc = new Calculadora(_timeMock.Object);

        // Act
        Assert.Throws<InvalidOperationException>(() => _calc.Sumar(5, 4));
    }

    [Test]
    public void RestarDentroDeHorario_DeberiaPermitirse()
    {
        // Arrange
        _timeMock.Setup(tp => tp.Now).Returns(new DateTime(2025, 1, 1, 08, 0, 0));
        _calc = new Calculadora(_timeMock.Object);
        // Act
        var resultado = _calc.Restar(5, 4);
        var resultadoEsperado = 1;
        Assert.That(resultadoEsperado, Is.EqualTo(resultado));
    }

    [Test]
    public void RestarFueraDeHorario_NoDeberiaPermitirse()
    {
        // Arrange
        _timeMock.Setup(tp => tp.Now).Returns(new DateTime(2025, 1, 1, 07, 0, 0));
        _calc = new Calculadora(_timeMock.Object);

        // Act
        Assert.Throws<InvalidOperationException>(() => _calc.Restar(10, 9));
    }
    [Test]
    public void MultiplicarDentroDeHorario_DeberiaPermitirse()
    {
        // Arrange
        _timeMock.Setup(tp => tp.Now).Returns(new DateTime(2025, 1, 1, 12, 0, 0));
        _calc = new Calculadora(_timeMock.Object);

        // Act
        var resultado = _calc.Multiplicar(10, 3);
        var resultadoEsperado = 30;
        Assert.That(resultadoEsperado, Is.EqualTo(resultado));
    }

    [Test]
    public void MultiplicarFueraDeHorario_NoDeberiaPermitirse()
    {
        // Arrange
        _timeMock.Setup(tp => tp.Now).Returns(new DateTime(2025, 1, 1, 20, 0, 0));
        _calc = new Calculadora(_timeMock.Object);

        // Act
        Assert.Throws<InvalidOperationException>(() => _calc.Multiplicar(10, 3));
    }

    [Test]
    public void DividirDentroDeHorario_DeberiaPermitirse()
    {
        // Arrange
        _timeMock.Setup(tp => tp.Now).Returns(new DateTime(2025, 1, 1, 17, 0, 0));
        _calc = new Calculadora(_timeMock.Object);

        // Act
        var resultado = _calc.Dividir(21, 3);
        var resultadoEsperado = 7;
        Assert.That(resultadoEsperado, Is.EqualTo(resultado));
    }

    [Test]
    public void DividirFueraDeHorario_NoDeberiaPermitirse()
    {
        // Arrange
        _timeMock.Setup(tp => tp.Now).Returns(new DateTime(2025, 1, 1, 20, 0, 0));
        _calc = new Calculadora(_timeMock.Object);
        // Act
        Assert.Throws<InvalidOperationException>(() => _calc.Dividir(15, 3));
    }

}
