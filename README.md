# Practica 1 - Melvin Marin Navarro

Se agrega la **Parte 2** y **Parte 3** faltante.   

## Test
### Se agregaron los siguientes:
---
* **CalculadoraUnitTests**
    * Division_DeberiaRetornarResultadoCorrecto
	* Multiplicar_DeberiaRetornarResultadoCorrecto
	
* **CalculadoraServiceTests**
	* RestarDentroDeHorario_DeberiaPermitirse
	* RestarFueraDeHorario_NoDeberiaPermitirse
	* MultiplicarDentroDeHorario_DeberiaPermitirse
	* MultiplicarFueraDeHorario_NoDeberiaPermitirse
	* DividirDentroDeHorario_DeberiaPermitirse
	* DividirFueraDeHorario_NoDeberiaPermitirse(

### Implementacion
```
var timeMock = new Mock<ITimeProvider>();
timeMock.Setup(tp => tp.Now).Returns(new DateTime(2025, 1, 1, 10, 0, 0));
var calc = new Calculadora(timeMock.Object);
```
> A traves de la clase Mock y mediante la interface ITimeProvider se simula 
una fecha y hora sobre la cual se realizan operaciones. 
>
