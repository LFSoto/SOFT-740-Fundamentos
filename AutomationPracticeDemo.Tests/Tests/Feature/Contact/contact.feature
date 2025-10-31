Feature: Formulario de contacto

    Scenario: Envío exitoso del formulario
        Given que estoy en la pantalla de Contact Us
        When envío el formulario con nombre "<name>", email "<email>", asunto "<subject>", mensaje "<message>" y archivo "<file>"
        Then debería mostrarse "Success! Your details have been submitted successfully."
