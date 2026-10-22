# 📋 Sistema de Control de Asistencia - Etapa 2

Sistema de escritorio desarrollado en **WPF (.NET 10)** para la gestión y control de asistencia de personal en tiempo real, orientado a garantizar la **continuidad operacional** en base a requerimientos, estándares y políticas institucionales.

* **Asignatura:** Taller de Integración de Competencias II (IEI-094)
* **Institución:** Instituto Profesional Santo Tomás
* **Equipo de Desarrollo:**
  * **Fabián Mora** (Infraestructura, Base de Datos SQLite y Continuidad Operacional)
  * **Agustín Cañas** (Desarrollo Frontend WPF MVVM y Lógica de Negocio)
  * **Paul Ferrada** (Validación QA, Pruebas Unitarias xUnit y Exportación Ofimática)

---

## 🛠️ Tecnologías y Arquitectura

* **Lenguaje:** C# (.NET 10)
* **Interfaz de Usuario:** WPF (Windows Presentation Foundation) con interfaz moderna oscura y escalado DPI responsivo.
* **Patrón de Arquitectura:** MVVM (Model-View-ViewModel) con comandos desacoplados (`RelayCommand`).
* **Base de Datos:** SQLite 3 (Motor relacional embebido local libre de latencias de red).
* **ORM:** Entity Framework Core 10.
* **Seguridad:** BCrypt.Net-Next para cifrado unidireccional seguro de contraseñas.
* **Testing:** xUnit + Microsoft.NET.Test.Sdk (19 pruebas automatizadas con 100% de aprobación).
* **Integración con Ofimática:** Módulo `ExportService` que genera archivos CSV con codificación UTF-8 con BOM y delimitador `;` nativo para apertura automática en **Microsoft Excel** y LibreOffice Calc.

## 🔑 Credenciales por Defecto (Administrador)

Al ejecutar la aplicación por primera vez, `DatabaseInitializer` crea automáticamente la base de datos `asistencia.db` y siembra el usuario administrador inicial:

* **Correo:** `admin@empresa.cl`
* **Contraseña:** `admin123`


