# API REST de Gestión de Usuarios

Esta es una API REST construida con .NET Core y C# que permite la gestión de usuarios, utilizando arquitectura hexagonal y principios DDD.

## Características

- Método GET para obtener usuarios desde un archivo JSON
- Método POST para crear nuevos usuarios y simular el envío de un email de bienvenida
- Método PUT para actualizar usuarios existentes
- Implementación de arquitectura hexagonal (puertos y adaptadores)
- Uso de principios SOLID y DDD

## Requisitos previos

- .NET 6.0 SDK o superior
- Editor de código (Visual Studio, VS Code, Rider, etc.)

## Estructura del proyecto

El proyecto sigue la arquitectura hexagonal (puertos y adaptadores) y está organizado en las siguientes capas:

- **UserManagement.Domain**: Contiene las entidades de dominio, interfaces de repositorios y servicios (puertos).
- **UserManagement.Application**: Contiene la lógica de aplicación, DTOs y servicios que implementan los casos de uso.
- **UserManagement.Infrastructure**: Contiene implementaciones concretas de repositorios y servicios (adaptadores).
- **UserManagement.Api**: Capa de presentación, contiene los controladores de la API REST (adaptadores primarios).

## Cómo ejecutar el proyecto

### 1. Clonar el repositorio

```
git clone <url-del-repositorio>
cd UserManagement
```

### 2. Restaurar paquetes y compilar

```
dotnet restore
dotnet build
```

### 3. Ejecutar la API

```
cd UserManagement.Api
dotnet run
```

La API estará disponible en:
- https://localhost:7239
- http://localhost:5286

### 4. Acceder a Swagger

Con la aplicación en ejecución, accede a:
- https://localhost:7239/swagger

## Endpoints de la API

### Obtener todos los usuarios
```
GET /api/users
```

### Obtener un usuario por ID
```
GET /api/users/{id}
```

### Crear un nuevo usuario
```
POST /api/users
Content-Type: application/json

{
  "name": "Nombre Usuario",
  "email": "email@ejemplo.com"
}
```

### Actualizar un usuario existente
```
PUT /api/users/{id}
Content-Type: application/json

{
  "name": "Nombre Actualizado",
  "email": "email_actualizado@ejemplo.com"
}
```

## Almacenamiento de datos

Los datos se almacenan en un archivo JSON ubicado en `UserManagement.Api/Data/users.json`. Este archivo se crea automáticamente si no existe.

## Simulación de envío de email

La API simula el envío de un email de bienvenida cuando se crea un nuevo usuario. Esta simulación se implementa en `EmailService` y registra un mensaje en los logs de la aplicación.
