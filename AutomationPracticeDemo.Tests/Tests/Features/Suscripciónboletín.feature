Feature: Suscripci�n bolet�n
scenario:Suscripci�n con email 
	Given El usuario navega a la p�gina principal de Automation Practice
	When El usuario se dirige a la secci�n de suscripci�n al bolet�n
	And El usuario ingresa un correo electr�nico  "<existingEmail>"
	And El usuario da click en el bot�n de suscribirse
	Then El usuario visualiza el mensaje de confirmaci�n de suscripci�n exitosa "You have successfully subscribed to this newsletter."
	