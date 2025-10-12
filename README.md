# Proyecto de Pruebas Automatizadas - Automation Practice Demo

Este proyecto contiene un esqueleto en .NET con NUnit y Selenium para practicar pruebas funcionales sobre el sitio [Automation Testing Practice](https://testautomationpractice.blogspot.com/) y corresponde a la entrega de la práctica # 3 del curso de Automatización de pruebas en .NET.

## Escenarios de prueba
Se realizaron pruebas automatizadas iteractuando con diferentes elementos web, adicionalmente se utilizo la librería Bogus.Faker para generalos datos de pruebas, así como métodos que permieten obtener la información de las tablas de manera dinámica sin importan la cantidad de productos, así como la eliminación de estos.

Se listan las pruebas realizadas:
- Register_New_Random_User.
- Existing_User_Login.
- Add_Products_To_Cart_Validate_Totals.
- Fill_Out_The_Contact_Form.
- Subscription_Newsletter.
- Process_Purchase_Order.

## Requisitos
- .NET 8 SDK
- Google Chrome
- ChromeDriver (instalado automáticamente por NuGet)

## Instalación
```bash
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
