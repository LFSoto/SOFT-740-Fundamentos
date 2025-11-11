Feature: Login de usuarios en AutomationExercise
  Como usuario registrado
  Quiero iniciar sesion con mis credenciales
  Para ver mi nombre autenticado en la pagina

  @login_exitoso
  Scenario Outline: Login exitoso con credenciales validas (dataset <CaseId>)
    Given que tengo los datos de login del caso "<CaseId>"
    And que estoy en la pagina de login
    When inicio sesion con esas credenciales
    Then el sistema debe mostrar el nombre del usuario autenticado

    Examples:
      | CaseId |
      | TC01   |
      | TC02   |



