Feature: Registro exitoso
scenario: Registro de nuevo usuario exitoso
	Given El usuario realiza una solicitud de registro de nuevo usuario
	When  El usuario da click en registro/inicio de sesión.
	Then El usuario navega a la página de inicio de sesión.
	When El usuario digita nombre "<firstName>".
	And  El usuario digita el correo electrónico "<email>" que no este registrado.
	And EL usuario da click en el botón de registrarse "<Sin¿gnup>".
	Then El usuario navega a la página de creación de cuenta.
	When El usuario completa el formulario de registro con la información requerida.
	And El usuario da click en el botón de crear cuenta.	
	Then El usuario visualiza mensaje de creaión de cuenta exitosa.