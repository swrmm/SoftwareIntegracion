# INFORME TÉCNICO DE ESPECIALIDAD - ETAPA 2
## Continuidad Operacional de Tecnologías de la Información (CE3N2)
### Proyecto: Sistema de Control de Asistencia para Personal

---

* **Institución:** Instituto Profesional Santo Tomás  
* **Carrera:** Ingeniería en Informática  
* **Asignatura:** Taller de Integración de Competencias II (IEI-094)  
* **Equipo de Desarrollo:**  
  * Fabián Mora  
  * Agustín Cañas  
  * Paul Ferrada  
* **Fecha de Entrega:** Semana 11 / Octubre 2026  
* **Versión del Documento:** 2.0 (Etapa 2)  

---

## 1. 📌 Resumen Ejecutivo y Alcance del Proyecto

El presente informe consolida el trabajo técnico y metodológico desarrollado por el equipo para garantizar la **continuidad operacional** en el despliegue del software **Sistema de Control de Asistencia**. Este desarrollo responde a la necesidad crítica de una empresa comercializadora de productos químicos con una dotación de 25 trabajadores, requiriendo un Mínimo Producto Viable (MVP) para registrar oportunamente la entrada y salida de su personal, controlar atrasos, salidas anticipadas e inasistencias, y exportar reportes para su análisis en herramientas de ofimática (Microsoft Excel / LibreOffice Calc).

La solución ha sido construida como una aplicación de escritorio moderna en **C# con .NET 10**, interfaz gráfica **WPF (Windows Presentation Foundation)** bajo patrón **MVVM**, almacenamiento local relacional mediante **Entity Framework Core** y motor **SQLite**, con cifrado de credenciales bajo algoritmo **BCrypt.Net-Next**.

A lo largo de las actividades 2.2 a 2.6, el equipo planificó rigurosamente los recursos, estandarizó el proceso de instalación y configuración del sistema operativo y dependencias, ejecutó una bitácora técnica de control, implementó una batería de 19 pruebas unitarias automatizadas con xUnit y consolidó una lista de chequeo integral que certifica la operatividad del computador y del sistema.

---

## 2. 📅 Actividad 2.2: Planificación de la Instalación de Software

### 2.1 Análisis de Recursos Existentes

Para evitar los errores documentados en el caso de estudio (donde se planificó sin catastrar la infraestructura existente), el equipo realizó un inventario técnico previo de hardware, software y red en las estaciones de trabajo de la empresa química:

| Componente | Especificación Existente | Compatibilidad con SistemaAsistencia |
| :--- | :--- | :---: |
| **Arquitectura de Procesador** | Intel Core i3 / i5 8va Gen o superior (x64) | ✅ Totalmente Compatible |
| **Memoria RAM** | 8 GB DDR4 (Mínimo disponible libre: 2.5 GB) | ✅ Compatible (Consumo base app: ~85 MB) |
| **Almacenamiento** | Disco SSD 256 GB (Espacio libre > 50 GB) | ✅ Compatible (Tamaño app + SQLite: < 150 MB) |
| **Sistema Operativo Base** | Windows 10 Pro 22H2 / Windows 11 Pro 64-bit | ✅ Compatible con .NET 10 WPF |
| **Conectividad de Red** | Tarjeta de Red Ethernet 1 Gbps / WiFi 802.11ac | ✅ Operativo para acceso local y remoto |
| **Entorno de Ofimática** | Microsoft Office 365 / Excel 2019 / LibreOffice 7+ | ✅ Soporte nativo para CSV con BOM UTF-8 |

### 2.2 Definición de Objetivos y Requisitos del Proyecto

