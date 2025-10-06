##Proyecto de Automatización - AutomationPracticeDemo

Este proyecto contiene un conjunto de pruebas automatizadas desarrolladas en **C#**, utilizando **Selenium WebDriver**, **NUnit** y el patrón **Page Object Model (POM)**.  
El objetivo principal es validar la interacción con diferentes elementos de un formulario web (text boxes, radio buttons, dropdowns, alertas, datepicker y botones).

---

## Requisitos Previos

Antes de clonar y ejecutar el proyecto, asegúrate de tener instalado lo siguiente:

- [✅ .NET SDK 6.0 o superior](https://dotnet.microsoft.com/download)
- [✅ Google Chrome](https://www.google.com/chrome/)
- [✅ Visual Studio 2022](https://visualstudio.microsoft.com/) con la carga de trabajo de **.NET Desktop Development**
- [✅ Git](https://git-scm.com/) para clonar el repositorio

---

## Clonar el Repositorio

Ejecuta el siguiente comando en tu terminal o consola:

```bash
git clone https://github.com/LFSoto/SOFT-740-Fundamentos.git
```

> Reemplaza `C:\Curso-Automatizacion-Repositorio\Semana2\SOFT-740-Fundamentos` con la URL real de tu repositorio.

---

## Ingresar al Proyecto

```bash
cd AutomationPracticeDemo
```

---

## Restaurar Dependencias

El proyecto utiliza paquetes NuGet para Selenium, NUnit y WebDriverManager.  
Para instalarlos automáticamente, ejecuta:

```bash
dotnet restore
```

O bien desde Visual Studio:

1. Ve a **Herramientas → Administrador de paquetes NuGet → Administrar paquetes NuGet para la solución**  
2. Haz clic en **Restaurar**.

---

## Ejecutar las Pruebas

Puedes ejecutar las pruebas de dos formas:

### Opción 1: Desde la Terminal (recomendado)

```bash
dotnet test
```

Esto compilará el proyecto y ejecutará todas las pruebas definidas en la solución.

---

### Opción 2: Desde Visual Studio

1. Abre la solución `AutomationPracticeDemo.sln`.
2. Ve al menú **Test → Test Explorer**.
3. Haz clic en **Run All Tests**.

---

## Caso de Prueba Incluido

El archivo [`FromTestPractica2.cs`](./Tests/Tests/FromTestPractica2.cs) contiene un caso de prueba que realiza las siguientes acciones:

- Completar campos de texto (Nombre, Correo, Teléfono, Dirección)
- Seleccionar radio buttons y checkboxes
- Seleccionar valores de dropdown
- Interactuar con un datepicker
- Validar alertas
- Ejecutar doble clic en un botón y validar resultado
- Realizar aserciones para validar los datos ingresados y las acciones ejecutadas

---
