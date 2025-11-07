Feature: Suscripción boletín
scenario:Suscripción con email 
	Given El usuario navega a la página principal de Automation Practice
	When El usuario se dirige a la sección de suscripción al boletín
	And El usuario ingresa un correo electrónico  "<existingEmail>"
	And El usuario da click en el botón de suscribirse
	Then El usuario visualiza el mensaje de confirmación de suscripción exitosa "You have successfully subscribed to this newsletter."