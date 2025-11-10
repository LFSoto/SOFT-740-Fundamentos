Feature: Añadir productos al carrito en SwagLabs
  Como usuario de SwagLabs
  Quiero añadir uno o varios productos al carrito
  Para poder continuar con el flujo de compra

  Background:
    Given que tengo los datos de login del caso "TC01"
    And estoy en la pagina de login
    When inicio sesion con esas credenciales
    Then el login debe ser exitoso

  Scenario Outline: Añadir productos al carrito usando el dataset <CaseId>
    Given que tengo los datos de productos del caso "<CaseId>"
    When agrego esos productos al carrito
    Then los productos deben estar en el carrito

    Examples:
      | CaseId |
      | AC01   |
      | AC02   |
