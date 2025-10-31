#Práctica 6 de Automatización con Selenium

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

##Escribir casos de prueba en Gherkin
###a_RegistroUsuarioNuevo

Crear el Gherkin para el escenario a_RegistroUsuarioNuevo

###b_LoginUsuarioExistente

Crear el Gherkin para el escenario b_LoginUsuarioExistente

###c_LoginUsuarioNoExistente

Crear el Gherkin para el escenario c_LoginUsuarioNoExistente

###d_AgregarProductosCarritoyVerificarTotal

Crear el Gherkin para el escenario d_AgregarProductosCarritoyVerificarTotal

###e_ContactUsForm

Crear el Gherkin para el escenario e_ContactUsForm

###f_SuscripcionNewsLetter

Crear el Gherkin para el escenario f_SuscripcionNewsLetter

##Autor

Yeison Rojas S.
Proyecto de práctica 6 – Selenium en C#
Desarrollado con fines educativos para fortalecer las habilidades en Page Object Model, Page Factory, manejo de elementos dinámicos y buenas prácticas de versionamiento con Git.