* **Objetivo General:** Desplegar y validar un sistema de control de asistencia de escritorio que garantice la continuidad operativa del proceso de marcaje y reportería de los 25 empleados de la empresa química.
* **Objetivos Específicos:**
  1. Estandarizar la configuración del sistema operativo Windows y el runtime de .NET 10.
  2. Implementar mecanismos de persistencia local en SQLite con integridad referencial y prevención de registros duplicados diarios.
  3. Proporcionar funcionalidades de administración de usuarios (CRUD) y visualización de reportes automáticos con umbrales configurados (Atrasos > 09:30 AM, Salidas anticipadas < 17:30 PM, Inasistencias en días hábiles).
  4. Habilitar la exportación directa de reportes a formatos de ofimática (CSV delimitado por punto y coma con codificación UTF-8 con BOM para Excel).
  5. Asegurar la continuidad operacional mediante una batería de pruebas unitarias xUnit (100% de aprobación) y una lista de chequeo de 20 criterios.

### 2.3 Cronograma y Carta Gantt de la Planificación (Semanas 7 a 11)

La planificación se estructuró en cinco fases correspondientes a las semanas 7 a 11 del semestre académico, detallando cada una de las actividades, sus plazos y su estado de ejecución:

| Fase / Semana | Actividad | Fecha Inicio | Duración | Responsable | Estado |
| :--- | :--- | :---: | :---: | :--- | :---: |
| **Semana 7: Sello Valórico & Plan** | Actividad 2.1: Reflexión Ética y Sello Valórico | 28/09/2026 | 5 días | Equipo Completo | **Listo** |
| **Semana 7-8: Catastro e Inventario** | Actividad 2.2: Catastro de Recursos e Inventario | 01/10/2026 | 3 días | Fabián Mora | **Listo** |
| **Semana 8: Planificación & Diseños** | Definición de Requisitos y Matriz de Riesgos | 05/10/2026 | 4 días | Fabián Mora | **Listo** |
| **Semana 8: Cronograma** | Elaboración de Carta Gantt e Hitos | 08/10/2026 | 3 días | Paul Ferrada | **Listo** |
| **Semana 9: Instalación & Configuración** | Actividad 2.3: Manual de Instalación y SO | 12/10/2026 | 4 días | Fabián Mora | **Listo** |
| **Semana 9: Procedimientos Técnicos** | Actividad 2.4: Registro en Bitácora Técnica | 15/10/2026 | 3 días | Paul Ferrada | **Listo** |
| **Semana 10: Validación & Pruebas** | Actividad 2.5: Pruebas Unitarias xUnit e Integración | 19/10/2026 | 4 días | Paul Ferrada | **Listo** |
| **Semana 10: Integración Ofimática** | Implementación Módulo Exportación a Ofimática | 21/10/2026 | 3 días | Paul Ferrada | **Listo** |
| **Semana 11: Lista de Chequeo** | Actividad 2.6: Lista de Chequeo de Continuidad | 23/10/2026 | 2 días | Fabián Mora | **Activo** |
| **Semana 11: Cierre y Evaluación** | Grabación de Video Tutorial y Presentación PPT | 24/10/2026 | 3 días | Equipo Completo | **Activo** |

### 2.4 Distribución de Roles del Equipo de Trabajo

A diferencia del caso problemático donde nadie tenía roles asignados, el equipo organizó sus funciones de forma clara y coordinada:

* **Fabián Mora:** Especialista en Infraestructura, Base de Datos y Continuidad Operacional. Encargado de la configuración del entorno del SO, persistencia en SQLite con EF Core, seguridad BCrypt y diseño de la Lista de Chequeo.
* **Agustín Cañas:** Desarrollador Frontend y Lógica de Negocio WPF. Responsable de la arquitectura MVVM, vistas XAML, navegación dinámica, estilos visuales y desarrollo de los servicios de Asistencia y Reportes.
* **Paul Ferrada:** Ingeniero de Calidad (QA), Validación y Reportería de Ofimática. Encargado del diseño y ejecución de la suite de pruebas automatizadas con xUnit, implementación del servicio de exportación CSV a Excel (`ExportService`), redacción de la bitácora técnica y coordinación del video tutorial.

