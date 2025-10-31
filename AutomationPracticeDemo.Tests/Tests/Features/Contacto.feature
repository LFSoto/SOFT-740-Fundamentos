Feature: Envío de mensaje a través del formulario de contacto
scenario:Envío exitoso del formulario de contacto
	Given El usuario realiza una solicitud de contacto
	When El usuario da click en el enlace de "Contact Us"
	Then El usuario visualiza la página de contacto
	When El usuario completa el formulario de contacto con los campos obligatorios
	And El usuario da click en el botón de enviar
	And El usuario  acepta la alerta de confirmación 
	Then El usuario visualiza el mensaje de confirmación de envío exitoso