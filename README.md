# Proyecto de Pruebas Automatizadas - Automation Practice Demo

Este proyecto contiene un esqueleto en .NET con NUnit y Selenium para practicar pruebas funcionales sobre el sitio [Automation Testing Practice](https://testautomationpractice.blogspot.com/).

## Requisitos
- .NET 8 SDK
- Google Chrome (La versión más reciente)
- ChromeDriver (instalado automáticamente por NuGet)

## Instalación
git clone https://github.com/LFSoto/SOFT-740-Fundamentos.git
git checkout DixonChavarria-SeleniumT2 
cd AutomationPracticeDemo.Tests
dotnet restore
dotnet build
dotnet test

##Tests

## Se agregaron los siguientes tests:

- Should_FillAndSubmitWikipediaInput()
- Should_ClickStartStopButton()
- Should_OpenAndCloseConfirmAlert()
- Should_UploadSingleFile()