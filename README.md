# Práctica 2 de Pruebas Automatizadas - Automation Practice Demo

Este proyecto contiene un esqueleto en .NET con NUnit y Selenium para practicar pruebas funcionales sobre el sitio [Automation Testing Practice](https://testautomationpractice.blogspot.com/).

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
- Test Should_FillAndSubmitForm2()
- Test Upload()
- Métodos y constructores necesarios para el funcionamiento de los test mencionados
- Asserts para verificar los datos ingresados y la subida de un archivo indivisual
