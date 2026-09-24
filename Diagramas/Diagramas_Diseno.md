# 📐 Diagramas de Análisis y Diseño de Software

Este documento contiene la especificación y representación gráfica de los diagramas de análisis y diseño complementarios solicitados en la pauta de evaluación.

---

## 1. 🔄 Diagrama de Flujo (Autenticación y Registro de Asistencia)

El siguiente flujo describe las decisiones y transiciones desde el inicio de sesión del empleado/administrador hasta el marcaje de entrada o salida.

```mermaid
flowchart TD
    A[Inicio: Abrir Aplicación] --> B[Pantalla de Login]
    B --> C{¿Credenciales válidas?}
    C -- No --> D[Mostrar error: 'Credenciales inválidas']
    D --> B
    C -- Sí --> E{¿Rol de Usuario?}
    
    E -- Empleado --> F[Vista Principal: Marcaje Asistencia]
    F --> G{¿Acción a realizar?}
    G -- Marcar Entrada --> H{¿Ya registró entrada hoy?}
    H -- Sí --> I[Mensaje: 'Entrada ya registrada hoy']
    H -- No --> J[Guardar Registro Entrada en BD]
    J --> K[Notificación Exitosita]
    
    G -- Marcar Salida --> L{¿Ya registró salida hoy?}
    L -- Sí --> M[Mensaje: 'Salida ya registrada hoy']
    L -- No --> N[Guardar Registro Salida en BD]
    N --> K
    
    E -- Administrador --> O[Panel Administrador: Gestión & Reportes]
    O --> P[Consultar Atrasos / Inasistencias / Crear Usuarios]
```

---

## 2. 📊 Diagrama de Estados (Registro de Asistencia Diario)

Describe las transiciones de estado por las que atraviesa la jornada de un empleado en un día hábil determinado.

```mermaid
stateDiagram-v2
    [*] --> SinRegistro: Inicio del día hábil (00:00 AM)
    
    SinRegistro --> Presente_A_Tiempo: Marcaje Entrada <= 09:30 AM
    SinRegistro --> Presente_Con_Atraso: Marcaje Entrada > 09:30 AM
    SinRegistro --> Inasistente: Fin del día sin marcaje
    
    Presente_A_Tiempo --> Jornada_Completa: Marcaje Salida >= 17:30 PM
    Presente_A_Tiempo --> Salida_Anticipada: Marcaje Salida < 17:30 PM
    
    Presente_Con_Atraso --> Jornada_Completa: Marcaje Salida >= 17:30 PM
    Presente_Con_Atraso --> Salida_Anticipada: Marcaje Salida < 17:30 PM
    
    Jornada_Completa --> [*]
    Salida_Anticipada --> [*]
    Inasistente --> [*]
```

---

## 3. ⚙️ Diagrama de Proceso (BPMN / Proceso de Control de Asistencia)

Describe el proceso de negocio entre el Empleado, el Sistema de Asistencia y la Jefatura/Administrador.

```mermaid
sequenceDiagram
    autonumber
    actor E as Empleado
    participant S as Sistema Asistencia WPF
    participant BD as Base de Datos SQLite
    actor A as Administrador
    
    E->>S: Ingresa Correo y Contraseña
    S->>BD: Consulta usuario y verifica Hash BCrypt
    BD-->>S: Usuario verificado (Empleado)
    S-->>E: Muestra interfaz de Marcaje
    
    E->>S: Presiona 'Registrar Entrada'
    S->>BD: Inserta registro (Fecha, Hora, Entrada)
    BD-->>S: Confirmación guardada
    S-->>E: Muestra confirmación en vivo
    
    Note over A,S: Fin de mes o revisión diaria
    A->>S: Solicita Reporte de Atrasos / Inasistencias
    S->>BD: Filtra registros por fecha y límites de horario
    BD-->>S: Retorna dataset compilado
    S-->>A: Despliega tabla de reporte filtrada
```
