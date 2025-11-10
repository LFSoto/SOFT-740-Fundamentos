Feature: Proceso de compra completo en SwagLabs
  Como usuario autenticado
  Quiero poder comprar productos desde el inventario
  Para validar que el flujo de checkout funcione correctamente

  Background:
    Given que inicio sesion con las credenciales validas del caso "TC01"

  Scenario: Compra exitosa de productos
    Given que agrego los productos al carrito
      | Producto                |
      | Sauce Labs Backpack     |
      | Sauce Labs Bike Light   |
    When procedo al checkout y completo los datos del cliente
      | Nombre  | Apellido | CodigoPostal |
      | Johan   | Mata     | 11001        |
    Then la compra debe completarse exitosamente
