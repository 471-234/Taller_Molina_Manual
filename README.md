Taller Molina: Sistema de Gestión Empresarial

El proyecto Taller Molina consiste en el desarrollo de un sistema de gestión empresarial orientado a pequeñas y medianas empresas del sector automotriz. El sistema fue implementado en C# Windows Forms bajo .NET 8, integrando módulos esenciales para la administración de inventarios, clientes, proveedores, facturación, ventas, pagos y un panel de indicadores clave. La solución busca mejorar la eficiencia operativa mediante una interfaz intuitiva, un diseño modular y un rendimiento estable para entornos administrativos.

Tecnologías utilizadas
Backend y lógica de negocio

El desarrollo del backend se realizó en C# (.NET 8) aplicando una arquitectura por capas que incluye interfaz de usuario (UI), capa de lógica de negocio (BLL) y capa de acceso a datos (DAL). La comunicación con la base de datos se implementó mediante ADO.NET, permitiendo consultas seguras, optimizadas y estructuradas. Asimismo, el sistema incorpora compatibilidad con dos motores de base de datos: SQL Server 2019/2022, administrado mediante SQL Server Management Studio 22 (SSMS 22), y MySQL Server 8, lo que facilita su despliegue en diferentes entornos.

Frontend o interfaz de usuario

La interfaz fue desarrollada con tecnología Windows Forms Modern UI, integrando controles personalizados y módulos dinámicos mediante UserControls. Este enfoque permite una navegación responsiva, mejor legibilidad de la información y un diseño coherente con aplicaciones empresariales contemporáneas. El sistema prioriza la usabilidad, la estabilidad y la claridad en la presentación de los datos.

Base de datos
Motores soportados

El sistema ofrece soporte para SQL Server 2019 y 2022, siendo este el motor principal utilizado en las fases de desarrollo, prueba y despliegue mediante SQL Server Management Studio 22 (SSMS 22). Alternativamente, también soporta MySQL Server 8, ampliando las opciones de compatibilidad para distintos escenarios de implementación.

Automatización del entorno de datos

Taller Molina integra un mecanismo denominado Auto-Healing DB, el cual genera automáticamente scripts para construir, restaurar y validar la integridad de la base de datos. Este mecanismo incluye la creación inicial del esquema, la generación de tablas con sus relaciones, la inserción de datos predeterminados, la reparación de tablas dañadas y la reinstalación de objetos fundamentales como llaves primarias, llaves foráneas y procedimientos almacenados.

Tablas principales del sistema

El modelo de datos está compuesto por las siguientes entidades centrales:

Clientes
Empleados
Servicios
Repuestos
Facturas
Detalle_Factura
Pagos

Estas tablas conforman el núcleo operativo del sistema, permitiendo una gestión completa de los procesos administrativos.

Pruebas y validación
Usuario administrador

Para efectos de prueba y validación del sistema, se incluye un usuario administrador preconfigurado:

Usuario: admin
Contraseña: 2006
Este usuario cuenta con acceso total a las funciones del sistema y permite verificar la correcta operación de todos los módulos.

Casos críticos evaluados

Las pruebas del sistema contemplaron escenarios clave para garantizar su estabilidad y funcionalidad, entre ellos:

Generación y registro de facturas completas.
Registro y administración de pagos, incluidas las facturas clasificadas como Pago.
Emisión de facturas de servicio.
Actualización automática del inventario al registrar servicios.
Funcionamiento de la búsqueda global.
Registro de eventos en la bitácora del sistema.
Verificación de permisos y restricciones basadas en roles de usuario.

Equipo del proyecto

El desarrollo de Taller Molina fue llevado a cabo por un equipo multidisciplinario encargado de las distintas fases técnicas y operativas:

Nayeri Melendres, Desarrollador Backend.
Henry Jafet Zambrano Ortiz, Analista de Base de Datos.
Mario Maldonado, Diseñador de Interfaz de Usuario y Tester.
Osman Orellana, Encargado de Documentación.

# Taller\_Molina\_Manual

Repositorio oficial para la documentación técnica y manuales de desarrolladores del proyecto Taller Molina

