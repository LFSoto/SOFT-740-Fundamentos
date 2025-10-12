## Proyecto de Automatización - AutomationPracticeDemo

Este proyecto contiene la práctica de automatización de flujos completos de usuario utilizando **Selenium WebDriver** en **C#**, sin aplicar aún el patrón **Page Object Model (POM)**.  
Incluye pruebas automatizadas que cubren distintos tipos de interacciones: formularios, botones, listas, validaciones y archivos adjuntos.

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

1. **Registro de usuario nuevo**  
   Valida el flujo completo de registro y mensaje “Account Created!”.

2. **Login con usuario existente**  
   Verifica el inicio de sesión correcto mostrando “Logged in as [usuario]”.

3. **Agregar productos al carrito y verificar total**  
   Confirma la correcta adición de productos y el total mostrado.

4. **Formulario Contact Us**  
   Comprueba el envío exitoso del formulario y el mensaje de confirmación.

5. **Suscripción al newsletter**  
   Valida la suscripción correcta al boletín.

---
