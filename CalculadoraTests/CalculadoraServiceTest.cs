using NUnit.Framework;
using Moq;
using CalculadoraLib;

namespace CalculadoraTests;

[TestFixture]
public class CalculadoraServiceTests
{
    [Test]
    public void SumarDentroDeHorario_DeberiaPermitirse()
    {
        // Arrange
        var timeMock = new Mock<ITimeProvider>();
        timeMock.Setup(tp => tp.Now).Returns(new DateTime(2025, 1, 1, 10, 0, 0));
        var calc = new Calculadora(timeMock.Object);

        // Act
        int resultado = calc.Sumar(5, 4);

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
}
