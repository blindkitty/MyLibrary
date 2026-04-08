## Library Manager Api
Simple monolith web application <br>
.NET 8, EF Core, PostgreSQL <br>
![Схема архитектуры](docs/architecture.png)
<br><br>

# Getting started
1. Create a local environment file from the example:

```bash
cp .env.example .env
```

2. Set your PostgreSQL connection string in `.env`.

3. Build and run the application:

```bash
docker compose up --build
```


Swagger will be available at: http://localhost:8080/swagger
