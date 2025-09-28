# Calculadora - Fundamentos de Pruebas en .NET (Práctica 1)

Este proyecto es el entregable de la **PRÁCTICA # 1** usando **NUnit** y **Moq**.  
Incluye una librería (`CalculadoraLib`) y un proyecto de pruebas (`CalculadoraTests`).  

---

# Alcance de las pruebas

Se realizaron pruebas posiitivas como negativas de las 4 operaciones básicas de las cálculadora, además de realizar pruebas de horario valido y guardado en la interfaz, a continuación se lista las pruebas ejecutadas

- CalculadoraUnitTest
	- Sumar_Retorna_Resultado_Correcto()
	- Restar_Retorna_Resultado_Correcto()
	- Multiplicar_Retorna_Resultado_Correcto()
	- Dividir_Retorna_Resultado_Correcto()
	- Dividir_Entre_Cero_Retorna_Error() 


- CalculadoraServiceTest
	- Sumar_Guarda_Operacion_En_Repositorio()
	- Restar_Guarda_Operacion_En_Repositorio()
	- Multiplicar_Guarda_Operacion_En_Repositorio()
	- Dividir_Guarda_Operacion_En_Repositorio()
	- Sumar_Dentro_Horario_Operacion_Permitida()
	- Sumar_Fuera_Horario_Operacion_Denegada()
	- Restar_Dentro_Horario_Operacion_Permitida()
	- Restar_Fuera_Horario_Operacion_Denegada()
	- Multiplicar_Dentro_Horario_Operacion_Permitida()
	- Multiplicar_Fuera_Horario_Operacion_Denegada()
	- Dividir_Dentro_Horario_Operacion_Permitida()
	- Dividir_Fuera_Horario_Operacion_Denegada()

---


## MOQ

En el proyecto se utilizó la librería Moq para la simulación de escenarios de respuesta.
Para esto se utilizó la interfaz IOperacionRepository, que se utiliza para simular el guardado de los registros procesados y la interfaz ITimeProvider que se utilizó para simular la fecha y hora hábiles para realizar las operaciones.

---

## Requisitos

- [Visual Studio 2022](https://visualstudio.microsoft.com/es/)
- [.NET 6 SDK o superior](https://dotnet.microsoft.com/en-us/download/dotnet)  
- Git instalado en el sistema  

---

## Pasos para empezar

1. **Clonar el repositorio**
   ```bash
   git clone https://github.com/LFSoto/SOFT-740-Fundamentos.git
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
