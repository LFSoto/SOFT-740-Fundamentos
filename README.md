# Práctica 4 de Automatización con Selenium  
**Sitio bajo prueba:** [https://automationexercise.com](https://automationexercise.com)

Este proyecto forma parte de las prácticas de automatización de pruebas funcionales desarrolladas en **C#** con **Selenium WebDriver** y **NUnit**.  
El objetivo es validar distintos flujos críticos del sitio bajo prueba, aplicando **técnicas de Data-Driven Testing (DDT)** mediante el uso de archivos **JSON** que contienen los datos de entrada.  

Las pruebas automatizan escenarios completos de interacción de usuario, como registro, inicio de sesión, suscripción, envío de formularios y compras en línea.  
Cada caso está documentado y genera capturas de pantalla durante su ejecución para facilitar el análisis de resultados.

---

## Requisitos previos

Antes de clonar y ejecutar el proyecto, asegúrate de tener instalado:

- [Visual Studio 2022](https://visualstudio.microsoft.com/es/vs/) o superior  
  _(con la carga de trabajo “Desarrollo de .NET Desktop” o “Desarrollo de ASP.NET y web” instalada)_
- [.NET 8 SDK o superior](https://dotnet.microsoft.com/en-us/download)
- [Google Chrome](https://www.google.com/chrome/)
- [ChromeDriver](https://chromedriver.chromium.org/downloads) compatible con la versión instalada de Chrome  
  _(recomendado usar `WebDriverManager` para manejarlo automáticamente)_

---

## Clonar el repositorio

Abre una terminal o Git Bash y ejecuta:

```bash
git clone https://github.com/tu-usuario/selenium-practica.git
cd selenium-practica
```

---

## Instalación de dependencias

El proyecto utiliza **Selenium WebDriver** y **NUnit** como framework de pruebas.  
Ejecuta el siguiente comando para restaurar las dependencias:

```bash
dotnet restore
```

O, si usas Visual Studio, solo abre el proyecto y las dependencias se restaurarán automáticamente.

---

## Ejecución de pruebas

Puedes ejecutar las pruebas de dos formas:

### Desde Visual Studio
1. Abre la solución `.sln`
2. Ve al menú **Test → Run All Tests** o presiona `Ctrl + R, A`

### Desde la línea de comandos (.NET CLI)
Ejecuta el siguiente comando desde la raíz del proyecto:

```bash
dotnet test
```

Este comando compilará el proyecto, ejecutará todos los tests definidos en las clases de prueba y mostrará los resultados en consola.  
Cada prueba genera capturas automáticas dentro de la carpeta `/Imagen/` para ver el estado visual del sitio en el momento de la validación.

---

## Escenarios de prueba incluidos

### 1️**a_RegistroUsuarioNuevo**
Valida el **flujo de registro de un nuevo usuario**.  
Se genera un correo aleatorio, se completan todos los campos del formulario y se verifica:
- Título del formulario.
- Mensaje de confirmación “Account Created!”.
- Inicio de sesión automático posterior al registro.

### 2️**b_LoginUsuarioExistente**
Prueba el **inicio de sesión exitoso** con un usuario ya registrado.  
Comprueba que el sistema muestre:
- El texto esperado en el home.  
- El mensaje “Logged in as [usuario]”.

### 3️**c_LoginUsuarioNoExistente**
Evalúa el **inicio de sesión fallido** con credenciales incorrectas.  
Verifica que se muestre el mensaje de error apropiado y que el usuario no acceda a la cuenta.

### 4️**d_AgregarProductosCarritoyVerificarTotal**
Simula una **compra en línea completa**, incluyendo:
- Adición de dos productos al carrito.
- Validación de los totales calculados vs. esperados.
- Llenado de formulario de pago.
- Confirmación final del pedido con el mensaje “Your order has been placed successfully!”.

### 5️**e_ContactUsForm**
Automatiza el **formulario “Contact Us”**, verificando:
- Que se pueda adjuntar un archivo.
- Que el sistema muestre la alerta y mensaje de éxito correctos tras el envío.

### 6️**f_SuscripcionNewsLetter**
Valida la **suscripción al boletín informativo (Newsletter)**.  
Confirma que se muestre el mensaje de éxito esperado tras el registro del correo.


## Autor

**Yeison Rojas S.**  
Proyecto de práctica de automatización – Selenium en C#  
Desarrollado con fines educativos para fortalecer las habilidades en **testing automatizado** y **estructuración de frameworks de prueba**.
