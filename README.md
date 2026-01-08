# MovieData API - Sistema de Gestión de Películas

API REST desarrollada con ASP.NET Core 8 para la gestión de información relacionada con películas, géneros, actores y premios.  
El proyecto está enfocado en buenas prácticas de desarrollo backend, diseño limpio y mantenibilidad.

---

## Características Principales

### API REST
- API RESTful desarrollada con ASP.NET Core
- Respuestas en formato JSON
- Endpoints claros y consistentes
- Documentación automática con Swagger
- Configuración de CORS

### Persistencia de Datos
- Entity Framework Core como ORM
- Consultas mediante LINQ
- Operaciones asíncronas
- Abstracción del acceso a datos mediante Repository Pattern

### Arquitectura
- Arquitectura en N capas (API → Infrastructure → DataAccess)
- Separación clara de responsabilidades
- Inyección de dependencias
- Principios SOLID aplicados

### Modelado
- Uso de DTOs para transferencia de datos
- Separación entre modelos internos y contratos de la API
- Control de la información expuesta
- Mapeo entre entidades y DTOs

### Configuración y Seguridad
- Uso de User Secrets para datos sensibles
- Sin credenciales en el repositorio
- Configuración por entorno
- Prevención de SQL Injection mediante EF Core

## Documentación de la API

La API cuenta con documentación interactiva generada con Swagger, permitiendo explorar y probar los endpoints disponibles.

---

## Tecnologías Utilizadas

| Categoría | Tecnología | Versión |
|----------|-----------|--------|
| Backend | ASP.NET Core | 8.0 |
| Lenguaje | C# | 12 |
| ORM | Entity Framework Core | 8.0 |
| Base de Datos | SQL Server | 2019 |
| Documentación | Swagger / OpenAPI | - |

---

## Buenas Prácticas Implementadas

- Programación asíncrona
- Inyección de dependencias
- Separación de responsabilidades
- Principios SOLID
- Código limpio y mantenible
- Repository Pattern
- DTO Pattern
- Uso de User Secrets
  
---

## Estado del Proyecto

Proyecto funcional y en evolución, con una base técnica sólida para futuras ampliaciones.

---

## Implementación Pendiente

- Autenticación y autorización (JWT)
- Manejo global de errores
- Validaciones avanzadas con FluentValidation
- Versionado de la API
- Logging centralizado con Serilog
- Pruebas unitarias e integración

---

## Mejoras Futuras

### Corto Plazo
- Autenticación con JWT
- Validaciones con FluentValidation
- Paginación y filtros avanzados
- Manejo centralizado de excepciones
- CRUD completo para MoviesActors
- UPDATE y DELETE para Genres, Actors y Awards

### Mediano Plazo
- Versionado de endpoints
- Logging estructurado con Serilog
- Cacheo de respuestas coon Redis
- Pruebas de integración
- Health Checks
- Rate Limiting

### Largo Plazo 
- Dockerización con Docker Compose
- CI/CD con GitHub Actions
- Observabilidad y métricas
- Integración con servicios externos
- CQRS con MediatR
- GraphQL como alternativa
- Deploy a Azure o AWS

---

## Objetivo del Proyecto

Este proyecto sigue en proceso para demostrar el desarrollo profesional de APIs REST utilizando el ecosistema .NET, aplicando buenas prácticas y diseño orientado a producción.

---

## Licencia

Este proyecto está bajo la Licencia MIT. Ver `LICENSE` para más información.

## Autor

**Carlos García** - Software Developer (.NET)

- **GitHub**: [https://github.com/Carlosdevelopp](https://github.com/Carlosdevelopp)
- **LinkedIn**: [https://linkedin.com/in/carlosdevel](https://linkedin.com/in/carlosdevel)
- **Email**: carlosdevelopp@gmail.com

## Agradecimientos

- Documentación oficial de [ASP.NET Core](https://docs.microsoft.com/aspnet/core)
- [Entity Framework Core Team](https://docs.microsoft.com/ef/core/)
- Comunidad de desarrolladores .NET

## Screenshots

### Swagger UI - Documentación Interactiva
![Swagger UI](docs/screenshots/swagger-ui.png)

### GET /api/movies/{id}/details - Consulta con Include
![Movie Details](docs/screenshots/movie-details.png)

### POST /api/movies - Creación Exitosa
![Post Movie](docs/screenshots/post-movie.png)

### Arquitectura del Sistema
![Architecture](docs/screenshots/architecture-diagram.png)

