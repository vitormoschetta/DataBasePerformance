# Database Performance Analyzer for PostgreSQL

## Initial Setup

### Compose Up

```bash
docker-compose up -d
```


## Migration Add
    
```bash
dotnet ef migrations add InitialCreate --project src/Modeling1/Modeling1.csproj -o Migrations
```