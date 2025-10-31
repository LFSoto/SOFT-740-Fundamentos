Feature: LoginFallido
scenario: Inicio de sesi�n fallido con credenciales inv�lidas
	Given El usuario realiza una solicitud de inicio de sesi�n fallido con credenciales inv�lidas
	When El usuario da click en registro/inicio de sesi�n.
	Then El usuario navega a la p�gina de inicio de sesi�n.
	When El usuario digita  el correo electr�nico valido "<email>. 
	And El usuario digita una contrase�a no valida "<password>".
	And El usuario da click en el bot�n de iniciar sesi�n.
	Then El usuario deber�a ver un mensaje de error indicando que las credenciales son inv�lidas.