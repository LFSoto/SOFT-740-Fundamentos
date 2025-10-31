Feature: Login
scenario: Inicio de sesi�n exitoso
	Given El usuario realiza una solicitud de inicio de sesi�n
	When El usuario da click en registro/inicio de sesi�n.
	Then El usuario visualiza la p�gina de inicio de sesi�n.
	When El usuario digita  el correo electr�nico "<email>" 
	And El usuario digita la contrase�a "<password>".
	And El usuario da click en el bot�n de iniciar sesi�n.
	Then El usuario visualiza su cuenta con el nombre "<accountName>".