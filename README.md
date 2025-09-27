# Calculadora Test

## CalculadoraServiceTest.cs
	Utilizamos esta clase para definir los métodos de los repositorios que queremos simular utilizan mocks.
	Creamos los objetos mocks para las interfaces
	Configuramos el mock usando setup
	Utilizamos el object mock en nuestra prueba.

##Repositorios
- IOperacionRepository
	Interface "GuardarOperacion" que recibe dos parámetros pero que no devuelve ningún resultado, por tanto debemos simular su acción.

- ItimeProvider
	Interface "ITimeProvider" que solamente obtiene la fecha y hora actual del sistema local.

##CalculadoraUnitTest
	Utilizamos esta clase para inicializar las variables, llamar los servicios y comprobar los resultados de los test.

------------------------------------------------
#Calculadora Lib

##Calculadora
	Contiene los métodos a llamar desde el Service Test: Sumar, Restar, Multiplicar, Dividir, etc.

##CalculadoraService
	Posee los métodos de SumarYGuardar retonando un resultado de la suma.

