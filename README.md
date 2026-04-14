# cpll — CRUD de alunos (WPF + MySQL)

**Autor:** guuii

Aplicação desktop **.NET 8** (WPF) que se conecta ao **MySQL** para cadastrar, listar, atualizar e excluir registros na tabela de alunos.

---

## Banco e tabela

| Item | Valor |
|------|--------|
| **SGBD** | MySQL |
| **Nome do banco** | **`escola`** — o nome usado no MySQL deve ser o **mesmo** valor que você gravar nos *user secrets* na chave **`database`** (veja seção abaixo). |
| **Tabela** | `alunos` |

Colunas usadas pelo projeto: `id` (auto incremento), `nome`, `email`, `idade`.

Exemplo de criação do banco **`escola`** e da tabela:

```sql
CREATE DATABASE IF NOT EXISTS escola
  CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci;

USE escola;

CREATE TABLE alunos (
  id INT UNSIGNED NOT NULL AUTO_INCREMENT,
  nome VARCHAR(200) NOT NULL,
  email VARCHAR(255) NOT NULL,
  idade INT UNSIGNED NOT NULL,
  PRIMARY KEY (id),
  UNIQUE KEY uk_alunos_email (email)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
```

---

## Pré-requisitos

- [.NET 8 SDK](https://dotnet.microsoft.com/download)
- Servidor **MySQL** em execução (ex.: localhost)
- Banco **`escola`** e tabela **`alunos`** criados conforme o script acima

---

## Credenciais (User Secrets)

O **nome do banco de dados** não fica no código-fonte: ele é informado pelo **User Secret** com a chave **`database`**.

O projeto lê usuário, senha, nome do banco e porta via **User Secrets** (não commitar senha no repositório). O servidor está fixo em código como `localhost`; o restante vem das chaves abaixo.

Na pasta do projeto (`cpll`), execute (exemplo usando o banco **`escola`**):

```bash
dotnet user-secrets set "database" "escola"
dotnet user-secrets set "user" "seu_usuario_mysql"
dotnet user-secrets set "password" "sua_senha_mysql"
dotnet user-secrets set "Port" "3306"
```

| Chave | Descrição |
|-------|-----------|
| **`database`** | **Nome do banco MySQL** (neste projeto o exemplo é **`escola`** — deve ser idêntico ao `CREATE DATABASE`). |
| `user` | Usuário MySQL |
| `password` | Senha do usuário |
| `Port` | Porta (opcional; se omitida, o código usa `3306`) |

> **Nota:** O `UserSecretsId` está no `.csproj`. Os secrets ficam na máquina do desenvolvedor, não no arquivo do projeto.

---

## Como rodar

No diretório do projeto:

```bash
dotnet restore
dotnet run
```

Ou abra a solução `cpll.sln` no Visual Studio e execute (F5).

---

## Resumo rápido

1. Crie o banco **`escola`** e a tabela **`alunos`** no MySQL.  
2. Defina o nome do banco nos secrets: `dotnet user-secrets set "database" "escola"` (e `user`, `password`, opcionalmente `Port`).  
3. Execute `dotnet run`.

Se a conexão falhar, confira se o MySQL está ativo, se o banco **`escola`** existe e se o valor de **`database`** nos secrets é exatamente esse nome.
