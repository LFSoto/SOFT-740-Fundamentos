Feature: Login
scenario: Inicio de sesión exitoso
	Given El usuario realiza una solicitud de inicio de sesión
	When El usuario da click en registro/inicio de sesión.
	Then El usuario visualiza la página de inicio de sesión.
	When El usuario digita  el correo electrónico "<email>" 
	And El usuario digita la contraseña "<password>".
	And El usuario da click en el botón de iniciar sesión.
	Then El usuario visualiza su cuenta con el nombre "<accountName>".