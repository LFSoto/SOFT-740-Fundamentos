Feature: Env�o de mensaje a trav�s del formulario de contacto
scenario:Env�o exitoso del formulario de contacto
	Given El usuario realiza una solicitud de contacto
	When El usuario da click en el enlace de "Contact Us"
	Then El usuario visualiza la p�gina de contacto
	When El usuario completa el formulario de contacto con los campos obligatorios
	And El usuario da click en el bot�n de enviar
	And El usuario  acepta la alerta de confirmaci�n 
	Then El usuario visualiza el mensaje de confirmaci�n de env�o exitoso