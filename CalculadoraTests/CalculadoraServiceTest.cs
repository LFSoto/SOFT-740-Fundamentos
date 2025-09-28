using NUnit.Framework;
using Moq;
using CalculadoraLib;

namespace CalculadoraTests;

[TestFixture]
public class CalculadoraServiceTests
{
    [Test]
    public void Sumar_Guarda_Operacion_En_Repositorio()
    {
        // Arrange
        var repoMock = new Mock<IOperacionRepository>();
        var timeMock = new Mock<ITimeProvider>();
        timeMock.Setup(tp => tp.Now).Returns(new DateTime(2025, 1, 1, 17, 0, 0));
        var calc = new Calculadora(timeMock.Object);
        var service = new CalculadoraService(calc, repoMock.Object);

        // Act
        var resultado = service.SumarYGuardar(2, 3);

        // Assert test
        Assert.That(resultado, Is.EqualTo(5));

        // Verificamos que se haya llamado al método GuardarOperacion
        repoMock.Verify(r => r.GuardarOperacion("2 + 3", 5), Times.Once);
    }

    [Test]
    public void Restar_Guarda_Operacion_En_Repositorio()
    {
        // Arrange
        var repoMock = new Mock<IOperacionRepository>();
        var timeMock = new Mock<ITimeProvider>();
        timeMock.Setup(tp => tp.Now).Returns(new DateTime(2025, 1, 1, 17, 0, 0));
        var calc = new Calculadora(timeMock.Object);
        var service = new CalculadoraService(calc, repoMock.Object);

        // Act
        var resultado = service.RestarYGuardar(10, 6);

        // Assert test
        Assert.That(resultado, Is.EqualTo(4));

        // Verificamos que se haya llamado al método GuardarOperacion
        repoMock.Verify(r => r.GuardarOperacion("10 - 6", 4), Times.Once);
    }

    [Test]
    public void Multiplicar_Guarda_Operacion_En_Repositorio()
    {
        // Arrange
        var repoMock = new Mock<IOperacionRepository>();
        var timeMock = new Mock<ITimeProvider>();
        timeMock.Setup(tp => tp.Now).Returns(new DateTime(2025, 1, 1, 17, 0, 0));
        var calc = new Calculadora(timeMock.Object);
        var service = new CalculadoraService(calc, repoMock.Object);

        // Act
        var resultado = service.MultiplicarYGuardar(5, 2);

        // Assert test
        Assert.That(resultado, Is.EqualTo(10));

        // Verificamos que se haya llamado al método GuardarOperacion
        repoMock.Verify(r => r.GuardarOperacion("5 * 2", 10), Times.Once);
    }

    [Test]
    public void Dividir_Guarda_Operacion_En_Repositorio()
    {
        // Arrange
        var repoMock = new Mock<IOperacionRepository>();
        var timeMock = new Mock<ITimeProvider>();
        timeMock.Setup(tp => tp.Now).Returns(new DateTime(2025, 1, 1, 17, 0, 0));
        var calc = new Calculadora(timeMock.Object);
        var service = new CalculadoraService(calc, repoMock.Object);

        // Act
        var resultado = service.DividirYGuardar(15, 3);

        // Assert test
        Assert.That(resultado, Is.EqualTo(5));

        // Verificamos que se haya llamado al método GuardarOperacion
        repoMock.Verify(r => r.GuardarOperacion("15 / 3", 5), Times.Once);
    }

    [Test]
    public void Sumar_Dentro_Horario_Operacion_Permitida()
    {
        // Arrange
        var timeMock = new Mock<ITimeProvider>();
        timeMock.Setup(tp => tp.Now).Returns(new DateTime(2025, 1, 1, 17, 0, 0));
        var calc = new Calculadora(timeMock.Object);

        // Act
        var resultado = calc.Sumar(2, 3);
    }

    [Test]
    public void Sumar_Fuera_Horario_Operacion_Denegada()
    {
        // Arrange
        var timeMock = new Mock<ITimeProvider>();
        timeMock.Setup(tp => tp.Now).Returns(new DateTime(2025, 1, 1, 7, 0, 0));
        var calc = new Calculadora(timeMock.Object);

        // Act
        Assert.Throws<InvalidOperationException>(() => calc.Sumar(2, 3));
    }

    [Test]
    public void Restar_Dentro_Horario_Operacion_Permitida()
    {
        // Arrange
        var timeMock = new Mock<ITimeProvider>();
        timeMock.Setup(tp => tp.Now).Returns(new DateTime(2025, 1, 1, 17, 0, 0));
        var calc = new Calculadora(timeMock.Object);

        // Act
        var resultado = calc.Restar(10, 6);
    }

    [Test]
    public void Restar_Fuera_Horario_Operacion_Denegada()
    {
        // Arrange
        var timeMock = new Mock<ITimeProvider>();
        timeMock.Setup(tp => tp.Now).Returns(new DateTime(2025, 1, 1, 7, 0, 0));
        var calc = new Calculadora(timeMock.Object);

        // Act
        Assert.Throws<InvalidOperationException>(() => calc.Restar(10, 6));
    }

    [Test]
    public void Multiplicar_Dentro_Horario_Operacion_Permitida()
    {
        // Arrange
        var timeMock = new Mock<ITimeProvider>();
        timeMock.Setup(tp => tp.Now).Returns(new DateTime(2025, 1, 1, 17, 0, 0));
        var calc = new Calculadora(timeMock.Object);

        // Act
        var resultado = calc.Multiplicar(5, 2);
    }

    [Test]
    public void Multiplicar_Fuera_Horario_Operacion_Denegada()
    {
        // Arrange
        var timeMock = new Mock<ITimeProvider>();
        timeMock.Setup(tp => tp.Now).Returns(new DateTime(2025, 1, 1, 19, 0, 0));
        var calc = new Calculadora(timeMock.Object);

        // Act
        Assert.Throws<InvalidOperationException>(() => calc.Restar(5, 2));
    }

    [Test]
    public void Dividir_Dentro_Horario_Operacion_Permitida()
    {
        // Arrange
        var timeMock = new Mock<ITimeProvider>();
        timeMock.Setup(tp => tp.Now).Returns(new DateTime(2025, 1, 1, 17, 0, 0));
        var calc = new Calculadora(timeMock.Object);

        // Act
        var resultado = calc.Dividir(15, 3);
    }

    [Test]
    public void Dividir_Fuera_Horario_Operacion_Denegada()
    {
        // Arrange
        var timeMock = new Mock<ITimeProvider>();
        timeMock.Setup(tp => tp.Now).Returns(new DateTime(2025, 1, 1, 7, 0, 0));
        var calc = new Calculadora(timeMock.Object);

        // Act
        Assert.Throws<InvalidOperationException>(() => calc.Sumar(15, 3));
    }
}
