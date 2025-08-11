# 📦 CHANGELOG - PIT

Registro de cambios técnicos del sistema de trazabilidad y optimización en el área de embolsado.

---

## [2025-08-05] - Versión inicial

### ⚙️ Backend (PIT.Backend)
- Se creó `ProduccionController.cs` con endpoints:
  - `GET /api/Produccion` → Devuelve lista simulada de lotes
  - `POST /api/Produccion` → Agrega nuevo lote
- Se habilitó CORS para permitir llamadas desde el frontend (`https://localhost:7176`)
- Se configuró Entity Framework Core con base de datos InMemory
- Swagger UI disponible en [https://localhost:5001/swagger](https://localhost:5001/swagger)

### 🖥️ Frontend (PIT.Frontend)
- Se corrigió la URL del backend en `Program.cs`
- Se creó el componente `EstadoDelSistema.razor` que consume el endpoint `api/produccion`
- Se implementó manejo de errores y carga dinámica de lotes

### 📄 Documentación
- Se reemplazó el `README.md` con enfoque específico en la embolsadora
- Se definió estructura modular del proyecto (Backend, Frontend, Docker)

---

## 🔜 Próximos pasos

- Agregar persistencia simulada o real
- Integrar módulo de monitoreo de línea
- Preparar `Dockerfile` y `docker-compose`
- Documentar cada módulo por separado (`README` por carpeta)
- Presentación técnica para validación interna
