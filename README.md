# Galería - Segundo Parcial T123-22

## Requisitos
- .NET 10 SDK + workload MAUI (`dotnet workload install maui`)
- SQL Server. Por defecto se usa **LocalDB** (`(localdb)\MSSQLLocalDB`, viene con Visual Studio).
  La base se crea y se siembra sola al arrancar la app.

## Comandos
```bash
dotnet build Galeria.Parcial2.slnx
```
Ejecutar la app: abrir la solución en Visual Studio / Rider y arrancar `Galeria.Launcher` con el target **Windows** (LocalDB no es accesible desde el emulador de Android).

## Estructura
| Proyecto | Capa |
|---|---|
| `Galeria.Domain` | Entidades, reglas, Composite de permisos, especificaciones, interfaces |
| `Galeria.Application` | Casos de uso, DTOs, algoritmos, variante de legajo |
| `Galeria.Infrastructure` | EF Core + SQL Server, repositorios, usuario simulado |
| `Galeria.Presentation` | ViewModels (net10.0, sin dependencias de MAUI) |
| `Galeria.Launcher` | Host MAUI: Views XAML y composición de DI |

Leé el enunciado completo antes de tocar código. Mantené `ESTADO.md` siempre actualizado.
