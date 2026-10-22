# 🎬 GUÍA MAESTRA Y GUION PARA LA GRABACIÓN DEL VIDEO TUTORIAL
## Evaluación Práctica Etapa 2 - Integración de Competencias II (IEI-094)
### Proyecto: Sistema de Control de Asistencia

---

* **Integrantes del Equipo:**
  * Fabián Mora
  * Agustín Cañas
  * Paul Ferrada
* **Formato:** Video Tutorial Grabado en Pantalla con Cámara Web (opcional) y Audio Claro
* **Duración Recomendada:** Entre 6 y 9 minutos (máximo 10 minutos)
* **Resolución Recomendada:** 1080p (1920x1080) a 30 o 60 FPS
* **Herramientas de Grabación Sugeridas:** OBS Studio, Xbox Game Bar (`Win + G`) o Streamlabs Desktop.

---

## 1. 🎯 Objetivos Obligatorios que Debe Demostrar el Video

De acuerdo con las instrucciones de la evaluación de la Etapa 2 (`IEI-094_E2_S11_2_6_Evaluacion practica`), el video debe ser de tipo tutorial y demostrar de forma fehaciente:
1. **La continuidad operacional del equipo:** Mostrar que el computador está configurado, estable y operativo con su sistema operativo Windows y dependencias listas.
2. **El proceso de instalación y configuración de las aplicaciones:** Demostrar cómo se prepara el entorno (.NET 10 Desktop Runtime, permisos y despliegue del software).
3. **El funcionamiento completo de la aplicación:** Recorrido práctico paso a paso de cada caso de uso (Login, marcajes de entrada/salida, control de duplicados, gestión de usuarios, reportes con umbrales y exportación a ofimática/Excel).
4. **La validación técnica automatizada:** Demostración en vivo de la ejecución de pruebas unitarias (`dotnet test`) con 100% de aprobación.
5. **Cierre, reflexiones y lecciones aprendidas:** Relación entre el trabajo técnico realizado, la continuidad operacional y los valores del sello institucional (Excelencia y Esfuerzo, Fraternidad y Solidaridad).

---

## 2. ⏱️ Estructura y Minutaje Sugerido

| Bloque | Tiempo Estimado | Responsable en Pantalla | Contenido Principal |
| :---: | :---: | :---: | :--- |
| **Bloque 1** | 00:00 - 01:15 | **Fabián Mora** | Introducción, presentación del equipo, contexto del caso empresarial y demostración del computador operativo. |
| **Bloque 2** | 01:15 - 02:45 | **Fabián Mora** | Proceso de instalación y configuración del entorno (.NET 10, dependencias, SQLite y permisos). |
| **Bloque 3** | 02:45 - 05:30 | **Agustín Cañas** | Demostración en vivo de la aplicación: Login, marcaje entrada/salida, prevención de duplicados y CRUD de usuarios. |
| **Bloque 4** | 05:30 - 07:15 | **Paul Ferrada** | Generación de reportes (Atrasos > 9:30, Salidas < 17:30, Inasistencias) y exportación a Microsoft Excel (Ofimática). |
| **Bloque 5** | 07:15 - 08:30 | **Paul Ferrada** | Demostración de las 19 pruebas unitarias automatizadas (`dotnet test`), lista de chequeo y conclusiones finales. |

---

## 3. 🎙️ Guion Minuto a Minuto Paso a Paso

### 📍 BLOQUE 1: Introducción y Continuidad Operacional del Equipo (00:00 - 01:15)
* **Voz a cargo:** Fabián Mora.
* **Qué mostrar en pantalla:**
  * Mostrar la portada de la presentación PPT o el escritorio de Windows limpio con el fondo institucional o del proyecto.
  * Abrir brevemente la ventana de "Acerca de tu PC" (`Win + Pause` o Configuración > Sistema > Información) y una terminal de PowerShell mostrando la versión de Windows y la sincronización horaria.
* **Qué decir (Guion):**
  > *"Hola, profesor y compañeros. Sean bienvenidos a este tutorial de la Etapa 2 de la asignatura Integración de Competencias II. Mi nombre es Fabián Mora, y junto a mis compañeros Agustín Cañas y Paul Ferrada presentaremos el despliegue, configuración y validación de la continuidad operacional de nuestro proyecto: el **Sistema de Control de Asistencia**.*
  > 
  > *El caso que resolvemos corresponde a una empresa comercializadora de productos químicos con 25 trabajadores, que requiere con urgencia controlar la asistencia de su personal y generar reportes para Recursos Humanos.*
  > 
  > *Para comenzar, demostramos la continuidad operacional de este equipo: contamos con un sistema operativo Windows 11 de 64 bits completamente actualizado, con reloj sincronizado por protocolo NTP a los servidores de red, conectividad activa y los recursos de hardware necesarios para garantizar un servicio ininterrumpido."*

