# Práctica 4 de Pruebas Automatizadas - Automation Practice Demo

Este proyecto contiene un esqueleto en .NET con NUnit y Selenium para practicar pruebas funcionales sobre el sitio https://automationexercise.com/

[![.NET 9 Selenium Tests](https://github.com/LFSoto/SOFT-740-Fundamentos/actions/workflows/dotnet-tests.yml/badge.svg)](https://github.com/LFSoto/SOFT-740-Fundamentos/actions/workflows/dotnet-tests.yml)

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
- Se implementa patrón de diseño POM y DDT
- La estructura tiene las pages y posteriormente una carpeta por cada page y funcionalidad
- Subcarpeta data que contiene un json y cs
- Subcarpeta test con las validaciones
- Se agrega en el proyecto la imagen QA.jpeg utilizada en el contactUsTest

## Nota
Se presenta un tema con la lectura de la imagen QA.jpeg pero al copiarla manual en la ruta indicada el test se ejecuta correctamente

