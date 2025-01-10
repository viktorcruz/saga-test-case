# Saga - Test Case

Este proyecto es una aplicación monolítica desarrollada con **WinForms** en **.NET 8**, que implementa **DDD (Domain-Driven Design)**, **CQRS**, y utiliza herramientas como **ADO.NET**, **Dapper**, **Procedimientos Almacenados (SP)** e **IoC (Inversión de Control)**.

---

## 🛠 Tecnologías y Herramientas Utilizadas

- **Lenguaje:** C# (.NET 8)
- **Patrones de Diseño:**
  - CQRS (Command Query Responsibility Segregation)
  - DDD (Domain-Driven Design)
- **Base de Datos:** SQL Server
  - Acceso a datos con ADO.NET y Dapper
  - Uso de Procedimientos Almacenados (Stored Procedures)
- **UI:** WinForms
- **Gestión de Dependencias:** IoC (Inversión de Control)

---

## 📁 Estructura del Proyecto

El proyecto está dividido en las siguientes capas:

### 1. **Saga.TestCase.Application**
   - Contiene la lógica de aplicación, incluyendo los casos de uso y la implementación de **CQRS**.
   - Subcarpetas:
     - `Clientes`: Casos de uso relacionados con clientes.
     - `Facturas`: Casos de uso relacionados con facturas.
     - `Productos`: Casos de uso relacionados con productos.
     - `Ventas`: Casos de uso relacionados con ventas.

### 2. **Saga.TestCase.Domain**
   - Define las **entidades** y las **interfaces** necesarias para la lógica de dominio.
   - Subcarpetas:
     - `Entities`: Entidades de dominio.
     - `Dependencies`: Interfaces del dominio.

### 3. **Saga.TestCase.Infrastructure**
   - Implementa el acceso a datos y la lógica de infraestructura.
   - Subcarpetas:
     - `Database`: Configuración y acceso a la base de datos utilizando **ADO.NET** y **Dapper**.
     - `Repositories`: Implementaciones de los repositorios del dominio.
     - `Factories`: Factorías necesarias para crear objetos de infraestructura.
     - `IoC`: Configuración de Inversión de Control.

### 4. **Saga.TestCase.Presentation**
   - Contiene la interfaz de usuario utilizando **WinForms**.
   - Subcarpetas:
     - `Forms`: Formularios individuales de la aplicación.
     - `Mdi`: Formularios principales para gestionar la interfaz MDI.
     - `Utils`: Utilidades compartidas en la capa de presentación.
     - `IoC`: Configuración específica de IoC para la presentación.

### 5. **Saga.TestCase.Transversal**
   - Contiene dependencias y utilidades transversales reutilizables en todo el proyecto.
   - Subcarpetas:
     - `IoC`: Gestión y configuración de dependencias globales.

---

## ⚙️ Configuración

### 1. **Requisitos Previos**
   - .NET SDK 8 instalado.
   - SQL Server configurado.
   - Conexión a la base de datos configurada en el archivo `appsettings.json`.

### 2. **Configuración de la Base de Datos**
   - Asegúrate de ejecutar los scripts de los **procedimientos almacenados** en la base de datos.
   - Configura la cadena de conexión en `Saga.TestCase.Presentation/appsettings.json`:
     ```json
     {
       "ConnectionStrings": {
         "DefaultConnection": "Server=YOUR_SERVER;Database=YOUR_DATABASE;User Id=YOUR_USER;Password=YOUR_PASSWORD;"
       }
     }
     ```

### 3. **Ejecutar el Proyecto**
   1. Abre la solución en Visual Studio 2022 o superior.
   2. Establece `Saga.TestCase.Presentation` como proyecto de inicio.
   3. Compila y ejecuta el proyecto.

---

## 🧩 Principios de Diseño

### **Domain-Driven Design (DDD)**
El proyecto sigue el enfoque **DDD**, que divide la lógica del negocio en las siguientes capas:
- **Dominio:** Contiene entidades y lógica de negocio pura.
- **Aplicación:** Define casos de uso específicos y coordina la lógica entre el dominio e infraestructura.
- **Infraestructura:** Se encarga del acceso a datos, integración con servicios externos, y repositorios.

### **CQRS**
Se implementa la segregación de comandos y consultas:
- **Comandos:** Operaciones que modifican el estado del sistema (crear, actualizar, eliminar).
- **Consultas:** Operaciones de solo lectura que obtienen información.

### **Mediator**
Se implmeneta junto con **CQRS**, permitiendo que los objetos se comuniquen entre sí a través de un mediador, en lugar de hacerlo directamente.

### **ID**
Se implementa para que los objetos reciban sus dependencias de una fuente externa.

---

## 📂 Funcionalidades Principales

- **Gestión de Clientes:** Crear, editar y consultar clientes.
- **Gestión de Facturas:** Registrar y listar facturas.
- **Gestión de Productos:** Agregar, actualizar y consultar productos.
- **Gestión de Ventas:** Registrar y consultar ventas.

---

## 📂 Nugets utilizados

- **AutoMapper:** Mapea objetos.
- **MediatR:** Comunicación entre objetos. 
- **Microsoft.Extensions.Configuration:** Abstracciones para configurar IConfiguration.
- **Microsoft.Extensions.DependencyInjection:** Acoplamiento flexible

## 📝 Licencia

Este proyecto está bajo la licencia MIT. Para más detalles, consulta el archivo [LICENSE](LICENSE).

## 🔨 Autor

Victor Cruz


## Arquitectura

**Domain-Driven-Desing DDD**
```plaintext
├───Saga
│   ├─── Application
│   │   ├───Clientes
│   │   │   ├───Commands
│   │   │   └───Queries
│   │   ├───Facturas
│   │   │   ├───Commands
│   │   │   └───Queries
│   │   ├───Productos
│   │   │   ├───Commands
│   │   │   └───Queries
│   │   └───Ventas
│   │       ├───Commands
│   │       └───Queries
│   │
│   ├─── Domain
│   │   ├───Entities
│   │   └───Entities
│   │
│   ├─── Infrastructure
│   │   ├───Database
│   │   ├───Factories
│   │   ├───IoC
│   │   └───Repositories
│   │       ├───AdoNet
│   │       ├───Dapper
│   │       └───StoredProcedure
│   │
│   ├─── Presentation
│   │   ├───Forms
│   │   ├───Mdi
│   │   └───Utils
│   │
│   └─── Transversal
│       └───IoC
└───tools

```

Carga de datos mediante un txt

![Carga de Datos mediante un TXT](./img/1.png)

Carga de datos mediante ADO.Net

![Carda de Datos mediante Ado.net](./img/2.png)


# Sistema Externo 

Se generan datos de forma masiva con **Go**.

Se utiliza un script en **Go** para generar de forma masiva datos genericos con el fin de implementar el **Caseo de Uso** de millones de registros.

Paquete implementado para conectar **Go** a SQL Server e inyectar registros:

```
go get github.com/denisenkom/go-mssqldb@v0.10.0
```