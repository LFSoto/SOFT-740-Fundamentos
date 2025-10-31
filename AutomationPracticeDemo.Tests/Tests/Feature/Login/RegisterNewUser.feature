Feature: Registro de usuario

    Scenario: Registro exitoso de un usuario aleatorio
        Given que estoy en la página de Automation Exercise
        When registro un nuevo usuario con datos aleatorios
        Then debería mostrarse el mensaje "ACCOUNT CREATED!"
        And puedo continuar y cerrar sesión
