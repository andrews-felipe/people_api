# Projeto CRUD API Simples .NET Core 3, C#

_Este projeto é para fins didáticos e avaliativos_

Esse projeto é a camada BackEnd do projeto "CRUD PESSOA"

CRUD simples da entidade pessoa:

## Paths

| Método HTTP | Path               | Recurso                     |
| ----------- | ------------------ | --------------------------- |
| GET         | `/api/pessoas`     | Listar Pessoas              |
| POST        | `/api/pessoas`     | Cadastrar nova Pessoa       |
| PUT         | `/api/pessoas{id}` | Alterar dados de uma Pessoa |
| DELETE      | `/api/pessoas{id}` | Excluir Pessoa              |

## Modelos
### People

| Nome  | Tipo     | Validação       |
| ----- | -------- | --------------- |
| Name  | `string` | Required        |
| Email | `string` | Required, Regex |
| Phone | `long`   | Required        |


# Conceitos

- **Models** Modelagem de entidades para mapeamento de objetos;
- **Controllers** Terminais Roteadores, recebem e retornam a requisição a nível de aplicação;
- **Context** Manipulação automática do banco de dados via querys padrões com os modelos criados;