### 2.5 Hitos y Entregables del Proyecto

1. **Hito 1 (Semana 7):** Ficha Metacognitiva de Sello Valórico finalizada con análisis de Fraternidad, Solidaridad, Excelencia y Esfuerzo.
2. **Hito 2 (Semana 8):** Documento de Planificación de Recursos, Matriz de Riesgos y Cronograma Gantt.
3. **Hito 3 (Semana 9):** Manual de Instalación del Sistema Operativo y Bitácora Técnica de Despliegue.
4. **Hito 4 (Semana 10):** Suite de 19 pruebas unitarias automatizadas superadas al 100% y módulo de exportación de ofimática integrado.
5. **Hito 5 (Semana 11):** Computador operativo validado bajo Lista de Chequeo, Video Tutorial grabado y Presentación ejecutiva en PPT.

### 2.6 Matriz de Riesgos Operacionales y Estrategias de Respuesta

| ID | Riesgo Operacional Identificado | Prob. | Impacto | Nivel | Estrategia de Respuesta / Mitigación |
| :---: | :--- | :---: | :---: | :---: | :--- |
| **R-01** | Incompatibilidad de versión de .NET Runtime en el SO cliente. | Media | Alto | **Crítico** | Despliegue de paquete autocontenido o verificación previa mediante script instalador de .NET 10 Desktop Runtime x64. |
| **R-02** | Bloqueo o corrupción del archivo local `asistencia.db` por permisos insuficientes. | Media | Crítico | **Crítico** | Configuración de permisos NTFS de lectura/escritura en carpeta de datos y manejo de excepciones en `AppDbContext` con fallback transaccional. |
| **R-03** | Marcaje duplicado por reintentos accidentales del usuario (doble clic). | Alta | Medio | **Medio** | Validación a nivel de servicio (`AsistenciaService.TieneEntradaHoy`), bloqueo de botón en la vista (`IsEnabled=false`) e índice único compuesto en base de datos. |
| **R-04** | Discrepancia horaria en registros por reloj desincronizado de la estación. | Baja | Alto | **Alto** | Configuración de sincronización automática NTP contra servidor de hora institucional de Windows (`time.windows.com`). |
| **R-05** | Formato de caracteres corrupto en reportes abiertos con Microsoft Excel (tildes/ñ). | Alta | Medio | **Medio** | Inclusión de marca de orden de bytes UTF-8 (BOM: `0xEF, 0xBB, 0xBF`) y delimitador de punto y coma en `ExportService.cs`. |

---

## 3. 🛠️ Actividad 2.3: Manual de Instalación y Configuración del Sistema y Sistema Operativo

### 3.1 Requisitos del Sistema

#### Requisitos Mínimos:
* **Procesador:** x64 con arquitectura de 1.8 GHz de doble núcleo.
* **Memoria RAM:** 4 GB.
* **Espacio en Disco:** 500 MB libres para runtime y base de datos.
* **Sistema Operativo:** Windows 10 (Build 19041 o superior) / Windows 11.
* **Resolución de Pantalla:** 1280 x 720 píxeles.

#### Requisitos Recomendados:
* **Procesador:** Intel Core i5 / AMD Ryzen 5 o superior.
* **Memoria RAM:** 8 GB o más.
* **Espacio en Disco:** Unidad de Estado Sólido (SSD) con más de 2 GB libres.
* **Sistema Operativo:** Windows 11 Pro de 64 bits con actualizaciones al día.
* **Resolución de Pantalla:** 1920 x 1080 píxeles (Full HD) con escalado al 100%.
* **Software Complementario:** Microsoft Excel 2019 / Microsoft 365 para análisis de reportes.

### 3.2 Procedimiento de Instalación del Entorno de Ejecución

