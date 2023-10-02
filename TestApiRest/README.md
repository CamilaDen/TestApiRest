# TestApiRest

TestApiRest es un proyecto de prueba que administra Pedidos que pueden contener información de Libros y usuarios involucrados en el pedido.

## Requisitos

- Visual Studio Community 2019 o una versión más reciente.
- SQL Server.
- Entity Framework.

## Configuración

1. Clona o descarga este repositorio.
2. Abre el proyecto en Visual Studio Community 2019.
3. Asegúrate de que tengas instalado SQL Server y una instancia local disponible.
4. En la Consola del Administrador de Paquetes (Tools -> NuGet Package Manager -> Package Manager Console), ejecuta el siguiente comando para agregar Entity Framework al proyecto:

- Install-Package Microsoft.EntityFrameworkCore.SqlServer


5. Configura la cadena de conexión a la base de datos SQL Server en el archivo `appsettings.json`:

   json
   {
     "ConnectionStrings": {
       "defaultConnection": "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=ApiRestDB;Integrated Security=True"
     }
   }
   

6. En la Consola del Administrador de Paquetes, ejecuta los siguientes comandos para crear la base de datos y las tablas:

- Add-Migration Initial
- Update-Database


## Guía de uso

La API proporciona endpoints para realizar diferentes operaciones sobre los Pedidos, Libros y Usuarios. Para utilizar la API, es necesario incluir la clave de la API en las solicitudes.

### Endpoints

#### Usuarios

- 'GET /api/Users': Obtiene la lista de todos los usuarios registrados.
- 'GET /api/Users/{id}': Obtiene un usuario por su ID.
- 'POST /api/Users': Crea un nuevo usuario.
- 'PUT /api/Users/{id}': Actualiza los datos de un usuario existente.
- 'DELETE /api/Users/{id}': Elimina un usuario por su ID.

#### Libros

- 'GET /api/Books': Obtiene la lista de todos los libros.
- 'GET /api/Books/{id}': Obtiene un libro por su ID.
- 'POST /api/Books': Agrega un nuevo libro.
- 'PUT /api/Books/{id}': Actualiza la información de un libro existente.
- 'DELETE /api/Books/{id}': Elimina un libro por su ID.

#### Pedidos

- 'GET /api/Orders': Obtiene la lista de todos los pedidos realizados.
- 'GET /api/Orders/{id}': Obtiene un pedido por su ID.
- 'POST /api/Orders': Crea un nuevo pedido.
- 'PUT /api/Orders/{id}': Actualiza los detalles de un pedido existente.
- 'DELETE /api/Orders/{id}': Elimina un pedido por su ID.

### Autenticación

Para realizar cualquier operación a través de la API, debes incluir la clave de la API en la cabecera de la solicitud:

*Nota*: Este es solo un proyecto de prueba, y la autenticación se realiza mediante una clave de API simple. En un entorno de producción, se deben implementar métodos más seguros y robustos de autenticación y autorización.


## Licencia

Este proyecto es de código abierto.
