# Practica 5 - Melvin Marin Navarro

Este proyecto contiene un esqueleto en .NET con NUnit y Selenium para practicar pruebas funcionales sobre el sitio [Automation Testing Practice](https://testautomationpractice.blogspot.com/).

[![.NET 9 Selenium Tests](https://github.com/LFSoto/SOFT-740-Fundamentos/actions/workflows/dotnet-tests.yml/badge.svg?branch=Melvin-SeleniumGIT)](https://github.com/LFSoto/SOFT-740-Fundamentos/actions/workflows/dotnet-tests.yml)

## Requisitos
- .NET 8 SDK
- Google Chrome
- ChromeDriver (instalado automáticamente por NuGet)

## Instalación
```bash
git clone https://github.com/LFSoto/SOFT-740-Fundamentos.git
git checkout Melvin-SeleniumGIT
cd AutomationPracticeDemo.Tests
dotnet restore
dotnet build
dotnet test
```

## Pages
### Se implementaron esperas en las siguientes páginas:
---
* **AccountInformationPage**
* **ContactUsPage**
* **FooterPage**
* **FormPage**
* **HomePage**
* **LoginPage**
* **NavBarPage**
* **ProductsPage**
* **ShoppingCartPage**
