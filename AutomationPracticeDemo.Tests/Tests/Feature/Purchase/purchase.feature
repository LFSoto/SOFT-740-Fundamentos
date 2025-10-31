Feature: Proceso de compra

    Scenario: Compra completa con tarjeta
        Given que inicio sesión con "<email>" y "<password>"
        And el carrito está vacío
        When compro los productos "<products>" con nombre en la tarjeta "<name>", número "<card>", cvc "<cvc>" y fecha "<date>"
        Then debería mostrarse "Congratulations! Your order has been confirmed!"
        And puedo finalizar la orden