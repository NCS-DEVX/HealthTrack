# HealthTrack

**HealthTrack** é um sistema de gestão simples para um consultório médico, desenvolvido em **ASP.NET Core MVC** e **Entity Framework Core** com banco de dados SQL Server.

Permite o gerenciamento de:

- Médicos
- Pacientes
- Consultas (futuramente)

## Funcionalidades

✅ Tela de Login com autenticação básica  
✅ Menu de navegação (Home, Médicos, Pacientes)  
✅ Listagem de Médicos  
✅ Listagem de Pacientes  
✅ Cadastro de Médicos  
✅ Cadastro de Pacientes  
✅ Edição e Exclusão de Pacientes e Médicos (em desenvolvimento)  
✅ Layout responsivo com **Bootstrap 5**

## Tecnologias Utilizadas

- [.NET 9.0](https://dotnet.microsoft.com/en-us/download/dotnet/9.0)
- ASP.NET Core MVC
- Entity Framework Core
- SQL Server
- Bootstrap 5

## Estrutura do Projeto

```
/Controllers
  - AccountController.cs
  - HomeController.cs
  - PacienteController.cs
  - MedicoController.cs
/Models
  - Paciente.cs
  - Medico.cs
  - Consulta.cs
/Data
  - HealthTrackContext.cs
/Views
  /Home
    - Index.cshtml
  /Paciente
    - Index.cshtml
    - Create.cshtml
    - Edit.cshtml (em construção)
  /Medico
    - Index.cshtml
    - Create.cshtml
/Views/Shared
  - _Layout.cshtml
```

## Como Executar

1. Clone o repositório:

```bash
git clone https://github.com/NCS-DEVX/HealthTrack.git
```

2. Abra a pasta do projeto:

```bash
cd HealthTrack
```

3. Restaure os pacotes NuGet:

```bash
dotnet restore
```

4. Atualize o banco de dados (caso tenha alterações):

```bash
dotnet ef database update
```

5. Execute a aplicação:

```bash
dotnet run
```

A aplicação estará disponível em:

```text
http://localhost:5126
```

## Usuário de Teste

- **Usuário:** admin  
- **Senha:** admin123

## Observações

- O sistema ainda está em desenvolvimento (MVP).  
- A autenticação é simples (não usa Identity ainda).  
- A tela de Consultas será adicionada nas próximas versões.

## To-Do

- [ ] CRUD completo de Médicos e Pacientes  
- [ ] Tela de Consultas  
- [ ] Filtros e pesquisa avançada  
- [ ] Relatórios PDF  
- [ ] Implementar autenticação com Identity  
- [ ] Testes unitários

## Licença

Este projeto é de uso pessoal e acadêmico.
