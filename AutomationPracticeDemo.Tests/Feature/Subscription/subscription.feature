Feature: Suscripción al boletín

    Scenario: Suscripción exitosa con correos válidos
        Given que el campo de suscripción está vacío
        When suscribo el correo "<email>"
        Then debería mostrarse "You have been successfully subscribed!"