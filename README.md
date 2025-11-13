# Proyecto Final
## Integrantes
- Melvin Marin Navarro
- Tamara Salazar Zúñiga

## Descripción
Este proyecto contiene una solcuión en .NET con NUnit, Moq, Selenium, y SpecFlow para practicar pruebas unitarias, funcionales y aceptación (BDD) sobre el sitio [SauceDemo](https://www.saucedemo.com/).

[![.NET 9 Selenium Tests](https://github.com/LFSoto/SOFT-740-Fundamentos/actions/workflows/dotnet-tests.yml/badge.svg?branch=Melvin-SeleniumGIT)](https://github.com/LFSoto/SOFT-740-Fundamentos/actions/workflows/dotnet-tests.yml)

## Requisitos
- .NET 8 SDK
- Google Chrome
- ChromeDriver (instalado automáticamente por NuGet)
- SpecFlow 

## Instalación
```bash
git clone https://github.com/LFSoto/SOFT-740-Fundamentos.git
git checkout Melvin-Tamara-Proyecto
cd SOFT-740-Fundamentos
cd AutomationPracticeDemo.Tests
dotnet restore
dotnet build
dotnet test
```

## Framework
### La arquitectura planteada contiene las capas:
---
- **Constants**
  - Se definen las constantes del proyecto
- **Models**
  - Se encarga de traducir los Json-Keys a atributos de una clase
- **Pages**
  - Se define seguiendo POM para la definición de las páginas
- **PaymentCalculatorLib**
  - Se define la lógica de las pruebas unitarias
- **StepDefinitions**
  - Se define la lógica de los scenarios de prueba según BDD
- **Tests**
  - **DataFiles**
    - Se definen los archivos de fuente de datos en formato JSON
  - **Features**
      - Se definen los scenarios de prueba según BDD
  - **UnitTest**
    - Se definen los casos de pruebas unitarias
- **Utils**
  - Se definen los utilitarias del proyecto   
