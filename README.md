# Proyecto de Pruebas Automatizadas - Automation Practice Demo

Este proyecto contiene un esqueleto en .NET con NUnit y Selenium para practicar pruebas funcionales sobre el sitio [Automation Testing Practice](https://testautomationpractice.blogspot.com/).

## Requisitos
- .NET 8 SDK
- Google Chrome, el más reciente.
- ChromeDriver (instalado automáticamente por NuGet)

## Instalación
```bash
git clone https://github.com/LFSoto/SOFT-740-Fundamentos.git
cd AutomationPracticeDemo.Tests
dotnet restore


## Crear la rama a trabajar.
Ir al repositorio de GIT
Branches seleniumTema2
Crear una rama con el nombre-SeleniumT2

##Extraer los cambios al Vs
Ir a VS
Ver -> Cambios de GIT.
Click en Fetch
Abrimos la pestaña de branches -> Remotos -> Seleccionamos SeleniumT2
Buscamos las ramas remotas y seleccionamos la rama con nuestro nombre.

##Instalar dependencias
En la solución buscamos la carpeta de dependencias y vemos si están cargadas.
Compilar -> Compilar Solución


##Ejecutar las pruebas
 Se pueden ejecutar todos los test de forma individual desde el explorador de pruebas:
- AddToCart
- contactUsForm
- DeleteProductsCart
- EnterAccountInfoTest
- LoginWithUserAccount
- newLetterTest
- NewUserTest
- SignupLoginTest
También se puede ejecutar todas las pruebas en conjunto desde el AutomationPractice en donde los test tienen un orden para ejecutarse de forma automática.

Nota: Se añade el test DeleteProductsCart para limpiar la lista de productos añadidos al carrito para realiza una prueba limpia con el test AddToCart y así verificar que se agregaron los dos productos solicitados.



	





