## TALLER MOLINA

Sistema de Gestión Empresarial desarrollado en C# Windows Forms.
Incluye módulos de inventario, clientes, proveedores, facturación, control de ventas y dashboard con indicadores clave.
Diseñado para pequeñas empresas que necesiten una herramienta rápida y funcional.

## Tecnologías Utilizadas

* Backend / Lógica de Negocio
* C# (.NET 8) – Windows Forms
* ADO.NET para conexión a base de datos
* SQL Server 2019 / MySQL 8 (motor dual seleccionable)

### Frontend (UI)

* Windows Forms Modern UI
* Controles personalizados y UserControls dinámicos

# Base de Datos

## Motores Soportados

* SQL Server 2019
* MySQL Server 8
* Scripts generados automáticamente (auto-healing DB)

### Los scripts permiten:

* Crear base de datos
* Insertar datos iniciales
* Reparar tablas inconsistentes

## Tablas principales

* CLIENTES
* EMPLEADOS
* SERVICIOS
* REPUESTOS
* FACTURAS
* DETALLE\_FACTURA
* PAGOS

# Pruebas

## Usuarios de prueba

Admin: admin / 2006

## Casos críticos a validar

Registro de facturas
Registro de pagos (Factura tipo PAGO)
Crear factura de servicio
Actualización de inventario al registrar un servicio
Búsqueda global
Bitácora del sistema
Permisos por roles

# Equipo del Proyecto

Nombre  ---------------  Rol
Nayeri Melendres --- Desarrollador Backend
Henry Jafet Zambrano Ortiz --- Analista de Base de Datos
Mario Maldonado --- Diseñador UI / Tester
Osman Orellana --- Documentacion

# Estado del Proyecto

Versión actual: v1.0.0
Estado: En producción estable
Próximas mejoras:
Módulo de proveedores ampliado
Mejoras en dashboard de estadísticas



## Estructura del repositorio

src/ -> Código fuente del proyecto
docs/ -> Documentación técnica y diagramas
README.md -> Portada del proyecto y descripción general
INSTALL.md -> Cómo instalar y ejecutar el sistema
DATABASE.md -> Detalle de la base de datos (tablas, triggers, SPs)
COMMENTS\_GUIDE.md -> Guía de comentarios en C# y SQL







# Taller\_Molina\_Manual

Repositorio oficial para la documentación técnica y manuales de desarrolladores del proyecto Taller Molina

