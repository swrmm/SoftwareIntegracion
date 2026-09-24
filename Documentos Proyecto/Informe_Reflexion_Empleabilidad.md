# 📝 Informe de Reflexión de Empleabilidad - Etapa 1

**Asignatura:** Taller de Integración (IEI-094)  
**Proyecto:** Sistema de Control de Asistencia  
**Estudiante / Integrante:** Fabian Mora, Agustin Cañas y Paul Ferrada  
**Fecha:** 24-09-2026 

---

## 1. 📌 Introducción
El presente informe tiene por objetivo reflexionar de forma crítica e introspectiva sobre el desempeño personal y técnico alcanzado durante el desarrollo del proyecto **Sistema de Control de Asistencia**. A través de esta evaluación, se analizan las competencias clave de empleabilidad, el trabajo colaborativo, la capacidad de adaptación y la resolución de problemas técnicos frente a los requerimientos del cliente.

---

## 2. 🤝 Trabajo en Equipo y Comunicación Efectiva

### 2.1 Coordinación y Distribución de Roles
* **Roles Asignados:** Durante la Etapa 1 del proyecto, las tareas se dividieron en diseño de arquitectura base de datos, desarrollo de lógica de negocio (Servicios C# WPF) y la confección de documentación de análisis y diseño.
* **Mecanismos de Comunicación:** Se utilizó control de versiones Git y reuniones periódicas para asegurar el cumplimiento del cronograma y la integración continua del código.

### 2.2 Gestión de Conflictos y Acuerdos
* Frente a divergencias en la elección de la pila tecnológica (WPF vs Web) o el esquema de la base de datos (SQLite y relaciones FK), se priorizaron los requerimientos funcionales y la seguridad de contraseñas mediante hashing BCrypt.

---

## 3. 🧩 Resolución de Problemas y Pensamiento Crítico

### 3.1 Desafíos Técnicos Enfrentados
1. **Modelado e Integridad de Datos:** Garantizar que los marcajes de entrada y salida respetaran la restricción de un solo evento por día por usuario.
   * *Solución:* Implementación de restricciones compuestas en EF Core e índices únicos.
2. **Construcción de Pruebas Unitarias:** Implementar suites de prueba aisladas en xUnit para verificar la lógica de autenticación, control de accesos y cálculos de atrasos/inasistencias sin alterar la base de datos de producción.

### 3.2 Adaptabilidad y Autogestión
* La capacidad de aprender e integrar tecnologías (.NET 10, Entity Framework Core 9, xUnit, WPF MVVM) en plazos acotados demostró un alto nivel de autonomía y responsabilidad profesional.

---

## 4. 📈 Autoevaluación de Competencias de Empleabilidad

| Competencia de Empleabilidad | Nivel Logrado (1 a 5) | Justificación / Evidencia |
| :--- | :---: | :--- |
| **Responsabilidad y Compromiso** | 5 | Cumplimiento del 100% de los entregables de software, diagramas y suites de pruebas unitarias. |
| **Trabajo bajo Presión** | 4 | Capacidad de respuesta ante cambios de requisitos y corrección inmediata de errores de persistencia. |
| **Resolución de Problemas** | 5 | Diseño de arquitectura limpia basada en patrones MVVM y Servicios desacoplados con validaciones rigurosas. |
| **Pensamiento Crítico** | 4 | Capacidad de cuestionar y refinar las reglas de negocio para mitigar vacíos de seguridad. |

---

## 5. 🎯 Conclusión y Plan de Mejora Personal

### 5.1 Conclusiones Principales
El desarrollo de esta primera entrega no solo permitió consolidar conocimientos técnicos en ingeniería de software y programación orientada a objetos, sino también fortalecer destrezas blandas fundamentales para la inserción en el mercado laboral TI.

### 5.2 Compromisos de Mejora para la Etapa 2
* **Profundización en Integración Continua (CI/CD):** Configurar ejecuciones automáticas de `dotnet test` en pipelines de GitHub Actions.
* **Mejora en Documentación Viva:** Mantener actualizados los comentarios de código y diagramas a medida que el prototipo evolucione hacia sus entregas finales.
