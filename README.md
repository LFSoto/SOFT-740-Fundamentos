# Proyecto Final - Saucedemo

Este proyecto contiene un framework de pruebas en .NET con NUnit y Selenium para realizar pruebas funcionales sobre el sitio [Saucedemo](https://www.saucedemo.com/). y también pruebas unitarias para el proyecto Calculator.Lib

## Requisitos
- .NET 8 SDK
- Google Chrome (La versión más reciente)
- Los siguientes son instalados automáticamente por Nuget:
- DotNetSeleniumExtras.WaitHelpers
- Gherkin
- Reqnroll
- Reqnroll.NUnit
- Reqnroll.SpecFlowCompatibility
- Selenium.Support
- Selenium.WebDriver
- Selenium.WebDriver.ChromeDriver

## Instalación
- git clone https://github.com/LFSoto/SOFT-740-Fundamentos.git
- git checkout DixonChavarria-ProyectoFinal 
- cd DixonProyectoFinal.Tests
- dotnet restore
- dotnet build
- dotnet test

## Data Driven Testing
**Se implementó en la clase StepDefinitions/Login/LoginSteps.cs**

## Resumen
- La carpeta **/Pages** contiene la implementación de POM
- La carpeta **/StepDefinitions** contiene las pruebas funcionales
- La carpeta **/Tests/Features** contiene la defición de las pruebas usando BDD
- La carpeta **/UnitTests** contiene las pruebas unitarias
- La carpeta **/Utils** contiene las clases de Helpers y constantes