1. **Instalación de .NET 10 Desktop Runtime:**
   * Descargar el instalador oficial de Microsoft: `.NET Desktop Runtime 10.0.x (x64)`.
   * Ejecutar como Administrador e instalar el runtime de Windows Desktop.
   * Verificar la instalación abriendo una terminal de PowerShell y ejecutando:
     ```powershell
     dotnet --list-runtimes
     ```
     *Resultado esperado:* Debe figurar `Microsoft.WindowsDesktop.App 10.0.x` en la lista.

2. **Despliegue de los Archivos de la Aplicación:**
   * Crear la carpeta de destino del software en una ruta segura, por ejemplo:
     `C:\Program Files\SistemaAsistencia\` o `C:\Empresa\SistemaAsistencia\`.
   * Descomprimir o copiar los binarios compilados de la solución.

3. **Configuración de Permisos en la Carpeta de Almacenamiento:**
   * Dado que la aplicación utiliza SQLite (`asistencia.db`), el usuario local requiere permisos de lectura y escritura en la carpeta donde reside la base de datos.
   * Asignar permisos mediante PowerShell:
     ```powershell
     icacls "C:\Empresa\SistemaAsistencia" /grant "Usuarios:(OI)(CI)M"
     ```

4. **Configuración de Integración con Herramientas de Ofimática:**
   * La aplicación genera archivos `.csv` compatibles con suites de ofimática.
   * Para asegurar que Windows abra los archivos automáticamente con Excel, asociar la extensión `.csv` a Microsoft Excel a través del menú de aplicaciones predeterminadas de Windows.

5. **Creación de Acceso Directo de Inicio:**
   * Crear un acceso directo en el Escritorio apuntando a `SistemaAsistencia.exe`.
   * En Propiedades del acceso directo, verificar que "Iniciar en:" apunte al directorio que contiene el ejecutable.

---

## 4. 📝 Actividad 2.4: Bitácora de Instalación y Procedimientos Técnicos

La siguiente bitácora documenta de manera cronológica cada paso realizado durante la preparación, instalación y puesta a punto del computador y la aplicación:

| Registro N° | Fecha y Hora | Responsable | Tarea Ejecutada | Parámetros / Comandos | Resultado / Observaciones |
| :---: | :---: | :---: | :--- | :--- | :--- |
| **BIT-01** | 2026-10-12 09:30 | Fabián Mora | Verificación del SO e integridad de Windows 11. | `winver`, `sfc /scannow` | Sistema operativo Windows 11 Pro 64-bit íntegro y sin archivos dañados. |
| **BIT-02** | 2026-10-12 11:15 | Fabián Mora | Instalación de dependencias de ejecución .NET 10. | `winget install Microsoft.DotNet.DesktopRuntime.10` | Instalación exitosa. .NET 10.0.401 disponible en PATH del sistema. |
| **BIT-03** | 2026-10-13 14:00 | Agustín Cañas | Configuración de resolución de pantalla y DPI. | Resolución 1920x1080 @ 100% | La interfaz moderna oscura de WPF se adapta perfectamente sin cortes. |
| **BIT-04** | 2026-10-14 10:20 | Paul Ferrada | Despliegue de binarios del sistema de asistencia. | `dotnet publish -c Release -o bin/Publish` | Binarios generados sin advertencias ni dependencias faltantes. |
| **BIT-05** | 2026-10-15 15:45 | Paul Ferrada | Primera ejecución e inicialización de SQLite. | Ejecución de `SistemaAsistencia.exe` | `DatabaseInitializer` creó `asistencia.db` y el usuario admin (`admin@empresa.cl`). |
| **BIT-06** | 2026-10-16 09:00 | Agustín Cañas | Verificación de apertura de reportes en Excel. | Apertura de archivo CSV de prueba generado. | Detección de caracteres con acentos correcta gracias al encoding UTF-8 con BOM. |
| **BIT-07** | 2026-10-19 16:30 | Fabián Mora | Validación de políticas de seguridad local. | Auditoría de puertos y permisos de escritura. | La aplicación funciona en modo usuario restringido con permisos exclusivos en su carpeta. |

---

## 5. 🧪 Actividad 2.5: Plan de Validación y Pruebas Integrales de Continuidad Operacional

### 5.1 Condiciones de Satisfacción y Resultados Esperados

El software se considera **operativo y apto para producción** cuando cumple el 100% de las siguientes condiciones de satisfacción:
1. Las credenciales ingresadas son verificadas de forma segura contra hash BCrypt en menos de 300 ms.
2. Un empleado no puede registrar dos entradas ni dos salidas en el mismo día calendario.
3. El administrador puede dar de alta, editar y eliminar usuarios asegurando unicidad en correos institucionales.
4. Los filtros de atrasos muestran con exactitud las entradas posteriores a las 09:30 AM.
5. Los filtros de salidas anticipadas muestran con exactitud las salidas previas a las 17:30 PM.
6. Las inasistencias detectan automáticamente días laborables (lunes a viernes) sin registro previo.
7. La exportación a CSV genera archivos con BOM UTF-8 y delimitador `;` legibles en Microsoft Excel.

### 5.2 Suite de Pruebas Unitarias Automatizadas (xUnit)

Se ejecutó la suite completa de pruebas unitarias contenida en el proyecto `SistemaAsistencia.Tests`, alcanzando un **100% de éxito (19/19 superadas)**:

| Suite de Prueba | Casos Ejecutados | Superadas | Fallidas | Cobertura Funcional |
| :--- | :---: | :---: | :---: | :--- |
| **AuthServiceTests** | 3 | 3 | 0 | Login correcto, contraseña incorrecta, cuenta inactiva. |
| **AsistenciaServiceTests** | 4 | 4 | 0 | Registro de entrada, rechazo de duplicado, registro de salida, registros de hoy. |
| **UsuarioServiceTests** | 4 | 4 | 0 | Creación de usuario, bloqueo de correo duplicado, modificación y borrado lógico. |
| **ReporteServiceTests** | 3 | 3 | 0 | Consulta de atrasos (>09:30), salidas (<17:30) e inasistencias en días de semana. |
| **ExportServiceTests** | 5 | 5 | 0 | Generación CSV atrasos, salidas, inasistencias, escape de caracteres y archivo UTF-8 BOM. |
| **TOTAL** | **19** | **19** | **0** | **100% Superado** |

### 5.3 Casos de Prueba Funcionales del Sistema (CP-01 a CP-10)

| ID Caso | Funcionalidad Evaluada | Procedimiento de Prueba | Resultado Esperado | Estado |
| :---: | :--- | :--- | :--- | :---: |
| **CP-01** | Inicio de Sesión de Administrador | Ingresar `admin@empresa.cl` / `admin123`. | Acceso concedido al panel con menú completo de reportes y gestión. | **CONFORME** |
| **CP-02** | Inicio de Sesión con Clave Errónea | Ingresar `admin@empresa.cl` / `claveIncorrecta`. | Mensaje de advertencia "Credenciales inválidas" sin colapso del sistema. | **CONFORME** |
| **CP-03** | Marcaje de Entrada de Empleado | Iniciar sesión como empleado y pulsar "Marcar Entrada". | Se registra la hora actual y el botón se deshabilita para evitar duplicados. | **CONFORME** |
| **CP-04** | Intento de Entrada Duplicada | Reintentar marcar entrada en la misma fecha. | El sistema rechaza la operación informando que la entrada ya existe hoy. | **CONFORME** |
| **CP-05** | Marcaje de Salida de Empleado | Pulsar "Marcar Salida" al finalizar la jornada. | Se registra la hora actual y se actualiza el historial en pantalla. | **CONFORME** |
| **CP-06** | Alta de Nuevo Usuario en el Sistema | Administrador completa formulario con nombre, correo y rol. | Usuario creado en SQLite; contraseña cifrada con BCrypt. | **CONFORME** |
| **CP-07** | Prevención de Correo Duplicado | Intentar crear usuario con correo ya registrado en la BD. | El sistema cancela la creación e informa que el correo ya se encuentra en uso. | **CONFORME** |
| **CP-08** | Generación de Reporte de Atrasos | Filtrar registros de la semana y pulsar "Generar Reporte". | Visualización exclusiva de marcajes con hora superior a las 09:30:00. | **CONFORME** |
| **CP-09** | Reporte de Salidas Anticipadas | Filtrar registros del mes y pulsar "Generar Reporte". | Visualización de salidas marcadas antes de las 17:30:00. | **CONFORME** |
| **CP-10** | Exportación de Reporte a Ofimática | Pulsar botón "📥 Exportar Excel/CSV" en reporte de atrasos. | Se genera archivo `.csv` que abre directamente en Microsoft Excel sin errores. | **CONFORME** |

---

## 6. ✅ Actividad 2.6: Lista de Chequeo (Checklist) de Continuidad Operacional

La siguiente lista de chequeo fue aplicada de forma rigurosa sobre el computador y el sistema operativo para certificar la **continuidad operacional del equipo y las aplicaciones**:

| N° | Ítem de Chequeo | Criterio de Verificación | Estado | Responsable | Observaciones |
| :---: | :--- | :--- | :---: | :---: | :--- |
| **1** | Integridad del Sistema Operativo | Windows 10/11 x64 actualizado sin archivos de sistema dañados. | **Conforme** | Fabián Mora | Comprobado mediante comando `sfc /scannow`. |
| **2** | Entorno de Ejecución .NET | .NET 10 Desktop Runtime x64 instalado y reconocido en PATH. | **Conforme** | Fabián Mora | Versión 10.0.401 verificada con `dotnet --list-runtimes`. |
| **3** | Almacenamiento y Espacio en Disco | Espacio disponible en disco duro superior a 10 GB libres en C:\. | **Conforme** | Fabián Mora | > 50 GB libres en unidad SSD. |
| **4** | Conectividad de Red | Conexión Ethernet / WiFi activa con salida a Internet y DNS resuelto. | **Conforme** | Fabián Mora | Ping exitoso a gateway local y servidores externos. |
| **5** | Sincronización Horaria (NTP) | Reloj del sistema sincronizado con servidor horario oficial de Windows. | **Conforme** | Fabián Mora | Hora exacta fundamental para marcajes de entrada/salida. |
| **6** | Permisos de Sistema de Archivos | Permisos de lectura y escritura en el directorio de `asistencia.db`. | **Conforme** | Paul Ferrada | Permisos NTFS otorgados al grupo Usuarios locales. |
| **7** | Creación Automática de Base de Datos | `DatabaseInitializer` genera tablas SQLite e índices al primer inicio. | **Conforme** | Paul Ferrada | Base de datos `asistencia.db` creada con integridad. |
| **8** | Semilla de Usuario Administrador | Creación del usuario maestro `admin@empresa.cl` con hash BCrypt. | **Conforme** | Paul Ferrada | Verificado ingreso con contraseña predeterminada `admin123`. |
| **9** | Interfaz Gráfica y Resolución | Interfaz WPF en modo oscuro visible y legible en resolución 1080p. | **Conforme** | Agustín Cañas | Escalado DPI correcto sin superposición de elementos. |
| **10** | Manejador Global de Excepciones | Los errores imprevistos son capturados en `App.xaml.cs` sin caída abrupta. | **Conforme** | Agustín Cañas | Registro de excepciones en archivo local `crash.log`. |
| **11** | Autenticación y Cierre de Sesión | Formulario de login valida contraseñas y permite cerrar sesión limpia. | **Conforme** | Agustín Cañas | Sesión destruida en memoria al pulsar "Cerrar Sesión". |
| **12** | Control de Marcaje de Entrada | El botón de entrada registra fecha/hora y queda bloqueado en el día. | **Conforme** | Agustín Cañas | Verificado en interfaz y base de datos. |
| **13** | Control de Marcaje de Salida | El botón de salida registra fin de jornada y queda bloqueado en el día. | **Conforme** | Agustín Cañas | No permite salida duplicada en el mismo día. |
| **14** | Módulo de Gestión de Usuarios (CRUD) | Alta, edición, desactivación y listado de personal administrativo/empleado. | **Conforme** | Paul Ferrada | Bloqueo activo ante intentos de correos repetidos. |
| **15** | Reporte Automatizado de Atrasos | Filtrado correcto de entradas posteriores a las 09:30:00 AM. | **Conforme** | Paul Ferrada | Filtro por rango de fechas totalmente operativo. |
| **16** | Reporte de Salidas Anticipadas | Filtrado correcto de salidas anteriores a las 17:30:00 PM. | **Conforme** | Paul Ferrada | Muestra horas exactas registradas por los colaboradores. |
| **17** | Reporte de Inasistencias | Detección de días hábiles laborales (lunes a viernes) sin marcaje. | **Conforme** | Paul Ferrada | Excluye fines de semana de forma automática. |
| **18** | Exportación a Herramientas de Ofimática | Generación de archivo CSV delimitado por `;` con codificación UTF-8 BOM. | **Conforme** | Paul Ferrada | Apertura directa y correcta en Microsoft Excel. |
| **19** | Aprobación de Pruebas Unitarias | 100% de la batería de 19 pruebas xUnit aprobadas sin advertencias. | **Conforme** | Paul Ferrada | Comando `dotnet test` finalizado con código de salida 0. |
| **20** | Procedimiento de Recuperación / Backup | Procedimiento documentado para respaldar y restaurar `asistencia.db`. | **Conforme** | Fabián Mora | Respaldo manual mediante copia segura del archivo SQLite. |

---

## 7. 🚀 Conclusiones y Oportunidades de Mejora del Proceso

### 7.1 Conclusiones Técnicas
* **Garantía de Continuidad Operacional:** A través del cumplimiento estricto de las actividades 2.2 a 2.6, se logró un entorno de trabajo 100% estable. La combinación de .NET 10 y SQLite local asegura que la empresa de productos químicos no detenga sus marcajes de asistencia aun si se producen caídas transitorias del enlace a Internet.
* **Integración Exitosa con Herramientas de Ofimática:** La adición del servicio de exportación a CSV con formato compatible para Microsoft Excel resolvió una de las brechas operativas críticas del caso, facilitando la labor del departamento de Recursos Humanos en la liquidación de remuneraciones.
* **Cultura de Calidad y Prevención:** El uso de suites automatizadas de pruebas unitarias xUnit permitió detectar y subsanar degradaciones de librerías y casos de borde antes de la entrega formal, consolidando un producto robusto y profesional.

### 7.2 Oportunidades de Mejora para Futuras Etapas
1. **Centralización en Nube con Resiliencia Local:** Implementar un mecanismo de sincronización bidireccional que mantenga la base local SQLite como respaldo offline y sincronice periódicamente con un motor centralizado en PostgreSQL o Azure SQL Database.
2. **Autenticación Biométrica / Código QR / RFID:** Integrar lectores de código de barras, tarjetas de proximidad o sensores dactilares USB para agilizar el marcaje en los turnos de entrada masiva de los 25 colaboradores.
3. **Módulo de Notificaciones Automáticas:** Configurar el envío automático por correo electrónico (vía SMTP o Microsoft Graph API) de alertas diarias de atrasos o inasistencias dirigidas a la jefatura de Recursos Humanos.
4. **Instalador Automatizado (MSIX o Inno Setup):** Empaquetar la solución completa con sus prerrequisitos en un instalador desatendido de un solo clic, reduciendo al mínimo el tiempo de despliegue en nuevas estaciones de trabajo.
