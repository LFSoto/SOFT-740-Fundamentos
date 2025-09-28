using NUnit.Framework;
using Moq;
using CalculadoraLib;

namespace CalculadoraTests;

[TestFixture]
public class CalculadoraServiceTests
{
    [Test]
    public void SumarYGuardar_DeberiaGuardarOperacionEnRepositorio()
    {
        // Arrange
        var repoMock = new Mock<IOperacionRepository>();
        var timeMock = new Mock<ITimeProvider>();
        timeMock.Setup(tp => tp.Now).Returns(new DateTime(2025, 1, 1, 10, 0, 0));
        var calc = new Calculadora(timeMock.Object);
        var service = new CalculadoraService(calc, repoMock.Object);

        // Act
        var resultado = service.SumarYGuardar(2, 3);

        // Assert

        Assert.That(resultado, Is.EqualTo(5));

        // Verificamos que se haya llamado al método GuardarOperacion
        repoMock.Verify(r => r.GuardarOperacion("2 + 3", 5), Times.Once);
    }

    [Test]
    public void SumarDentroDeHorario_DeberiaPermitirse() 
    {
        // Arrange
        var timeMock = new Mock<ITimeProvider>();
        timeMock.Setup(tp => tp.Now).Returns(new DateTime(2025, 1, 1, 10, 0, 0));
        var calc = new Calculadora(timeMock.Object);

        // Act
        var resultado = calc.Sumar(5, 4);

        Assert.That(resultado, Is.EqualTo(9));
    }

    [Test]
    public void SumarFueraDeHorario_NoDeberiaPermitirse()
    {
        // Arrange
        var timeMock = new Mock<ITimeProvider>();
        timeMock.Setup(tp => tp.Now).Returns(new DateTime(2025, 1, 1, 7, 0, 0));
        var calc = new Calculadora(timeMock.Object);

        // Act
        Assert.Throws<InvalidOperationException>(() => calc.Sumar(5, 4));

    }
    [Test]
    public void RestarDentroDeHorario_DeberiaPermitirse()
    {
        // Arrange
        var timeMock = new Mock<ITimeProvider>();
        timeMock.Setup(tp => tp.Now).Returns(new DateTime(2025, 1, 1, 12, 0, 0));
        var calc = new Calculadora(timeMock.Object);

        // Act
        var resultado = calc.Restar(7, 4);

        Assert.That(resultado, Is.EqualTo(3));
    }

    [Test]
    public void RestarFueraDeHorario_NoDeberiaPermitirse()
    {
        // Arrange
        var timeMock = new Mock<ITimeProvider>();
        timeMock.Setup(tp => tp.Now).Returns(new DateTime(2025, 1, 1, 7, 0, 0));
        var calc = new Calculadora(timeMock.Object);

        // Act
        Assert.Throws<InvalidOperationException>(() => calc.Restar(7, 4));

    }
    [Test]
    public void MultiplicarDentroDeHorario_DeberiaPermitirse()
    {
        // Arrange
        var timeMock = new Mock<ITimeProvider>();
        timeMock.Setup(tp => tp.Now).Returns(new DateTime(2025, 1, 1, 13, 0, 0));
        var calc = new Calculadora(timeMock.Object);

        // Act
        var resultado = calc.Multiplicar(10, 3);

        Assert.That(resultado, Is.EqualTo(30));
    }

    [Test]
    public void MultiplicarFueraDeHorario_NoDeberiaPermitirse()
    {
        // Arrange
        var timeMock = new Mock<ITimeProvider>();
        timeMock.Setup(tp => tp.Now).Returns(new DateTime(2025, 1, 1, 3, 0, 0));
        var calc = new Calculadora(timeMock.Object);

        // Act
        Assert.Throws<InvalidOperationException>(() => calc.Multiplicar(10, 3));

    }
    [Test]
    public void DividirDentroDeHorario_DeberiaPermitirse()
    {
        // Arrange
        var timeMock = new Mock<ITimeProvider>();
        timeMock.Setup(tp => tp.Now).Returns(new DateTime(2025, 1, 1, 13, 0, 0));
        var calc = new Calculadora(timeMock.Object);

        // Act
        var resultado = calc.Dividir(10, 2);

        Assert.That(resultado, Is.EqualTo(5));
    }

    [Test]
    public void DividirFueraDeHorario_NoDeberiaPermitirse()
    {
        // Arrange
        var timeMock = new Mock<ITimeProvider>();
        timeMock.Setup(tp => tp.Now).Returns(new DateTime(2025, 1, 1, 20, 0, 0));
        var calc = new Calculadora(timeMock.Object);

        // Act
        Assert.Throws<InvalidOperationException>(() => calc.Dividir(10, 2));

    }
}
