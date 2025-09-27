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
        timeMock.Setup(tp => tp.Now).Returns(new DateTime(2025,1,1,10,0,0));
        var calc = new Calculadora(timeMock.Object);
        var service = new CalculadoraService(calc, repoMock.Object);

        // Act
        var resultado = service.SumarYGuardar(2, 3);

        // Assert
        Assert.AreEqual(5, resultado);

        // Verificamos que se haya llamado al método GuardarOperacion
        repoMock.Verify(r => r.GuardarOperacion("2 + 3", 5), Times.Once);
    }

    [Test]
    public void Sumar_CasoValidoMoq()
    {
        // Arrange
        var timeMock = new Mock<ITimeProvider>();
        timeMock.Setup(tp => tp.Now).Returns(new DateTime(2025, 1, 1, 17, 0, 0));
        var calc = new Calculadora(timeMock.Object);

        var resultado = calc.Sumar(2, 3);
        var expected = 5;
        Assert.That(expected, Is.EqualTo(resultado));

    }

    [Test]
    public void Restar_CasoInvalidoMoq()
    {
        //Arrange
        var timeMock = new Mock<ITimeProvider>();
        timeMock.Setup(tp => tp.Now).Returns(new DateTime(2025, 1, 1, 7, 0, 0));
        var calc = new Calculadora(timeMock.Object);

        //Act
        Assert.Throws<InvalidOperationException>(() => calc.Restar(2,5));

    }

}
