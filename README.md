
# Authentication API

Este projeto visa demonstrar a implementação de um sistema de autenticação de usuários, permitindo o registro, login e comunicação de forma autenticada com o front-end via Bearer token.


## Aviso importante

Este repositório é somente a parte do back-end do projeto. Para funcionar do modo esperado, deve-se executar também a API que se encontra neste repositório: https://github.com/leopholdo/authentication-app


## Funcionalidades

- **Registro de usuários** persistindo os dados em banco ou memória
- **Criptografia de password** com BCrypt
- **Validações de dados de usuários** em camadas diferentes
- **Autenticação de usuários**
- **Comunicação com API** de forma anônima e autenticada via Bearer token
- **Implementação de uma API segura** por CORS, autenticação e autorização com JWT e Bearer


## Tecnologias utilizadas

**Front-end:** VueJS e Vuetify

**Back-end:** ASP.NET Core 8, Swagger UI, Entity Framework Core, BCrypt, e Authentication JwtBearer

**Banco de dados:** PostgreSQL


## Como usar

1. **Configuração do ambiente:**
- Clone e configure o repositório do front-end [que se encontra neste link](https://github.com/leopholdo/authentication-app);
- Certifique-se de ter o .NET SDK 8 instalado em sua máquina. Você pode baixar a versão mais recente [neste link](https://dotnet.microsoft.com/pt-br/download).
- Clone este repositório;
- Execute o comando abaixo para restaurar os pacotes e dependências do projeto:
```
dotnet restore
```

2. **Configuração do Banco de dados**
**InMemory Database:**
- Abra o arquivo **Program.cs**
- Descomente da linha 17 a 19;
- Comente da linha 22 a 24;

**PostgreSQL:**
- Abra o arquivo **Program.cs**
- Comente da linha 17 a 19;
- Descomente da linha 22 a 24;
- Certifique-se de ter o ambiente PostgreSQL configurado na sua máquina;
- Abra o arquivo **appsettings.json** e edite a **ConnectionString** com as credenciais do seu ambiente PostgreSQL;
- Aplique as Migrações do Banco de Dados com o comando: 
```
dotnet ef database update

```

3. **Execução do Projeto:**
- Execute o projeto com o comando 
```
dotnet run
```

## Acesso ao projeto
**Com a aplicação front-end**
- Execute o projeto APP com o comando 
```
npm run dev
```
Ou se preferir com o YARN,
```
yarn dev
```
- Abra o navegador e acesse a aplicação pelo endereço http://localhost:5101

**Swagger-UI** (somente em DEV)
- Abra o navegador e acesse o Swagger pelo endereço http://localhost:5398/swagger/index.html

## Contribuindo

Contribuições são sempre bem-vindas!

Se você encontrar algum problema ou tiver sugestões, sinta-se à vontade para abrir uma [issue](https://github.com/leopholdo/authentication-api/issues/new) ou enviar um [pull request](https://github.com/leopholdo/authentication-api/pulls).