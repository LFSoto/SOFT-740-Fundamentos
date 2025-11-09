# Práctica 7: Automatización con Selenium y Reqnroll (BDD)

**Sitio bajo prueba:** https://automationexercise.com

Este proyecto forma parte de las prácticas de automatización de pruebas funcionales utilizando **C#**, **Selenium WebDriver**, **NUnit** y el patrón **Page Object Model (Page Factory)**.  
A partir de la **Práctica 7**, los casos de prueba se describen y ejecutan mediante **Gherkin + Reqnroll** (framework BDD compatible con SpecFlow).

El propósito es aplicar buenas prácticas en:
- Diseño de frameworks de automatización estructurados.
- Manejo de elementos dinámicos y Data-Driven Testing (DDT) con archivos JSON.
- Versionamiento en Git con control ordenado del repositorio.
- Implementación de escenarios Gherkin convertidos en pruebas automatizadas.

Durante la ejecución, se generan capturas de pantalla para facilitar el análisis de resultados.

---

## Requisitos previos

Antes de clonar y ejecutar el proyecto, asegúrate de tener instalado:

| Herramienta | Versión recomendada |
|------------|--------------------|
| **Visual Studio 2022** | Con carga de trabajo `.NET Desktop` o `ASP.NET Web Development` |
| **.NET SDK** | 8.0 o superior |
| **Google Chrome** | Última versión estable |
| **ChromeDriver** | Compatible con tu versión de Chrome (se recomienda WebDriverManager) |
| **Git** | Para clonar y versionar el proyecto |

---

## Clonar el repositorio

```bash
git clone https://github.com/YeisonRojas-SeleniumGIT.git
cd YeisonRojas-SeleniumGIT
```

---

## Instalación de dependencias

```bash
dotnet restore
```

O abriendo la solución `.sln` en Visual Studio.

---

## Instalación de Reqnroll (Práctica 7)

Instalar los paquetes NuGet:

```
Reqnroll
Reqnroll.SpecFlowCompatibility
Reqnroll.NUnit
```

Cada archivo `.feature` debe tener su archivo `*.Steps.cs` asociado, usando:

```csharp
[Given]
[When]
[Then]
```

---

## Ejecución de pruebas

### Desde Visual Studio
1. Abrir la solución `.sln`.
2. Menú **Test → Run All Tests** o `Ctrl + R, A`.

### Desde la línea de comandos

```bash
dotnet test
```

Resultados se muestran en consola y capturas se guardan en `Imagen/`.

---

## Escenarios en Gherkin

| Archivo `.feature` | Descripción |
|--------------------|-------------|
| `b_LoginUsuarioExistente.feature` | Login con usuario existente |
| `c_LoginUsuarioNoExistente.feature` | Login inválido |

Cada escenario tiene su implementación en `Steps/`.

---

## Estructura de rama para entrega

Subir a una rama con formato:
```
YeisonRojas-Reqnroll
```

---

## Autor

**Yeison Rojas S.**  
Práctica 7 – Selenium + Reqnroll en C#  
Proyecto educativo para fortalecer habilidades en automatización, BDD y manejo de repositorios.

