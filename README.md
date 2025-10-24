# Práctica 5 de Pruebas Automatizadas - Automation Practice Demo

Este proyecto contiene un esqueleto en .NET con NUnit y Selenium para practicar pruebas funcionales sobre el sitio https://automationexercise.com/

## Requisitos
- .NET 8 SDK
- Google Chrome
- ChromeDriver (instalado automáticamente por NuGet)

## Instalación
```bash
git clone https://github.com/LFSoto/SOFT-740-Fundamentos.git
git checkout AlejandraFonseca-SeleniumPOM-DDT
cd AutomationPracticeDemo.Tests
dotnet restore
dotnet build
dotnet test

## Ajustes realizados
- Se implementan SeleniumExtras.WaitHelpers
- Se corrige tema de rutas
- Uso de commits representativos



