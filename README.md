# Práctica 1 - Dixon Chavarría Vargas
**Resumen:** Se implementó la interfaz ItimeProvider, se realizó el uso de Moq para simular el uso de la interfaz en las pruebas unitarias de la clase CalculadoraUnitTests.cs

## Se agregaron los siguientes métodos:

- SumarDeberiaRetornarResultadoCorrecto()
- RestarDeberiaRetornarResultadoCorrecto()
- MultiplicarDeberiaRetornarResultadoCorrecto()
- DividirDeberiaRetornarResultadoCorrecto()
- DividirDeberiaRetornarError()
- SumarDeberiaRetornarErrorPorHorario()
- RestarDeberiaRetornarErrorPorHorario()
- MultiplicarDeberiaRetornarErrorPorHorario()
- DividirDeberiaRetornarErrorPorHorario()
- DividirDeberiaErrorPorHorario()

## Implmentación de la clase MOQ ejemplo:

```
Mock<ITimeProvider> _timeMockHoraHabil = new Mock<ITimeProvider>();
Mock<ITimeProvider> _timeMockHoraNoHabil = new Mock<ITimeProvider>();

[SetUp]
public void Setup()
{
    _timeMockHoraHabil.Setup(tp => tp.Now).Returns(new DateTime(2025, 9, 28, 9, 30, 00));
    _timeMockHoraNoHabil.Setup(tp => tp.Now).Returns(new DateTime(2025, 9, 27, 21, 30, 00));
}

[Test]
public void SumarDeberiaRetornarResultadoCorrecto()
{
    //Arrange
    Calculadora calc = new Calculadora(_timeMockHoraHabil.Object);

    int resultado = calc.Sumar(2, 3);

    Assert.That(resultado, Is.EqualTo(5));
}
```