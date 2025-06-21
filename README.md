# Api-Auth

API de autenticação desenvolvida em C# (.NET 8) com integração ao MongoDB. Tem como objetivo fornecer endpoints seguros para cadastro, autenticação e gerenciamento de usuários, utilizando JWT para autenticação e Docker para facilitar o deploy.

## Funcionalidades

- Cadastro de usuários
- Autenticação de usuários com retorno de JWT
- Endpoints protegidos por autenticação
- Registro e consulta de informações de usuário
- Logging configurável por ambiente

## Tecnologias Utilizadas

- **C# (.NET 8)**
- **MongoDB** (armazenamento dos usuários)
- **JWT** (autenticação)
- **Docker** (containerização)

## Como Executar Localmente

### Pré-requisitos

- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download)
- [Docker](https://www.docker.com/) (opcional, mas recomendado)
- Instância do MongoDB rodando (local ou na nuvem)

### Clonando o repositório

```bash
git clone https://github.com/MikaelRagna/Api-Auth.git
cd Api-Auth
```

### Configuração de Variáveis de Ambiente

Você pode definir as variáveis diretamente ou alterar os arquivos de configuração:

- `DATABASE_HOST` — host do MongoDB (padrão: localhost)
- `DATABASE_PORT` — porta do MongoDB (padrão: 27017)
- `DATABASE_USER` — usuário do MongoDB (exemplo: root_mongodb)
- `DATABASE_PASS` — senha do MongoDB (exemplo: Mongo1*db)
- `SECRET_KEY` — chave secreta para geração de JWT

Essas variáveis podem ser alteradas no docker-compose.override.yml, launchSettings.json ou exportadas no ambiente.

### Rodando com Docker

```bash
docker build -t api-auth .
docker run -p 8080:80 \
  -e DATABASE_HOST=localhost \
  -e DATABASE_PORT=27017 \
  -e DATABASE_USER=root_mongodb \
  -e DATABASE_PASS=Mongo1*db \
  -e SECRET_KEY=SuaChaveSecreta \
  api-auth
```

### Rodando Localmente

```bash
dotnet run --project Api-Auth
```

A aplicação ficará disponível em `http://localhost:5048` ou conforme configurado.

## Endpoints Principais

- `POST /register` — Cadastro de novo usuário
- `POST /login` — Autenticação (retorna JWT)
- `GET /user` — Consulta informações do usuário autenticado (JWT necessário)

## Exemplo de Estrutura de Usuário

```json
{
  "firstName": "João",
  "lastName": "Silva",
  "email": "joao@email.com",
  "passCrypt": "hashSenha",
  "dateRegister": "2025-06-21T00:00:00Z"
}
```

## Sobre o Banco de Dados

O projeto utiliza MongoDB, acessando a base `ApiAuth` e a coleção `Users`. A string de conexão é montada dinamicamente com as variáveis de ambiente.

## Documentação e Testes

Acesse `/swagger` após subir o projeto para testar todos os endpoints via Swagger UI.

## Licença

MIT

---


