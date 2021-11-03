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
DO $$ DECLARE
    r RECORD;
BEGIN
    FOR r IN (SELECT tablename FROM pg_tables WHERE schemaname = current_schema()) LOOP
        EXECUTE 'DROP TABLE IF EXISTS ' || quote_ident(r.tablename) || ' CASCADE';
    END LOOP;
END $$;

```
In Package Manager Console
```
dotnet ef migrations remove
```