Feature: Inicio de sesión

    Scenario: Inicio de sesión exitoso con usuario existente
        Given que estoy en la página de login
        When inicio sesión con el email "<email>" y la contraseña "<password>"
        Then debería mostrarse "Logged in as <usuario>"

