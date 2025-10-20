# Proyecto de Pruebas Automatizadas - Automation Practice Demo

Este proyecto contiene un esqueleto en .NET con NUnit y Selenium para practicar pruebas funcionales sobre el sitio [Automation Testing Practice](https://testautomationpractice.blogspot.com/).

## Requisitos
- .NET 8 SDK
- Google Chrome (La versión más reciente)
- ChromeDriver (instalado automáticamente por NuGet)

## Instalación
git clone https://github.com/LFSoto/SOFT-740-Fundamentos.git
git checkout DixonChavarria-SeleniumPOM-DDT 
cd AutomationPracticeDemo.Tests
dotnet restore
dotnet build
dotnet test

# Práctica 4 Dixon Chavarria

## Se agregaron las siguientes Pruebas (Carpeta Tests/Practica4)

- Should_RegisterNewUser()
- Should_LoginExistingUser()
- Should_AddItemsToCartAndVerifyTotal()
- Should_SendContactForm()
- Should_SubscribeToNewsletter()

## Data Driven Testing
** Se implementó en la clase Tests/Practica4/Login/LoginTest **