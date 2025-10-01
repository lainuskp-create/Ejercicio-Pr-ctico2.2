# Ejercicio 2.2 – Repository + Unit of Work con Entity Framework Core

## Resumen del Proyecto
Este proyecto implementa el patrón **Repository** junto con **Unit of Work** utilizando **.NET 8 / EF Core**.  
El objetivo es desacoplar el acceso a datos de la lógica de negocio, mejorar la mantenibilidad y centralizar la gestión de transacciones.

### Principales características:
- **Repository Pattern**: encapsula las operaciones de acceso a datos.  
- **Unit of Work Pattern**: centraliza la transacción y coordinación entre múltiples repositorios.  
- **Entity Framework Core**: ORM para interactuar con la base de datos.  
- **Lazy Loading**: navegación de entidades automática cuando se accede a propiedades de navegación.  
- **Change Tracking optimizado**: uso de `AsNoTracking()` en consultas de solo lectura.  
- **Query Splitting**: evita problemas de “cartesian explosion” en relaciones 1:N con `AsSplitQuery()`.  
- **Bulk Operations**: soporte para inserciones masivas con `EFCore.BulkExtensions`.  
- **Connection Resilience**: reintentos automáticos ante fallos transitorios en la base de datos.  

---

## Estructura del Código

