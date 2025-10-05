# Proyecto de Pruebas Automatizadas - Automation Practice Demo

Este proyecto contiene un esqueleto en .NET con NUnit y Selenium para practicar pruebas funcionales sobre el sitio [Automation Testing Practice](https://testautomationpractice.blogspot.com/) y corresponde a la entrega de la práctica # 2 del curso de Automatización de pruebas en .NET.

## Escenarios de prueba
Se realizaron las pruebas automatizadas de los elementos (Text boxes, RadioButtons, Buttons, DropDowns, DatePicker, Alerts y Elementos dinámicos).

Se listan las pruebas realizadas:
- Should_Fill_And_Submit_Form_Parametrized
- Dynamic_Button_Test
- Simple_Alert_Button_Test
- Confirmation_Alert_Button_Test
- Dynamic_Web_Table_Get_Disk_Value_Test
- Data_Picker_Test

## Requisitos
- .NET 8 SDK
- Google Chrome
- ChromeDriver (instalado automáticamente por NuGet)

## Instalación y ejecución de pruebas
Clonar el repositorio
- git clone https://github.com/LFSoto/SOFT-740-Fundamentos.git

Ingresar a la carpeta de pruebas del proyecto
- cd AutomationPracticeDemo.Tests

Restaurar las dependencias
- dotnet restore

Compilar la solución
- dotnet build

Ejecutar las pruebas
- dotnet test
