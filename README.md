# 🏥 SGHSS.API

Sistema de Gestão Hospitalar e Serviços de Saúde

## 📌 Sobre o projeto

A **SGHSS.API** é uma API REST desenvolvida em **.NET** com o objetivo de simular um sistema de gestão hospitalar
utilizando como prinicipal linguagens o **C#**.

O projeto permite:

* Cadastro de pacientes
* Autenticação de usuários com JWT
* Controle de acesso às rotas
* Operações CRUD (Create, Read, Update, Delete)

A arquitetura segue boas práticas utilizadas em sistemas reais, separando responsabilidades em camadas.

---

## 🏗️ Arquitetura do projeto

O projeto foi organizado seguindo uma estrutura em camadas:

```
Application     → Controllers (entrada da API)
Domain          → Entidades, Interfaces e Regras de negócio
Infrastructure  → Banco de dados e Repositórios
```

### 📂 Estrutura

```
SGHSS.API
│
├── Application
│   ├── PacientesController.cs
│   └── AuthController.cs
│
├── Domain
│   ├── Entites
│   │   ├── Pacientes.cs
│   │   └── Usuario.cs
│   │
│   ├── Interfaces
│   │   └── IPacientesRepository.cs
│   │
│   └── Services
│       ├── PacientesServices.cs
│       └── AuthService.cs
│
├── Infrastructure
│   ├── Data
│   │   └── AppDbContext.cs
│   │
│   └── Repository
│       └── PacientesRepository.cs
│
├── wwwroot
│   └── sghss-interface.html   ← interface gráfica
│
└── Program.cs
```

---

## 🖥️ Interface Gráfica

O projeto conta com uma interface web moderna que permite utilizar todas as funcionalidades da API sem precisar do Swagger.

### ✅ Funcionalidades da interface

* Tela de login e cadastro de usuário
* Dashboard com estatísticas dos pacientes (total, sexo, idade média)
* Listagem de pacientes em tabela com busca em tempo real
* Cadastro, edição e remoção de pacientes via modais
* Feedback visual com notificações de sucesso e erro
* Campo configurável para URL da API

### 📥 Como instalar a interface

**1. Habilitar arquivos estáticos no `Program.cs`**

Adicione a linha `app.UseStaticFiles()` antes de `app.MapControllers()`:

```csharp
app.UseAuthentication();
app.UseAuthorization();

app.UseStaticFiles(); // ← adicionar esta linha

app.MapControllers();
app.Run();
```



**2. Executar a aplicação normalmente**

```
dotnet run
```

**3. Acessar a interface no navegador**

```
http://localhost:5024/sghss-interface.html

*Linguagens Utilidas na interface HTML+CSS & JavaScript
```

> A URL da API pode ser ajustada diretamente no campo exibido na tela de login, caso o projeto rode em outra porta.

---

## 🔐 Autenticação com JWT

O sistema utiliza **JWT (JSON Web Token)** para autenticação.

### Fluxo:

1. Usuário se cadastra
2. Usuário faz login
3. API gera um token JWT
4. O token é usado para acessar rotas protegidas

---

## 🚀 Funcionalidades

### 🔑 Autenticação

| Método | Rota                    | Descrição                |
| ------ | ----------------------- | ------------------------ |
| POST   | `/api/v1/auth/register` | Cadastrar usuário        |
| POST   | `/api/v1/auth/login`    | Login e geração de token |

---

### 👤 Pacientes (Protegido por JWT)

| Método | Rota                     | Descrição          |
| ------ | ------------------------ | ------------------ |
| GET    | `/api/v1/pacientes`      | Listar pacientes   |
| POST   | `/api/v1/pacientes`      | Cadastrar paciente |
| PUT    | `/api/v1/pacientes/{id}` | Atualizar paciente |
| DELETE | `/api/v1/pacientes/{id}` | Remover paciente   |

---

## 🛠️ Tecnologias utilizadas

* .NET 9
* ASP.NET Core
* Entity Framework Core
* MySQL
* JWT Authentication
* Swagger (OpenAPI)

---

## ⚙️ Como executar o projeto

### 1️⃣ Clonar o repositório

```
git clone https://github.com/Rickelmy365/EmpresaAPI.git
```

---

### 2️⃣ Acessar a pasta do projeto

```
cd SGHSS.csproj
```

---

### 3️⃣ Configurar o banco de dados

No arquivo `appsettings.json`, configure a string de conexão:

```json
"ConnectionStrings": {
  "DefaultConnection": "server=localhost; Port=3306;database=empresa_db; User=root; Password=root;"
}
```

---

### 4️⃣ Criar o banco com migrations

```
dotnet ef migrations add InitialCreate
dotnet ef database update
```

---

### 5️⃣ Executar a aplicação

```
dotnet run
```

---

### 6️⃣ Acessar a interface gráfica

```
http://localhost:5024/sghss-interface.html
```

### 6️⃣ Ou acessar o Swagger

```
http://localhost:5024/swagger
```

---

## 🔐 Como usar autenticação

### 1. Registrar usuário

```
POST /api/v1/auth/register
```

Exemplo:

```
email: admin@sghss.com
senha: 123456
```

---

### 2. Fazer login

```
POST /api/v1/auth/login
```

Retorno:

```json
{
  "token": "SEU_TOKEN_AQUI"
}
# Obs: na interface entra automaticamente #
```

---

### 3. Usar token nas requisições

Adicionar no Header:

```
Authorization: Bearer SEU_TOKEN
```

---

## 📌 Melhorias futuras

* Criptografia de senha (BCrypt)
* Cadastro de médicos
* Sistema de consultas
* Prontuário eletrônico
* Controle de permissões por perfil

---

## 👨‍💻 Autor

Desenvolvido por **Rickelmy Ferreira de Souza Ribeiro**
Estudante de Análise e Desenvolvimento de Sistemas

--------------Trabalho final de ADS---------------------
