# Database Performance Analyzer for PostgreSQL

## Initial Setup

### Compose Up

```bash
docker-compose up -d
```

### Execute app

```bash
dotnet run --project src/Modeling1/Modeling1.csproj
```

For apply seed data, execute app with `--seed` option:
```bash
dotnet run --project src/Modeling1/Modeling1.csproj --seed
```


## Migration Add
    
```bash
dotnet ef migrations add InitialCreate --project src/Modeling1/Modeling1.csproj -o Migrations
```
