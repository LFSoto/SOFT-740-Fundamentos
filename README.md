# Calculadora - Fundamentos de Pruebas en .NET

Este proyecto contiene la solución de la práctica1 **pruebas unitarias en .NET** usando **NUnit** y **Moq**.  
  

---

## Ajustes realizados

1. **Ajustes implementadas en clase Calculadora**
   ```bash
   Se ajustan los métodos:
   Restar
   Multiplicar
   Dividir
   En los que se agrega ValidarHoras();

2. **Pruebas implementadas en clase CalculadoraUnitTest**
	```bash
   Se agregan los métodos de prueba
   RestarDeberiaRetornarResultadoCorrecto()
   MultiplicarDeberiaRetornarResultadoCorrecto()
   Division_Normal_DeberiaRetornarResultadoCorrecto()
   Division_Entre_Cero_DeberiaRetornarResultadoCorrecto() 

3. **Ajustes implementadas en clase CalculadoraService**
	```bash
   Se agregan los métodos:
   RestarYGuardar
   MultiplicarYGuardar
   DividirYGuardar

4. **Pruebas implementadas en clase CalculadoraUnitTest**
	```bash
   Se agregan los métodos de prueba:
   RestarDentroDeHorario_DeberiaPermitirse()
   RestarFueraDeHorario_NoDeberiaPermitirse()
   MultiplicarDentroDeHorario_DeberiaPermitirse()
   MultiplicarFueraDeHorario_NoDeberiaPermitirse()
   DividirDentroDeHorario_DeberiaPermitirse()
   DividirFueraDeHorario_NoDeberiaPermitirse()

  ## Uso del Moq

1. Implementación del Moq:
	```bash
	Se hace uso del mismo Moq de Time Provider en los métodos de la clase CalculadoraServiceTest y CalculadoraUnitTest para validar si está o no fuera de horario y en el la clase Calculadora para el método ValidarHoras()
	



  ## Comandos útiles

1. Compilar:
	```bash
	dotnet build

2. Ejecutar pruebas:
	```bash
	dotnet test

3. Agregar nuevos paquetes (ejemplo: Moq):
	```bash
	dotnet add CalculadoraTests package Moq
