# EduPay

## O que é o EduPay

EduPay é um sistema backend desenvolvido em **.NET/C#**, estruturado com **Entity Framework Core**, **SQL Server** e **Clean architecture**.  
O projeto gerencia entidades como Aluno, Curso, Pagamento e Matricula, utilizando DTOs, AutoMapper, Repositories e Services para manter o código limpo, desacoplado e fácil de manter.

---

## Caso de Uso do Projeto

### EduPay – Gestão de Cursos e Pagamentos Educacionais
**Conceitos Utilizados:**

- **Polimorfismo**  
  Implementado com as classes `CursoPresencial` e `CursoOnline`, ambas herdando de `Curso`, cada uma com propriedades específicas.

- **LINQ para relatórios financeiros**  
  Utilizado para consultas como:
  - Total pago por aluno  
  - Receita por curso  
  - Filtros de pagamentos por data  
  - Relatórios agregados usando `Sum`, `GroupBy`, `Select`, etc.

Esses recursos reforçam o aprendizado de:
- Arquitetura limpa (Service + Repository)
- Modelos de domínio com herança
- Boas práticas com EF Core
- Consultas avançadas em LINQ  
- DTOs + AutoMapper
- SQL Server com Migrations
  
---

## Pacotes NuGet Utilizados

### Mapeamento
- AutoMapper — `12.0.1`
- AutoMapper.Extensions.Microsoft.DependencyInjection — `12.0.1` *(preterido)*

### Entity Framework Core
- Microsoft.EntityFrameworkCore — `9.0.0`
- Microsoft.EntityFrameworkCore.SqlServer — `9.0.0`
- Microsoft.EntityFrameworkCore.Design — `9.0.0`
- Microsoft.EntityFrameworkCore.Tools — `9.0.0`

### Code Generation
- Microsoft.VisualStudio.Web.CodeGeneration.Design — `8.0.7`

---

## Tecnologias Principais

- **.NET 8 / C#**
- **Entity Framework Core 9**
- **SQL Server**
- **AutoMapper**
- **Dependency Injection**
- **Migrations EF Core**
- **Clean architecture**: Domain • Infrastructure • Application

---

## Como Rodar o Projeto

### ✔ Pré-requisitos

- .NET SDK 8 instalado  
- String de conexão configurada no `appsettings.json`  
- EF Core CLI ou Package Manager Console disponível  

---

## Executando o Projeto

### 1️⃣ Clonar o repositório
```bash
git clone https://github.com/GustavoMarques06/EduPay.git
```
Entrar no projeto
```bash
cd EduPay
 ```

### 3️⃣ Criar a migration inicial
Esse comando deve ser rodado no Package Manager Console do Visual Studio:    
```bash
Add-Migration inicial
```
Ou pela CLI:
```bash
dotnet ef migrations add InitialCreate
```
4️⃣ Atualizar o banco de dados
No Package Manager Console:
```bash
Update-Database
```
Ou pela CLI:
```bash
dotnet ef database update
```
5️⃣ Rodar a API
```bash
dotnet run
```
