# Pruebas Automatizadas en .NET - Proyecto Final - Swag Labs

Este proyecto contiene un esqueleto en .NET con NUnit, Selenium y BDD de las pruebas pruebas funcionales y unitarias sobre el sitio [Swag Labs] https://www.saucedemo.com/)
## Resumen del proyecto
Este framework integra pruebas funcionales (BDD) y pruebas unitarias dentro de una arquitectura modular, escalable y profesional, diseñada para validar tanto la interfaz de usuario como la lógica de negocio del sistema.
Características principales
-	Arquitectura basada en Page Object Model (POM).
-	Escenarios BDD legibles en Gherkin integrados con Reqnroll.
-	Uso de datos externos en JSON para parametrizar pruebas.
-	Mocks con Moq para simular servicios externos (pagos y notificaciones).
-	Reportes dinámicos con Allure, con métricas, evidencias y capturas.


## Requisitos
- .NET 8 SDK
- Google Chrome
- ChromeDriver (instalado automáticamente por NuGet)
- Gecko Driver

## Instalación
```bash
## Instalación y ejecución de pruebas

Restaurar las dependencias
- dotnet restore


Compilar la solución
- dotnet build


Ejecutar las pruebas
- dotnet test
