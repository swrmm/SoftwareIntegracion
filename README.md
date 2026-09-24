# 📋 Sistema de Control de Asistencia

Un sistema de escritorio moderno desarrollado en **WPF (.NET 10)** para la gestión y control de asistencia de empleados en tiempo real, utilizando **Entity Framework Core** con almacenamiento en **SQLite** local.


## 🛠️ Tecnologías Utilizadas

* **Lenguaje:** C# (.NET 10)
* **Interfaz Gráfica:** WPF (Windows Presentation Foundation)
* **Arquitectura:** MVVM (Model-View-ViewModel)
* **Base de Datos:** SQLite (Local)
* **ORM:** Entity Framework Core 10
* **Seguridad:** BCrypt.Net-Next

---

## 🔑 Credenciales por Defecto (Administrador)

Al ejecutar la aplicación por primera vez, se inicializa automáticamente la base de datos local `asistencia.db` y se crea una cuenta de administrador por defecto:

* **Correo:** `admin@empresa.cl`
* **Contraseña:** `admin123`

> ⚠️ **Nota:** Se recomienda cambiar la contraseña o crear una nueva cuenta de administrador desde el panel de gestión de usuarios.