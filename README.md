# 🖥️ TaskManager.Api - Backend con .NET Core 8

API REST desarrollada con **.NET Core 8** que permite gestionar tareas de forma persistente utilizando **Entity Framework Core** y **SQLite**. Este backend es consumido por una aplicación frontend en **Angular 14** para ofrecer una experiencia completa de gestión de tareas.

![.NET](https://img.shields.io/badge/.NET_Core-8-blue?logo=dotnet)
![EF Core](https://img.shields.io/badge/EF_Core-8.0-9cf)
![SQLite](https://img.shields.io/badge/Database-SQLite-00aced)

---

## ✨ Características

- ✅ API REST con métodos `GET`, `POST`, `PUT` y `DELETE`.
- ✅ Persistencia de datos con **SQLite** (archivo `tasks.db`).
- ✅ Inicialización automática con 3 tareas de ejemplo.
- ✅ Configuración de **CORS** para permitir peticiones desde Angular (`http://localhost:4200`).
- ✅ Documentación de API con **Swagger / SwaggerUI** en desarrollo.
- ✅ Modelo de datos simple y eficiente: `TaskItem`.

---

## 🚀 Tecnologías utilizadas

- **Framework**: .NET Core 8
- **ORM**: Entity Framework Core 8
- **Base de datos**: SQLite (archivo local)
- **Documentación**: Swagger / SwaggerUI
- **Control de versiones**: Git

---

## 🛠️ Instalación y uso

### 1. Navegar al directorio del backend

```bash
cd ~/Desarrollo/Pruebas/TaskManager.Api