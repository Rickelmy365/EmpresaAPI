# EmpresaAPI

API REST desenvolvida em **ASP.NET Core (.NET 8)** para gerenciamento de funcionários, utilizando **Entity Framework Core** com **MySQL**.

---

## 📌 Tecnologias Utilizadas

- .NET 8
- ASP.NET Core Web API
- Entity Framework Core
- Entity framework Core Design
- MySQL
- Pomelo.EntityFrameworkCore.MySql
- Swagger (OpenAPI)

---

## 📁 Estrutura do Projeto

```
EmpresaAPI
│
├── Application
│   └── FuncionariosController.cs
│
├── Domain
│   ├── Entites
│   │   └── Funcionarios.cs
│   ├── Interfaces
│   │   └── IFuncionariosRepository.cs
│   └── Services
│       └── FuncionariosServices.cs
│
├── Infrastructure
│   ├── Data
│   │   └── AppDbContext.cs
│   └── FuncionariosRepository.cs
│
├── Migrations
├── Program.cs
├── appsettings.json
└── EmpresaAPI.csproj
```

---

## ⚙️ Pré-requisitos

Antes de executar o projeto, certifique-se de ter instalado:

- **.NET SDK 8.0+**
- **MySQL Server** (8.0 ou superior)
- **DBeaver** ou outro cliente MySQL (opcional)

Verifique o SDK:
```
dotnet --info
```

---

## 🔐 Configuração do Banco de Dados

Edite o arquivo **`appsettings.json`** e configure a connection string:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost;Database=empresa_db;User=root;Password=sua_senha;"
}
```

---

## 📦 Restaurar Dependências

```
dotnet restore
```

---

## 🧱 Executar Migrations

```
dotnet ef database update
```

Caso ainda não exista migration:
```
dotnet ef migrations add InitialCreate
dotnet ef database update
```

---

## ▶️ Executar a Aplicação

```
dotnet run
```

A API ficará disponível em:

```
http://localhost:5024
```

---

## 📑 Swagger

Acesse no navegador:

```
http://localhost:5024/swagger
```

---

## 📌 Endpoints Principais

| Método | Rota                          | Descrição                   |
|------|-------------------------------|-----------------------------|
| GET  | /api/v1/Funcionarios          | Lista funcionários          |
| POST | /api/v1/Funcionarios          | Cadastra funcionário        |
| PUT  | /api/v1/Funcionarios/{id}     | Atualiza funcionário        |
| DELETE | /api/v1/Funcionarios/{id}  | Remove funcionário          |

---

## 👨‍💻 Autor

Projeto desenvolvido para fins de estudo em ASP.NET Core e Entity Framework Core.
