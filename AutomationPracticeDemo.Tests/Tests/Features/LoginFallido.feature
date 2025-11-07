Feature: LoginFallido
	Scenario: Inicio de sesión fallido con credenciales inválidas
		Given El usuario realiza una solicitud de inicio de sesión fallido con credenciales inválidas
		When El usuario da click en registro inicio de sesión
		Then El usuario navega a la página de inicio de sesión
		When El usuario digita  el correo electrónico valido
		And El usuario digita una contraseña no valida 
		And El usuario da click en el botón de iniciar sesión
		Then El usuario debería ver un mensaje de error indicando que las credenciales son inválidas