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
        //Se crean los objetos Mock para las interfaces.

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
        repoMock.Verify(r => r.GuardarOperacion("2 + 3", 5), Times.Once);//que se llame solo 1 vez.

    }

    [Test]
    public void SumarDentroDeHorario_DeberiaPermitirse() 
    {
        // Arrange
        //Se crean los objetos Mock para las interfaces.
        var timeMock = new Mock<ITimeProvider>();
        //Se configura el mock usando Setup.
        timeMock.Setup(tp => tp.Now).Returns(new DateTime(2025, 1, 1, 10, 0, 0));
        //Usamos el objeto mock en nuestra prueba.
        var calc = new Calculadora(timeMock.Object);

        // Act
        var resultado = calc.Sumar(5, 4);
        //Afirmamos que el resultado es el esperado.
        Assert.That(resultado, Is.EqualTo(9));//9am
    }

    [Test]
    public void SumarFueraDeHorario_NoDeberiaPermitirse()
    {
        // Arrange
        var timeMock = new Mock<ITimeProvider>();
        timeMock.Setup(tp => tp.Now).Returns(new DateTime(2025, 1, 1, 7, 0, 0));
        var calc = new Calculadora(timeMock.Object);

        // Act
        Assert.Throws<InvalidOperationException>(() => calc.Sumar(5, 1));//7am

    }

    [Test]
    public void RestarDentroDeHorario_DeberiaPermitirse()
    {
        // Arrange
        //Se crean los objetos Mock para las interfaces.
        var timeMock = new Mock<ITimeProvider>();
        //Se configura el mock usando Setup.
        timeMock.Setup(tp => tp.Now).Returns(new DateTime(2025, 1, 1, 10, 0, 0));
        //Usamos el objeto mock en nuestra prueba.
        var calc = new Calculadora(timeMock.Object);

        // Act
        var resultado = calc.Restar(18, 8);
        //Afirmamos que el resultado es el esperado.
        Assert.That(resultado, Is.EqualTo(10));//10am -> el esperado debe ser 10
    }
    [Test]
    public void RestarFueraDeHorario_NoDeberiaPermitirse()
    {
        // Arrange
        var timeMock = new Mock<ITimeProvider>();
        timeMock.Setup(tp => tp.Now).Returns(new DateTime(2025, 1, 1, 7, 0, 0));
        var calc = new Calculadora(timeMock.Object);

        // Act
        Assert.Throws<InvalidOperationException>(() => calc.Restar(10, 4)); //6am

    }
    [Test]
    public void MultiplicarDentroDeHorario_DeberiaPermitirse()
    {
        // Arrange
        //Se crean los objetos Mock para las interfaces.
        var timeMock = new Mock<ITimeProvider>();
        //Se configura el mock usando Setup.
        timeMock.Setup(tp => tp.Now).Returns(new DateTime(2025, 1, 1, 10, 0, 0));
        //Usamos el objeto mock en nuestra prueba.
        var calc = new Calculadora(timeMock.Object);

        // Act
        var resultado = calc.Multiplicar(2, 5);
        //Afirmamos que el resultado es el esperado.
        Assert.That(resultado, Is.EqualTo(10)); //10 am
    }
    [Test]
    public void MultiplicarFueraDeHorario_NoDeberiaPermitirse()
    {
        // Arrange
        var timeMock = new Mock<ITimeProvider>();
        timeMock.Setup(tp => tp.Now).Returns(new DateTime(2025, 1, 1, 7, 0, 0));
        var calc = new Calculadora(timeMock.Object);

        // Act
        Assert.Throws<InvalidOperationException>(() => calc.Multiplicar(4, 5));//20hrs

    }
}
