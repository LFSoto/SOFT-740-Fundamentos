Feature: Registro Fallido de Nuevo Usuario
	Scenario: Registro de nuevo usuario fallido por correo ya registrado
		Given El usuario realiza una solicitud de registro de nuevo usuario
		When El usuario da click en registro/inicio de sesión
		Then El usuario navega a la página de inicio de sesión
		When El usuario digita nombre
		And El usuario digita el correo electrónico que si este registrado
		And EL usuario da click en el botón de registrarse
		Then El usuario visualiza un mensaje de error indicando que el correo ya está registrado