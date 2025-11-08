Feature: Login
Scenario: Inicio de sesión exitoso
	Given El usuario realiza una solicitud de inicio de sesion
	When El Usuario da click en registro de sesion
	Then El usuario visualiza la pagina de inicio de sesion
	When El usuario digita el correo electronico "SOFT-740@cenfotec.com" y contrasena "SOFT-740"
	And El usuario da click en el boton de iniciar sesion
	Then El usuario visualiza su cuenta con el nombre "SOFT-740"