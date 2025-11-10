@allure.suite:Login
@allure.feature:Autenticacion_de_usuarios
Feature: Login de usuarios en SwagLabs
  Como usuario de SwagLabs
  Quiero iniciar sesion con diferentes credenciales
  Para validar logins exitosos y fallidos

  @login_exitoso
  @allure.story:Login_exitoso
  @allure.tag:positivo
  Scenario Outline: Login exitoso con credenciales validas (dataset <CaseId>)
    Given que tengo los datos de login del caso "<CaseId>"
    And estoy en la pagina de login
    When inicio sesion con esas credenciales
    Then el login debe ser exitoso

    Examples:
      | CaseId |
      | TC01   |

  @login_fallido
  @allure.story:Login_fallido
  @allure.tag:negativo
  Scenario Outline: Login no exitoso con credenciales invalidas (dataset <CaseId>)
    Given que tengo los datos de login del caso "<CaseId>"
    And estoy en la pagina de login
    When inicio sesion con esas credenciales
    Then el login debe fallar mostrando un mensaje de error

    Examples:
      | CaseId |
      | TC02   |