---

### 📍 BLOQUE 2: Proceso de Instalación y Configuración de Software (01:15 - 02:45)
* **Voz a cargo:** Fabián Mora.
* **Qué mostrar en pantalla:**
  * Abrir PowerShell o Terminal y ejecutar:
    ```powershell
    dotnet --list-runtimes
    ```
    (Mostrar que está instalado `Microsoft.WindowsDesktop.App 10.0.x`).
  * Mostrar la carpeta donde está desplegada la aplicación `SistemaAsistencia`.
  * Mostrar los permisos de la carpeta y cómo se inicializa la base de datos local SQLite `asistencia.db`.
* **Qué decir (Guion):**
  > *"A diferencia del caso de estudio, donde el equipo de soporte actuó sin estándares y cada técnico instaló sistemas operativos distintos sin llevar registro, nosotros implementamos un procedimiento riguroso documentado en nuestro Manual de Instalación y Bitácora Técnica.*
  > 
  > *Primero, verificamos la presencia del entorno de ejecución Microsoft .NET 10 Desktop Runtime mediante el comando `dotnet --list-runtimes`. Segundo, aseguramos los permisos de lectura y escritura en el directorio de la aplicación para que el motor de base de datos SQLite pueda persistir las transacciones sin bloqueos.*
  > 
  > *Al ejecutar por primera vez la aplicación, el componente `DatabaseInitializer` crea automáticamente la base de datos `asistencia.db` con sus tablas relacionales, índices únicos de rendimiento y el usuario administrador inicial con contraseña encriptada mediante algoritmo seguro BCrypt."*

---

### 📍 BLOQUE 3: Demostración en Vivo del Software - Login, Marcaje y Usuarios (02:45 - 05:30)
* **Voz a cargo:** Agustín Cañas.
* **Qué mostrar en pantalla:**
  * Ejecutar `SistemaAsistencia.exe` o iniciarlo desde Visual Studio / terminal.
  * Mostrar la pantalla de **Login** con diseño moderno en modo oscuro.
  * Demostrar un intento de login con credenciales erróneas (ver mensaje de error).
  * Iniciar sesión con `admin@empresa.cl` / `admin123`.
  * Mostrar el panel principal con sidebar navegable y datos del usuario autenticado.
  * Realizar un marcaje de **Entrada**: pulsar el botón y mostrar cómo cambia el estado y se bloquea el botón para evitar duplicados.
  * Ir al módulo de **Gestión de Usuarios**:
    * Mostrar la lista de empleados actuales.
    * Crear un nuevo usuario (ej: `Carlos Gómez`, `carlos@empresa.cl`, rol `Empleado`).
    * Probar la validación de unicidad: intentar crear otro usuario con el mismo correo y mostrar que el sistema lo impide.
    * Editar un usuario o cambiarle el rol.
* **Qué decir (Guion):**
  > *"Gracias, Fabián. Mi nombre es Agustín Cañas y les mostraré el funcionamiento del sistema en vivo.*
  > 
  > *Aquí vemos nuestra ventana de inicio de sesión desarrollada en WPF bajo arquitectura MVVM. Si ingresamos credenciales incorrectas, el sistema valida la seguridad y nos notifica de inmediato sin cerrarse. Al ingresar como Administrador con `admin@empresa.cl`, accedemos al panel de control.*
  > 
  > *En la sección 'Marcar Asistencia', el empleado o administrador registra su entrada con un solo clic. El sistema captura la fecha y la hora exacta del reloj del equipo y, muy importante para la continuidad y la integridad de los datos, bloquea el botón para que nadie pueda registrar dos entradas el mismo día.*
  > 
  > *Luego, en 'Gestión de Usuarios', el administrador puede administrar toda la nómina de la empresa química: crear nuevos colaboradores, asignar roles de Empleado o Administrador, modificar datos o desactivar cuentas. Si intentamos registrar un correo duplicado, el software nos alerta de inmediato protegiendo la base de datos."*

---

### 📍 BLOQUE 4: Módulo de Reportes y Exportación a Ofimática / Excel (05:30 - 07:15)
* **Voz a cargo:** Paul Ferrada.
* **Qué mostrar en pantalla:**
  * Ir a la pestaña **Atrasos**:
    * Explicar el criterio de negocio: se considera atraso toda entrada posterior a las 09:30 AM.
    * Seleccionar el rango de fechas del mes y pulsar **"Generar Reporte"**.
    * Mostrar la grilla con los empleados atrasados, fecha y hora exacta.
    * Pulsar el botón **"📥 Exportar Excel/CSV"**. Guardar el archivo en el Escritorio.
    * **Abrir el archivo CSV generado con Microsoft Excel** directamente en pantalla: mostrar que las columnas están perfectamente separadas y que los nombres con tildes y caracteres especiales se leen sin errores gracias a la codificación UTF-8 con BOM.
  * Ir a la pestaña **Salidas Anticipadas**:
    * Explicar la regla: salidas antes de las 17:30 PM. Pulsar generar reporte y mostrar resultados.
  * Ir a la pestaña **Inasistencias**:
    * Explicar la regla: detección automática de días laborables (lunes a viernes) sin marcaje, excluyendo fines de semana.
