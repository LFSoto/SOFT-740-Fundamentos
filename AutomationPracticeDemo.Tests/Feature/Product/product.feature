Feature: Carrito de compras

    Scenario: Agregar productos y validar totales
        Given que el carrito está vacío
        When agrego los productos "<products>" al carrito
        Then cada ítem del carrito debe tener Total = Precio × Cantidad