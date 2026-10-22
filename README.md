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

---

## 📂 Estructura de Entregables - Etapa 2

Todos los documentos requeridos para la evaluación de la Etapa 2 (Semanas 7 a 11) se encuentran en la carpeta [`Documentos Proyecto/`](./Documentos%20Proyecto/):

1. **Presentación Ejecutiva PPT:**
   * Archivo: [`Presentacion_Etapa_2_Semana_11.pptx`](./Documentos%20Proyecto/Presentacion_Etapa_2_Semana_11.pptx)
   * Contenido: Lista de chequeo, Carta Gantt de planificación, enlace/estructura del video tutorial y conclusiones con oportunidades de mejora.
2. **Ficha Metacognitiva Sello Valórico:**
   * Archivo Word: [`IEI-094_E2_S7_2_1_Ficha_Metacognitiva_Sello_Valorico.docx`](./Documentos%20Proyecto/IEI-094_E2_S7_2_1_Ficha_Metacognitiva_Sello_Valorico.docx)
   * Formato Markdown: [`Ficha_Metacognitiva_Sello_Valorico.md`](./Documentos%20Proyecto/Ficha_Metacognitiva_Sello_Valorico.md)
   * Contenido: Reflexión y fundamentación de los valores Tomistas **Excelencia y Esfuerzo** y **Fraternidad y Solidaridad** según la pauta oficial.
3. **Informe Técnico de Especialidad (Continuidad Operacional):**
   * Archivo Word: [`IEI-094_E2_Informe_Tecnico_Continuidad_Operacional.docx`](./Documentos%20Proyecto/IEI-094_E2_Informe_Tecnico_Continuidad_Operacional.docx)
   * Formato Markdown: [`Informe_Tecnico_Continuidad_Operacional.md`](./Documentos%20Proyecto/Informe_Tecnico_Continuidad_Operacional.md)
   * Contenido: Actividades 2.2 a 2.6 (Planificación, Manual de Instalación y SO, Bitácora Técnica, Plan de Validación y Lista de Chequeo de 20 criterios).
4. **Guía y Guion del Video Tutorial:**
   * Archivo: [`Guia_Video_Tutorial_Etapa_2.md`](./Documentos%20Proyecto/Guia_Video_Tutorial_Etapa_2.md)
   * Contenido: Estructura minuto a minuto, guion paso a paso por integrante, pantallas a exhibir y recomendaciones técnicas para la grabación.

---

## 🚀 Puesta en Marcha y Ejecución

### Prerrequisitos
1. Windows 10 (x64) o Windows 11.
2. [.NET 10 Desktop Runtime](https://dotnet.microsoft.com/download/dotnet/10.0) instalado.

### Compilación y Ejecución
Para compilar y ejecutar la aplicación desde la consola:
```powershell
dotnet build
dotnet run --project SistemaAsistencia
```

### Ejecución de Pruebas Unitarias Automatizadas
Para ejecutar la batería completa de 19 pruebas xUnit:
```powershell
dotnet test
```

---

## 🔑 Credenciales por Defecto (Administrador)

Al ejecutar la aplicación por primera vez, `DatabaseInitializer` crea automáticamente la base de datos `asistencia.db` y siembra el usuario administrador inicial:

* **Correo:** `admin@empresa.cl`
* **Contraseña:** `admin123`

---

## 📊 Reglas de Negocio Implementadas

* **CA-01 (Marcaje de Asistencia):** Los trabajadores registran entrada y salida. Se valida la restricción de solo 1 entrada y 1 salida por usuario por día calendario.
* **RE-01 (Reporte de Atrasos):** Entradas registradas después de las **09:30 AM**.
* **RE-02 (Reporte de Salidas Anticipadas):** Salidas registradas antes de las **17:30 PM**.
* **RE-03 (Reporte de Inasistencias):** Identificación automática de ausencia de registros en días laborables (lunes a viernes).
* **EX-01 (Exportación a Ofimática):** Botón `📥 Exportar Excel/CSV` en todos los reportes, generando archivos compatibles con Microsoft Excel.
* **GU-01 a GU-03 (Gestión de Usuarios):** CRUD completo con validación estricta de correo electrónico único.
