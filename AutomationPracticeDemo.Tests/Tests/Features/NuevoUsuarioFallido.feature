﻿Feature: Registro Fallido de Nuevo Usuario
scenario: Registro de nuevo usuario fallido por correo ya registrado
	Given El usuario realiza una solicitud de registro de nuevo usuario
	When  El usuario da click en registro/inicio de sesión.
	Then El usuario navega a la página de inicio de sesión.
	When El usuario digita nombre "<firstName>".
	And  El usuario digita el correo electrónico "<email>" que si este registrado.
	And EL usuario da click en el botón de registrarse "<Sin¿gnup>".
	Then El usuario visualiza un mensaje de error indicando que el correo ya está registrado "<errorMessage>".