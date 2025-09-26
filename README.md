# Practica de Pruebas Unitarias para Calculadora

Esta practica amplica la cobertura de pruebas unitarias de una calculadora básica en C#, utilizando **NUnit** para la validación de lógica y **Moq** para simular datos de prueba, en el caso de la practica simulamos la hora en la que se realiza la prueba haciendo uso de la interfaz ITimeProvider con una propiedad Now de tipo DateTime.

## Pruebas Implementadas
### Parte 2: Operaciones Básicas y Manejo de Errores
Se desarrollaron pruebas unitarias para los siguientes escenarios:

- **Suma**: Verifica que la suma de dos números retorna el resultado correcto.
- **Resta**: Verifica que la resta de dos números retorna el resultado correcto.
- **Multiplicación**: Verifica que la multiplicación de dos números retorna el resultado correcto.
- **División**: Verifica que la división de dos números retorna el resultado correcto.
- **División por cero**: Se espera que al efectuar una operación que realice la divición entre cero el error sea controlado mediante unauna excepción `DivideByZeroException`.

### Parte 3: Validación de Horario con ITimeProvider
Se creó la interfaz `ITimeProvider` con la propiedad `DateTime Now { get; }`. La clase `Calculadora` fue modificada para recibir esta dependencia por constructor, permitiendo controlar el tiempo en pruebas.

#### Pruebas con Moq
Se utilizaron mocks para simular diferentes horarios:

- **Caso válido**: Se simula una hora dentro del rango permitido (ej. 10:00 AM). La operación se ejecuta correctamente ya que se encuentra entre el horario de 8:00 AM a 6:00 PM.
- **Caso inválido**: Se simula una hora fuera del rango (ej. 8:00 AM a 6:00 PM). Se espera una excepción `InvalidOperationException`.

## Herramientas Utilizadas
- **NUnit**: Framework de pruebas unitarias.
- **Moq**: Biblioteca para crear objetos simulados (mocks) y aislar dependencias como `ITimeProvider`.

## Notas
- Todas las pruebas se ejecutan de forma independiente y correctamente según la revisión manual realizada.
- Se cubren tanto escenarios positivos como negativos.
- El uso de Moq nos permitio en la practica validar comportamientos que dependian del tiempo sin necesidad de modificar el sistema, especificamente la hora del sistema.

# Se mantiene la información del readme para guiarme en el futuro.
# Calculadora - Fundamentos de Pruebas en .NET

Este proyecto es una base para practicar **pruebas unitarias en .NET** usando **NUnit** y **Moq**.  
Incluye una librería (`CalculadoraLib`) y un proyecto de pruebas (`CalculadoraTests`).  

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
