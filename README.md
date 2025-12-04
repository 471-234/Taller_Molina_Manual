

## TALLER MOLINA
Taller Molina es un sistema empresarial desarrollado en C# (.NET 8) utilizando Windows Forms, diseñado para gestionar operaciones críticas como inventarios, clientes, proveedores, facturación, ventas y análisis mediante dashboard.
Su objetivo es ofrecer una herramienta rápida, eficiente y funcional para pequeñas empresas del rubro automotriz.

## 2. Tecnologías Utilizadas

##  Documentación del Proyecto

- 👉 [Guía de Instalación](INSTALL.md)
- 🗄️ [Base de Datos (tablas, triggers, SPs)](DATABASE.md)
- 💬 [Guía de Comentarios en C# y SQL](COMMENTS_GUIDE.md)


### 2.1 Backend / Lógica de Negocio

-C# (.NET 8 – Windows Forms)

-ADO.NET (manejo de conexiones SQL)

-Arquitectura por capas (UI – BLL – DAL)

-Motor de base de datos dual (SQL Server / MySQL)

### 2.2 Frontend (UI)

-Windows Forms Modern UI

-Controles personalizados

-UserControls dinámicos

# 3. Base de Datos

## 3.1 Motores Soportados

-SQL Server 2019 / 2022

-MySQL Server 8

### 3.2 Scripts Automáticos (Auto-Healing DB)

Los scripts permiten:
-Crear la base de datos automáticamente
-Generar tablas principales
-Insertar datos iniciales
-Verificar integridad
-Reparar tablas inconsistentes

## 3.3 Tablas Principales

- CLIENTES
- EMPLEADOS
- SERVICIOS
- REPUESTOS
- FACTURAS
- DETALLE_FACTURA
- PAGOS
  
# 4. Pruebas del Sistema
## 4.1 Usuario de Prueba
Admin/Desarrollador

Usuario: admin

Contraseña: 2006

## 4.2 Casos Críticos a Validar

-Registro de facturas
-Registro de pagos (Factura tipo PAGO)
-Creación de factura por servicio
-Descuento del inventario al facturar
-Funcionamiento de búsqueda global
-Bitácora del sistema
-Permisos por roles4.2 Casos Críticos a Validar
-Registro de facturas
-Registro de pagos (Factura tipo PAGO)
-Creación de factura por servicio
-Descuento del inventario al facturar
-Funcionamiento de búsqueda global
-Bitácora del sistema
-Permisos por roles

# Equipo del Proyecto

| Nombre            | Rol                        |
|-------------------|----------------------------|
| Nayeri Melendres  | Desarrollador Backend      |
| Henrry Zambrano   | Analista de Base de Datos  |
| Mario Maldonado   | Diseñador UI / Tester      |
| Osman Orellana    | Documentación              |


# 6. Estado del Proyecto

Versión actual: v1.0.0

Estado: Estable – En producción

# 6.1 Próximas Mejoras

Ampliación del módulo de proveedores
Mejoras en el dashboard de estadísticas
Nuevas funciones de análisis para el inventario
Optimización general del rendimiento




## Estructura del repositorio

1. src/ -> Código fuente del proyecto
2. docs/ -> Documentación técnica y diagramas
3. README.md -> Portada del proyecto y descripción general
4. INSTALL.md -> Cómo instalar y ejecutar el sistema
5. DATABASE.md -> Detalle de la base de datos (tablas, triggers, SPs)
6. COMMENTS_GUIDE.md -> Guía de comentarios en C# y SQL


# 8. Taller_Molina_Manual

1. Repositorio oficial destinado a centralizar:
2. Manual técnico para desarrolladores
3. Manual de usuario final
4. Diagramas UML y documentación visual
5. Guías de instalación y despliegue
6.Estándares de programación
7. Información estructurada del proyecto
