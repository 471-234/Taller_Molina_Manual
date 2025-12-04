# Guía de Comentarios - Taller Molina

/## Módulo EMPLEADOS - Gestión de Empleados

Este UserControl administra los registros de empleados en la aplicación Taller Molina:

- Ajusta la interfaz y carga los datos al iniciar.
- Carga roles y áreas en los combos para selección.
- Muestra todos los empleados en un DataGridView, con búsqueda y filtrado.
- Permite seleccionar un empleado para editar sus datos.
- Inserta nuevos empleados con contraseña, rol y área asignados.
- Actualiza información de empleados existentes.
- Elimina empleados, validando que no tengan pagos asociados.
- Limpia los campos del formulario tras cada operación.

### Reglas de negocio importantes
- No se permite eliminar un empleado si tiene pagos registrados.
- La contraseña es obligatoria al crear un empleado nuevo.
- La interfaz siempre refleja cambios de manera inmediata.

## Módulo CLIENTE - Gestión de Clientes

Este UserControl administra los registros de clientes en la aplicación Taller Molina:

- Ajusta la interfaz y centra los controles al cambiar tamaño del formulario.
- Carga clientes desde la base de datos en un DataGridView, mostrando información como nombre, teléfono, correo, dirección y fecha de registro.
- Permite insertar nuevos clientes con todos sus datos, incluyendo fecha de registro.
- Permite actualizar la información de clientes existentes.
- Permite eliminar clientes seleccionados del DataGridView.
- Al seleccionar un cliente en el grid, los campos del formulario se llenan automáticamente para edición.
- Incluye limpieza de los campos del formulario después de cada operación.

### Reglas de negocio importantes
- No se permite insertar clientes con nombre vacío.
- Al eliminar, se valida que exista un cliente seleccionado.
- La fecha de registro siempre se guarda o actualiza automáticamente.
- La interfaz siempre refleja los cambios de manera inmediata en el DataGridView.

### Comentario de ejemplo en código C#
```csharp
/* Módulo CLIENTE - Gestión de clientes
 * ------------------------------------
 * Este UserControl administra los registros de clientes:
 * - Ajusta la interfaz y centra los controles al cambiar tamaño.
 * - Carga clientes desde la base de datos en un DataGridView.
 * - Permite insertar, actualizar y eliminar clientes.
 * - Aplica reglas de negocio: no insertar clientes vacíos, siempre guardar fecha.
 */