* **Qué decir (Guion):**
  > *"Hola a todos, mi nombre es Paul Ferrada. Continuaré mostrándoles una de las características más críticas solicitadas en el caso: el despliegue y compatibilidad con herramientas de ofimática para el área de Recursos Humanos.*
  > 
  > *En el módulo de 'Atrasos', la aplicación filtra automáticamente todos aquellos marcajes de entrada posteriores a las 09:30 AM. Como pueden ver, el administrador puede seleccionar cualquier periodo y consultar el listado completo.*
  > 
  > *Para resolver la necesidad de la empresa de analizar estos datos en sus planillas de cálculo, agregamos la función 'Exportar Excel/CSV'. Al hacer clic, generamos un archivo CSV configurado con marca de orden de bytes UTF-8 con BOM y delimitador de punto y coma. Al abrirlo en Microsoft Excel, observen cómo se despliega inmediatamente formateado, con tildes impecables y listo para que Recursos Humanos procese sueldos y descuentos.*
  > 
  > *De la misma manera funcionan los reportes de 'Salidas Anticipadas' (antes de las 17:30 horas) y el reporte de 'Inasistencias', el cual analiza de forma inteligente los días hábiles del calendario excluyendo sábados y domingos."*

---

### 📍 BLOQUE 5: Pruebas Unitarias Automatizadas, Lista de Chequeo y Cierre (07:15 - 08:30)
* **Voz a cargo:** Paul Ferrada (con intervención breve de Fabián y Agustín).
* **Qué mostrar en pantalla:**
  * Abrir la terminal de comandos o Visual Studio en la carpeta del proyecto.
  * Ejecutar en vivo:
    ```powershell
    dotnet test
    ```
  * Mostrar el resultado en pantalla: **19 pruebas superadas de 19, 0 fallidas**.
  * Mostrar en pantalla la diapositiva de la **Lista de Chequeo (Checklist)** con sus 20 ítems evaluados en estado Conforme.
  * Cierre con los tres integrantes despidiéndose.
* **Qué decir (Guion):**
  > *"Para validar la calidad del software y asegurar que no existan regresiones, implementamos una batería de pruebas unitarias automatizadas con xUnit. Ejecutamos en este momento `dotnet test` en consola... y como pueden apreciar, las 19 pruebas de autenticación, restricciones de marcaje, cálculo de reportes y exportación pasan con un 100% de efectividad.*
  > 
  > *Todo este proceso fue auditado mediante nuestra Lista de Chequeo de Continuidad Operacional de 20 criterios, asegurando que el computador, el sistema operativo, la base de datos y la interfaz gráfica cumplen con los más altos estándares técnicos.*
  > 
  > *Finalmente, en concordancia con nuestro sello valórico Tomista, este proyecto nos demostró que la Excelencia y el Esfuerzo, junto a la Fraternidad y la Solidaridad en equipo, son los pilares fundamentales para entregar un servicio informático de excelencia que garantice la continuidad operacional de cualquier organización.*
  > 
  > *Agradecemos su atención. ¡Muchas gracias!"*

---

## 4. 💡 Recomendaciones Técnicas para la Grabación y Entrega

1. **Configuración de Audio:**
   * Usar auriculares con micrófono para evitar eco o reverberación de los parlantes.
   * Si graban por Discord, Teams o Google Meet entre los tres, asegurarse de probar los niveles de voz antes de comenzar la grabación definitiva.
2. **Entorno Limpio:**
   * Ocultar íconos innecesarios del escritorio.
   * Cerrar aplicaciones personales (WhatsApp, navegadores con pestañas privadas, notificaciones de Windows activando el modo 'No Molestar').
3. **Plataforma de Subida del Video:**
   * Subir el video grabado a **YouTube en modo "No Listado"** (Unlisted) o a **Google Drive / OneDrive** con acceso configurado en *"Cualquier persona que tenga el vínculo puede ver"*.
   * Copiar el enlace directo del video y pegarlo en la diapositiva correspondiente de la presentación PPT (`Presentacion_Etapa_2_Semana_11.pptx`) para que el docente evaluador pueda reproducirlo con un solo clic.
