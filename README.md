#Práctica 5 de Automatización con Selenium

Sitio bajo prueba: https://automationexercise.com

Este proyecto forma parte de las prácticas de automatización de pruebas funcionales desarrolladas en C# con Selenium WebDriver, NUnit y el patrón Page Factory.
El objetivo es reforzar el uso de buenas prácticas en el diseño de frameworks, aplicando el manejo de elementos dinámicos, así como versionamiento en Git con una estructura de repositorio organizada.

Las pruebas validan flujos críticos del sitio bajo prueba, utilizando Data-Driven Testing (DDT) con archivos JSON para la parametrización de datos.
Cada caso está documentado y genera capturas de pantalla durante su ejecución para facilitar el análisis de resultados.

##Requisitos previos

Antes de clonar y ejecutar el proyecto, asegúrate de tener instalado:

Visual Studio 2022
 o superior
(con la carga de trabajo “Desarrollo de .NET Desktop” o “Desarrollo web con ASP.NET”)

.NET 8 SDK o superior

Google Chrome

ChromeDriver
 compatible con la versión instalada de Chrome
(recomendado usar WebDriverManager para administrarlo automáticamente)

Acceso a una cuenta de GitHub
 para clonar y versionar el proyecto.

##Clonar el repositorio

Abre una terminal o Git Bash y ejecuta:

git clone https://github.com/YeisonRojas-SeleniumGIT.git
cd YeisonRojas-SeleniumGIT

##Instalación de dependencias

El proyecto utiliza Selenium WebDriver, NUnit y Selenium Extras PageFactory.
Ejecuta el siguiente comando para restaurar las dependencias:

dotnet restore


O, si usas Visual Studio, solo abre el proyecto y las dependencias se restaurarán automáticamente.

##Ejecución de pruebas

Puedes ejecutar las pruebas de dos formas:

###Desde Visual Studio

Abre la solución .sln

Ve al menú Test → Run All Tests o presiona Ctrl + R, A

##Desde la línea de comandos (.NET CLI)

Ejecuta el siguiente comando desde la raíz del proyecto:

dotnet test


Este comando compilará el proyecto, ejecutará los tests definidos en las clases de prueba y mostrará los resultados en consola.
Durante la ejecución, se generan capturas automáticas dentro de la carpeta /Imagen/ para verificar el estado visual del sitio en el momento de validación.

##Escenarios de prueba incluidos
###a_RegistroUsuarioNuevo

Valida el flujo de registro de un nuevo usuario, con datos obtenidos desde un archivo JSON.
Verifica el título del formulario, el mensaje “Account Created!” y el inicio de sesión posterior al registro.

###b_LoginUsuarioExistente

Prueba el inicio de sesión exitoso de un usuario registrado, comprobando el texto esperado en el home y el mensaje “Logged in as [usuario]”.

###c_LoginUsuarioNoExistente

Evalúa el inicio de sesión fallido con credenciales incorrectas y valida el mensaje de error correspondiente.

###d_AgregarProductosCarritoyVerificarTotal

Simula una compra completa en línea, manejando elementos dinámicos mediante Page Factory y esperas explícitas:

Adición de productos al carrito.

Validación de totales calculados vs. esperados.

Llenado de formulario de pago.

Confirmación final del pedido con el mensaje “Your order has been placed successfully!”.

###e_ContactUsForm

Automatiza el formulario “Contact Us”, incluyendo la carga de archivos, manejo de alertas y verificación del mensaje de éxito.

###f_SuscripcionNewsLetter

Valida la suscripción al boletín informativo (Newsletter) mostrando el mensaje de confirmación esperado tras el registro del correo.

##Autor

Yeison Rojas S.
Proyecto de práctica 5 – Selenium en C#
Desarrollado con fines educativos para fortalecer las habilidades en Page Object Model, Page Factory, manejo de elementos dinámicos y buenas prácticas de versionamiento con Git.