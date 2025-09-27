# Reporte de Pruebas Unitarias con Moq y NUnit

## Pruebas Implementadas

Se desarrollaron pruebas unitarias para la clase `Calculadora`, utilizando el framework **NUnit** y la librería **Moq** para simular dependencias de tiempo (`ITimeProvider`). El objetivo fue validar que las operaciones matemáticas respondan correctamente según las restricciones de horario o manejo de errores.

---

### Pruebas usando Moq

#### `Sumar_CasoValidoMoq`
- **Descripción:** Verifica que `Sumar(2, 3)` funcione correctamente cuando se realiza a las 17:00.
- **Resultado esperado:** `5`
- **Moq usado para:** Simular `DateTime.Now` a las 17:00.

#### `Restar_CasoInvalidoMoq`
- **Descripción:** Verifica que `Restar(2, 5)` lanza una excepción si se ejecuta a las 07:00.
- **Resultado esperado:** `InvalidOperationException`
- **Moq usado para:** Simular horario no permitido (07:00).

#### `Sumar_DeberiaRetornarResultadoCorrecto`
- **Descripción:** Valida el resultado de `Sumar(2, 3)` a las 11:00.
- **Resultado esperado:** `5`
- **Moq usado para:** Simular horario válido (11:00).

#### `Restar_DeberiaRetornarResultadoCorrecto`
- **Descripción:** Valida el resultado de `Restar(2, 1)` a las 11:00.
- **Resultado esperado:** `1`
- **Moq usado para:** Simular horario válido (11:00).

---

### Pruebas sin Moq (métodos sin restricciones horarias)

#### `Multiplicar_DeberiaRetornarResultadoCorrecto`
- **Descripción:** Verifica que `Multiplicar(2, 3)` devuelve `6`.
- **Moq:** No requerido.

#### `Dividir_DeberiaRetornarResultadoCorrecto`
- **Descripción:** Verifica que `Dividir(6, 2)` devuelve `3`.
- **Moq:** No requerido.

#### `ManejoError_Dividir_DeberiaRetornarResultadoCorrecto`
- **Descripción:** Verifica que `Dividir(10, 0)` lanza `DivideByZeroException`.
- **Moq:** No requerido.

---

## Uso de Moq

Se utilizó **Moq** para simular la interfaz `ITimeProvider`, permitiendo configurar el valor de `Now` y controlar los horarios en los que se realizan ciertas operaciones. Esto permitió probar fácilmente los casos en los que:

- Las operaciones solo están permitidas en ciertos horarios.
- Se debe lanzar una excepción fuera del horario válido.

### Ejemplo de configuración con Moq:

```csharp
var timeMock = new Mock<ITimeProvider>();
timeMock.Setup(tp => tp.Now).Returns(new DateTime(2025, 1, 1, 11, 0, 0));
var calc = new Calculadora(timeMock.Object);
