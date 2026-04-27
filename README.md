# Sistema de Tiquetes Aéreos – Proyecto en C#

## Descripción del proyecto

Este proyecto corresponde al desarrollo de una aplicación de consola en **C# con .NET**, orientada a la gestión de un sistema de tiquetes aéreos.

El sistema permite administrar información relacionada con aerolíneas, aviones, aeropuertos, vuelos, reservas, pagos, clientes, asientos y tiquetes, siguiendo una arquitectura modular basada en principios de **DDD (Domain Driven Design)** y separación por capas.

El objetivo principal es centralizar la operación de una plataforma de reservas aéreas, permitiendo el control de entidades críticas del negocio mediante menús de consola y persistencia de datos.

---

## Tecnologías utilizadas

* C#
* .NET
* Visual Studio Code
* Entity Framework (estructura preparada)
* SQL / configuración mediante `appsettings.json`
* Git + GitHub

---

## Estructura general del proyecto

```text
SistemadeTiquetesProyecto-main/
│
├── SistemadeTiquetes.sln
├── README.md
├── appsettings.json
│
└── SistemadeTiquetess/
    │
    ├── Program.cs
    ├── SistemadeTiquetess.csproj
    ├── appsettings.json
    ├── Migrations/
    │
    └── src/
        └── modules/
            │
            ├── Aircrafts/
            ├── Airlines/
            ├── Airports/
            ├── Cities/
            ├── Countries/
            ├── Customers/
            ├── CustomerContacts/
            ├── Flights/
            ├── FlightSegments/
            ├── FlightStatus/
            ├── Reservations/
            ├── ReservationPassengers/
            ├── ReservationStatus/
            ├── Seats/
            ├── SeatAssignments/
            ├── SeatAvailability/
            ├── Payments/
            ├── PaymentMethods/
            ├── Tickets/
            ├── TicketStatus/
            └── Admin/
```

---

## Arquitectura utilizada

Cada módulo sigue una estructura organizada por capas:

```text
Module/
│
├── Application/
│   ├── interfaces/
│   ├── services/
│   ├── usecase/
│   └── DTOs
│
├── Domain/
│   ├── aggregate/
│   ├── repositories/
│   └── valueObject/
│
├── Infrastructure/
│   ├── Entity/
│   └── Repositories/
│
└── UI/
    └── Menús de consola
```

### Función de cada capa

### Application

Contiene la lógica de aplicación, servicios, DTOs y casos de uso.

### Domain

Representa las reglas del negocio, agregados, entidades principales y value objects.

### Infrastructure

Gestiona persistencia, mapeos y repositorios concretos.

### UI

Interfaz de usuario en consola para interacción con el sistema.

---

## Módulos principales del sistema

### Gestión operativa

* Aerolíneas
* Aeronaves
* Aeropuertos
* Países
* Ciudades

### Gestión de vuelos

* Vuelos
* Segmentos de vuelo
* Estado de vuelo

### Gestión de clientes

* Clientes
* Contactos de clientes

### Gestión de reservas

* Reservas
* Pasajeros de reserva
* Estado de reserva

### Gestión de asientos

* Asientos
* Asignación de asientos
* Disponibilidad de asientos

### Gestión financiera

* Pagos
* Métodos de pago

### Gestión de tiquetes

* Tiquetes
* Estado de tiquete

---

## Flujo general del sistema

1. Registrar países, ciudades y aeropuertos
2. Registrar aerolíneas y aeronaves
3. Crear vuelos y segmentos
4. Registrar clientes
5. Crear reservas
6. Asignar pasajeros y asientos
7. Procesar pagos
8. Generar tiquetes
9. Consultar estados y reportes operativos

---

## Cómo ejecutar el proyecto

## 1. Clonar el repositorio

```bash
git clone <url-del-repositorio>
```

---

## 2. Ingresar al proyecto

```bash
cd SistemadeTiquetesProyecto-main
```

---

## 3. Restaurar dependencias

```bash
dotnet restore
```

---

## 4. Compilar el proyecto

```bash
dotnet build
```

---

## 5. Ejecutar la aplicación

```bash
dotnet run --project SistemadeTiquetess
```

---

## Estado actual del proyecto

El sistema cuenta con estructura modular avanzada, separación por capas y base sólida para escalar funcionalidades CRUD completas por cada módulo.

Se encuentra preparado para continuar con:

* validaciones avanzadas
* integración completa con base de datos
* reportes administrativos
* autenticación por roles
* mejoras en interfaz de usuario

---

## Autor

Proyecto académico desarrollado para la gestión integral de tiquetes aéreos mediante arquitectura limpia y buenas prácticas en desarrollo de software.

---

## Conclusión

Este proyecto representa una solución estructurada para la gestión de tiquetes aéreos mediante una aplicación de consola desarrollada en C# y .NET, aplicando principios de arquitectura limpia y organización modular por dominios.

Su diseño permite una administración eficiente de procesos clave como vuelos, reservas, clientes, pagos y emisión de tiquetes, proporcionando una base sólida para futuras mejoras e integraciones.

Como proyecto académico universitario, demuestra la aplicación práctica de buenas prácticas de desarrollo de software, separación por capas, control de versiones y modelado de procesos reales dentro del sector aeronáutico.

Además, facilita la escalabilidad del sistema y su adaptación a necesidades más complejas dentro de un entorno empresarial real.

---

## Autores 

**sergio andres abril mendoza**
**Henry jhoan duran peña**

Proyecto académico  desarrollado 
 para la gestión integral de tiquetes aéreos mediante arquitectura limpia, buenas prácticas de programación y organización modular del software.
