# Práctica 3 de Pruebas Automatizadas - Automation Practice Demo

Este proyecto contiene un esqueleto en .NET con NUnit y Selenium para practicar pruebas funcionales sobre el sitio https://automationexercise.com/

## Requisitos
- .NET 8 SDK
- Google Chrome
- ChromeDriver (instalado automáticamente por NuGet)

## Instalación
```bash
git clone https://github.com/LFSoto/SOFT-740-Fundamentos.git
git checkout AlejandraFonseca-SeleniumT2 
cd AutomationPracticeDemo.Tests
dotnet restore
dotnet build
dotnet test

## Ajsutes realizados
- Se agrega la clase AutomationPractice
- Se crean los Test:
-	signUpTest()
-	loginTest()
-	addProductsTest()
-	contactUsTest()
-	newsLetterSubscriptionTest()
-	EmptyCart() El cual es un test adicional utilizado en el addProductsTest para limpiar el carrito antes de iniciar
- Se agrega en el proyecto la imagen QA.jpeg utilizada en el contactUsTest
