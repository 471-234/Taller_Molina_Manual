📘 DOCUMENTACIÓN OFICIAL – TALLER MOLINA
Versión para README / Manual Técnico
1. Descripción General del Sistema

Taller Molina es un Sistema de Gestión Empresarial desarrollado en C# (.NET 8) bajo arquitectura por capas.
Está orientado a talleres automotrices y pequeñas empresas que requieren control eficiente de sus operaciones principales: inventarios, facturación, clientes, proveedores y análisis de datos.

2. Características Principales

-Interfaz moderna desarrollada en Windows Forms.
-Arquitectura modular y escalable.
-Conexión mediante ADO.NET.
-Motor de base de datos dual: SQL Server 2019 / MySQL 8.
-Scripts inteligentes para auto-reparación (Auto-Healing DB).
-Dashboard con indicadores en tiempo real.
-Sistema de roles y permisos.
-Bitácora de actividades del sistema.

3. Tecnologías Utilizadas

3.1 Backend

-C# (.NET 8 – Windows Forms)
-ADO.NET para consultas SQL
-Patrón de arquitectura en capas (UI – BLL – DAL)
-Manejo de excepciones y logs

3.2 Frontend (UI)

-Windows Forms Modern UI
-UserControls dinámicos
-Ajuste automático para pantallas HD

4. Base de Datos

4.1 Motores Soportados

-SQL Server 2019 / 2022
-MySQL Server 8

4.2 Funciones Auto-Healing

-Crear base de datos automáticamente
-Crear tablas requeridas
-Insertar datos iniciales
-Verificar llaves primarias y foráneas
-Reparar tablas faltantes o dañadas

4.3 Tablas Principales

1.CLIENTES
2.EMPLEADOS
3.SERVICIOS
4.REPUESTOS
5.FACTURAS
6.DETALLE_FACTURA
7.PAGOS
8.ROLES
9.BITACORA
10.CONFIGURACIÓN

5. Pruebas y Validaciones

5.1 Credenciales de Prueba

Usuario para desarrolladores
Usuario: admin
Contraseña: 2006

5.2 Casos Críticos a Probar

1.Registro de facturas
2.Registro de pagos (Factura tipo PAGO)
3.Descuento de inventario al facturar
4.Creación de factura por servicio
5.Permisos según rol
6.Búsqueda global del sistema
7.Registro en bitácora
8.Dashboard y estadísticas

6. Equipo del Proyecto
Versión en cuadro ASCII (compatible con Bloc de Notas)
+----------------------+------------------------------+
| Nombre               | Rol                          |
+----------------------+------------------------------+
| 1. Nayeri Melendres  | Desarrollador Backend        |
| 2. Henrry Zambrano   | Analista de Base de Datos    |
| 3. Mario Maldonado   | Diseñador UI / Tester        |
| 4. Osman Orellana    | Documentación Técnica        |
+----------------------+------------------------------+

7. Estado del Proyecto

Versión actual: v1.0.0
Estado: Estable en producción

Próximas mejoras:

3.1 Ampliación del módulo de proveedores
3.2 Mejoras visuales en dashboard
3.3 Reportes avanzados
3.4 Módulo de órdenes de trabajo

8. Estructura del Repositorio
1. /src                -> Código fuente del sistema
2. /docs               -> Manuales, diagramas y documentación técnica
3. README.md           -> Descripción general del proyecto
4. INSTALL.md          -> Guía de instalación y ejecución
5. DATABASE.md         -> Detalles de tablas, SPs, triggers e índices
6. COMMENTS_GUIDE.md   -> Normas de comentarios en C# y SQL
7. CHANGELOG.md        -> Historial de versiones

9. Objetivo del Repositorio Taller_Molina_Manual

Este repositorio reúne toda la documentación oficial:
Manual técnico para desarrolladores
Manual de usuario final
Diagramas de arquitectura y UML
Procedimiento de instalación y despliegue
Lineamientos de programación
Información estructurada del proyecto
