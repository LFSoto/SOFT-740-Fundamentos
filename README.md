# Practica 1 Tamara Salazar - Fundamentos de Pruebas en .NET

## Se realiza lo siguientes:

**CalculadoraUnitTests**
```
```Sumar_DeberiaRetornarResultadoCorrecto
```Sumar_DeberiaRetornarResultadoInorrecto
```RestarDeberiaRetornarResultadoCorrecto
```RestarDeberiaRetornarResultadoInorrecto
MultiplicarDeberiaRetornarResultadoCorrecto
MultiplicarDeberiaRetornarResultadoIncorrectoDivisionDeberiaRetornarResultadoCorrecto
Division_Entre_Cero_DeberiaRetornarResultadoIncorrecto
Division_DeberiaRetornarResultadoIncorrectoHORA
```

**CalculadoraServiceTest.cs**

```SumarDentroDeHorario_DeberiaPermitirse
```SumarFueraDeHorario_NoDeberiaPermitirse()
```RestarDentroDeHorario_DeberiaPermitirse
```RestarFueraDeHorario_NoDeberiaPermitirse
```MultiplicarDentroDeHorario_DeberiaPermitirse
```MultiplicarFueraDeHorario_NoDeberiaPermitirse
```DividirDentroDeHorario_DeberiaPermitirse
```DividirFueraDeHorario_NoDeberiaPermitirse

**Calculadora.cs**
Se agrego ValidarHoras() en todas las operaciones

## Pasos para empezar

1. **Clonar el repositorio**
   ```bash
   git clone https://github.com/LFSoto/SOFT-740-Fundamentos/tree/TamaraSalazar
   cd SOFT-740-Fundamentos

2. **Restaurar dependencias**
	```bash
   dotnet restore

3. **Compilar la solución**
	```bash
   dotnet build

4. **Ejecutar las pruebas unitarias**
	```bash
   dotnet test

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
