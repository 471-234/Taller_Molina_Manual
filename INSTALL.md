# 📦 Guía de Instalación – Taller Molina

El siguiente documento explica paso a paso cómo instalar, configurar y ejecutar el sistema **Taller Molina**, desarrollado en **C# (.NET 8)** bajo **Windows Forms**, utilizando SQL Server o MySQL como motores de base de datos.

# 1. Requisitos del Sistema

## 1.1 Sistema Operativo  
- Windows 10 o Windows 11 (64 bits)

## 1.2 Herramientas de Desarrollo  
- Visual Studio 2019 o Visual Studio 2022  
  - Workloads requeridos:
    - *Desktop development with .NET*
    - *Data storage and processing* (opcional)

## 1.3 Framework  
- .NET 8 SDK

## 1.4 Motores de Base de Datos  
- SQL Server 2019 / 2022  
- MySQL Server 8

# 2. Clonar el Repositorio

Ejecutar en Git Bash, CMD o PowerShell:

## Instalación
1. Clonar el repositorio:  
   `git clone https://github.com/471-234/Taller_Molina_Manual_Tecnico.git`
2. Abrir la solución en Visual Studio (`TallerMolina.sln`) desde `src/TallerMolina/`.
3. Restaurar paquetes NuGet si los hubiera.
4. Configurar la cadena de conexión a la base de datos en `Data/DbContext.cs`.
5. Compilar y ejecutar la aplicación.


