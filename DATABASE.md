# Base de Datos - Taller Molina

Este documento describe la estructura de la base de datos del sistema Taller Molina, incluyendo tablas, relaciones y consideraciones importantes.

---

## Tablas principales
- Clientes
- Empleados
- Vehículos
- Servicios
- Facturas

## Motores Soportados
- SQL Server 2022
- MySQL Server 8
- Scripts generados automáticamente (auto-healing DB)

- 
### Los scripts permiten:
- Crear base de datos
- Insertar datos iniciales
- Reparar tablas inconsistentes

## Tablas principales

### 1. ROLES
- **RolID** (INT, PK, auto-increment)
- **Nombre** (VARCHAR(50), único, obligatorio)
- **Descripcion** (VARCHAR(200))

**Descripción:** Define los roles de los empleados del taller (Administrador, Mecánico, Secretario, Pintor).

---

### 2. EMPLEADOS
- **EmpleadoID** (INT, PK, auto-increment)
- **Nombre** (VARCHAR(100), obligatorio)
- **Telefono** (VARCHAR(20))
- **Correo** (VARCHAR(100))
- **RolID** (INT, FK → ROLES.RolID)
- **Usuario** (VARCHAR(50))
- **ContrasenaHash** (VARCHAR(128))
- **Area** (VARCHAR(100))
- **Activo** (TINYINT, por defecto 1)

**Descripción:** Información de los empleados y su rol dentro del taller.

---

### 3. CLIENTES
- **ClienteID** (INT, PK, auto-increment)
- **Nombre** (VARCHAR(100), obligatorio)
- **Telefono** (VARCHAR(20))
- **Correo** (VARCHAR(100))
- **Direccion** (VARCHAR(255))
- **FechaRegistro** (DATETIME, por defecto CURRENT_TIMESTAMP)

**Descripción:** Datos de los clientes del taller.

---

### 4. SERVICIOS
- **ServicioID** (INT, PK, auto-increment)
- **Nombre** (VARCHAR(100), único, obligatorio)
- **Categoria** (VARCHAR(50))
- **Descripcion** (VARCHAR(255))
- **Precio** (DECIMAL(12,2), por defecto 0)
- **Activo** (TINYINT, por defecto 1)

**Descripción:** Lista de servicios que ofrece el taller.

---

### 5. FACTURAS
- **FacturaID** (INT, PK, auto-increment)
- **ClienteID** (INT, FK → CLIENTES.ClienteID)
- **EmpleadoID** (INT, FK → EMPLEADOS.EmpleadoID)
- **Fecha** (DATETIME, por defecto CURRENT_TIMESTAMP)
- **Total** (DECIMAL(12,2), por defecto 0)
- **Codigo** (VARCHAR(50))
- **TipoFactura** (VARCHAR(20), por defecto 'SERVICIO')

**Descripción:** Registra las facturas emitidas a los clientes.

---

### 6. REPUESTOS
- **RepuestoID** (INT, PK, auto-increment)
- **Nombre** (VARCHAR(150), obligatorio)
- **Categoria** (VARCHAR(80))
- **Precio** (DECIMAL(12,2), por defecto 0)
- **Stock** (INT, por defecto 0)
- **Activo** (TINYINT, por defecto 1)

**Descripción:** Almacena los repuestos disponibles en el inventario.

---

### 7. INVENTARIO
- **InventarioID** (INT, PK, auto-increment)
- **RepuestoID** (INT, FK → REPUESTOS.RepuestoID)
- **Cantidad** (INT, por defecto 0)
- **CostoPromedio** (DECIMAL(12,2), por defecto 0)
- **FechaActualizacion** (DATETIME, por defecto CURRENT_TIMESTAMP)

**Descripción:** Control de stock de los repuestos.

---

### 8. DETALLE_FACTURA
- **DetalleID** (INT, PK, auto-increment)
- **FacturaID** (INT, FK → FACTURAS.FacturaID)
- **ServicioID** (INT, FK → SERVICIOS.ServicioID)
- **RepuestoID** (INT, FK → REPUESTOS.RepuestoID)
- **Descripcion** (VARCHAR(255))
- **Cantidad** (INT, por defecto 1)
- **PrecioUnitario** (DECIMAL(12,2), por defecto 0)
- **Subtotal** (DECIMAL(12,2), por defecto 0)

**Descripción:** Detalle de cada servicio o repuesto dentro de una factura.

---

### 9. PAGOS
- **PagoID** (INT, PK, auto-increment)
- **FacturaID** (INT, FK → FACTURAS.FacturaID)
- **EmpleadoID** (INT, FK → EMPLEADOS.EmpleadoID)
- **NumeroCuenta** (VARCHAR(100))
- **Metodo** (VARCHAR(100))
- **Monto** (DECIMAL(12,2), por defecto 0)
- **FechaPago** (DATETIME, por defecto CURRENT_TIMESTAMP)
- **Observacion** (VARCHAR(400))

**Descripción:** Registro de pagos realizados a facturas.

---

### 10. BITACORA
- **BitacoraID** (INT, PK, auto-increment)
- **EmpleadoID** (INT, FK → EMPLEADOS.EmpleadoID)
- **Accion** (VARCHAR(200), obligatorio)
- **Fecha** (DATETIME, por defecto CURRENT_TIMESTAMP)
- **Detalle** (VARCHAR(500))

**Descripción:** Registro de acciones realizadas por los empleados en el sistema.

---

## Relaciones principales

- `EMPLEADOS.RolID → ROLES.RolID`  
- `FACTURAS.ClienteID → CLIENTES.ClienteID`  
- `FACTURAS.EmpleadoID → EMPLEADOS.EmpleadoID`  
- `INVENTARIO.RepuestoID → REPUESTOS.RepuestoID`  
- `DETALLE_FACTURA.FacturaID → FACTURAS.FacturaID`  
- `DETALLE_FACTURA.ServicioID → SERVICIOS.ServicioID`  
- `DETALLE_FACTURA.RepuestoID → REPUESTOS.RepuestoID`  
- `PAGOS.FacturaID → FACTURAS.FacturaID`  
- `PAGOS.EmpleadoID → EMPLEADOS.EmpleadoID`  
- `BITACORA.EmpleadoID → EMPLEADOS.EmpleadoID`

---

## Consideraciones

- Todos los IDs principales son auto-incrementales.  
- Columnas `Activo` por defecto están en 1 para indicar registros activos.  
- Las fechas por defecto usan `CURRENT_TIMESTAMP`.  
- La base de datos se puede poblar automáticamente usando `DatabaseSmartBuilder.RunScript()` en C#.  
- Este documento sirve como guía y referencia técnica para desarrolladores y evaluadores.

---
