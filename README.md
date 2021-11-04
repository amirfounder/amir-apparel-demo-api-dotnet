# Markdown File

## Sources / Code Inpsiration

### Repositories

- https://github.com/nbarbettini/BeautifulRestApi/blob/master/src/Startup.cs
- https://github.com/FabianGosebrink/ASPNETCore-WebAPI-Sample

### Developers

- G.B.

## Rebuilding the Database

### Postgres

#### Build
```
dotnet ef migrations add InitialCreate
dotnet ef database update

```
#### Delete
In Query Editor:
```
DROP SCHEMA public CASCADE;
CREATE SCHEMA public;

```
In Package Manager Console
```
dotnet ef migrations remove
```