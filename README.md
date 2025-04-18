# API de Controle de Estoque (.NET 8) - Nível 1

Uma API RESTful básica desenvolvida com ASP.NET Core 8 para gerenciar produtos e seus movimentos de estoque. Representa a fase inicial de implementação (Nível 1), focando na estrutura principal e funcionalidade usando um banco de dados Em Memória para desenvolvimento e testes iniciais.

## 🚧 Status do Projeto: Nível 1 Completo 🚧

Esta versão fundamental implementa:

*   **Estrutura Principal:** Utiliza um padrão de arquitetura em camadas (Controllers -> Services -> Repositories).
*   **Acesso a Dados:** Usa Entity Framework Core com o provedor de banco de dados **Em Memória** (`Microsoft.EntityFrameworkCore.InMemory` v8.0.0) para esta fase inicial. Os dados persistirão apenas durante o ciclo de vida da aplicação.
*   **Mapeamento de Objetos:** Utiliza **AutoMapper** (`v10.1.1` e `AutoMapper.Extensions.Microsoft.DependencyInjection v8.1.1`) para mapear entre Entidades e DTOs.
*   **CRUD Básico:** Implementa operações fundamentais de Criar, Ler, Deletar (Create, Read, Delete) para Produtos e Movimentos de Estoque.
*   **Documentação da API:** Integra Swagger (Swashbuckle) para uma interface clara de documentação e teste da API.

**Nota:** O foco deste nível foi estabelecer a arquitetura principal e as operações básicas. Funcionalidades como operações de Atualização (Update), integração com banco de dados persistente (SQL Server, PostgreSQL, etc.), cálculos avançados de estoque, autenticação de usuário, tratamento de erros abrangente e logging detalhado estão planejadas para níveis futuros de desenvolvimento.

## ✨ Funcionalidades (Nível 1)

*   **Produtos:**
    *   Listar todos os produtos (incluindo seus movimentos de estoque).
    *   Obter um produto específico por ID.
    *   Criar um novo produto (definindo SKU, Nome, Descrição).
    *   Deletar um produto por ID.
*   **Movimentos de Estoque:**
    *   Obter um movimento de estoque específico por ID.
    *   Criar um novo movimento de estoque (Entrada, Saída, Ajuste) para um produto existente.
    *   Deletar um movimento de estoque por ID.

## 🛠️ Tecnologias & Pacotes Utilizados (Nível 1)

*   **.NET 8.0**
*   **ASP.NET Core 8.0**
*   **Entity Framework Core 8.0**
    *   `Microsoft.EntityFrameworkCore.InMemory` (v8.0.0) - *Para Banco de Dados Em Memória*
*   **AutoMapper**
    *   `AutoMapper` (v10.1.1)
    *   `AutoMapper.Extensions.Microsoft.DependencyInjection` (v8.1.1)
*   **Swagger / OpenAPI**
    *   `Swashbuckle.AspNetCore` (v6.4.0)

## 📋 Pré-requisitos (Nível 1)

*   .NET SDK 8.0
*   Git
*   Um IDE (Ambiente de Desenvolvimento Integrado) como Visual Studio ou VS Code (opcional, mas recomendado)
*   *(Nenhum servidor de banco de dados externo é necessário para esta configuração inicial Em Memória)*

## 🚀 Como Começar (Nível 1)

Siga estes passos para ter o projeto rodando localmente:

1.  **Clonar o repositório:**
    ```bash
    git clone [URL DO SEU REPOSITÓRIO NO GITHUB]
    cd [NOME DA PASTA DO SEU PROJETO]
    ```

2.  **Executar a Aplicação:**
    *   *(Configuração de banco de dados e migrações NÃO são necessárias ao usar o provedor Em Memória).*
    *   **Usando .NET CLI:**
        ```bash
        dotnet run
        ```
    *   **Usando Visual Studio:**
        *   Abra o arquivo `.sln`.
        *   Pressione `F5` ou clique no botão "Iniciar".

3.  **Acessar a API:**
    *   A aplicação geralmente iniciará em `https://localhost:[PORTA]` (ex: `https://localhost:7092`) ou `http://localhost:[PORTA]`. Verifique a saída do console para a URL exata.
    *   Acesse a UI do Swagger para documentação interativa e testes: `https://localhost:[PORTA]/swagger/index.html`

## 🕹️ Uso da API / Endpoints (Nível 1)

A principal forma de explorar e testar os endpoints da API é através da **UI do Swagger**, disponível em `/swagger/index.html` quando a aplicação está rodando.

**Endpoints Principais (Nível 1):**

*   **Produtos:**
    *   `GET /api/product`: Recupera uma lista de todos os produtos (incluindo seus movimentos de estoque).
    *   `GET /api/product/{id}`: Recupera um produto específico pelo seu ID.
    *   `POST /api/product`: Cria um novo produto. Requer um corpo de requisição (ver estrutura `CreateProductDTO` - provavelmente `sku`, `name`, `description`).
    *   `DELETE /api/product/{id}`: Deleta um produto pelo seu ID.
*   **Movimentos de Estoque:**
    *   `GET /api/stockmovement/{id}`: Recupera um movimento de estoque específico pelo seu ID.
    *   `POST /api/stockmovement`: Cria um novo movimento de estoque. Requer um corpo de requisição (ver estrutura `CreateStockMovementDTO` - provavelmente `productId`, `type`, `quantity`, `movementDate`, `reason` opcional, `batchNumber`).
    *   `DELETE /api/stockmovement/{id}`: Deleta um movimento de estoque pelo seu ID.

## ⚙️ Configuração (Nível 1)

*   **Banco de Dados:** Atualmente configurado em `Program.cs` para usar `UseInMemoryDatabase("NomeDoSeuBanco")`. Os dados não são persistidos entre execuções da aplicação.
*   **CORS:** *(Deve ser configurado em `Program.cs` para interação com o frontend).*

---

## 🌱 Desenvolvimento Futuro / Próximos Níveis 🚀

Este projeto está planejado para evoluir. Próximos passos e melhorias potenciais incluem:

*   **Nível 2: Banco de Dados Persistente & Melhorias Essenciais**
    *   **Migração de Banco de Dados:** Transição do banco de dados Em-Memória para um banco de dados relacional persistente como **SQL Server** usando **Entity Framework Core (ORM)**. Implementar migrações (migrations) de banco de dados.
    *   **Operações de Atualização:** Implementar endpoints `PUT` ou `PATCH` para atualizar Produtos e potencialmente Movimentos de Estoque (se as regras de negócio permitirem).
    *   **Validação Avançada:** Integrar a biblioteca **FluentValidation** para regras de validação mais robustas, testáveis e expressivas nos DTOs, substituindo/complementando as Data Annotations.
    *   **Tratamento de Erros Refinado:** Implementar middleware global de tratamento de exceções para respostas de erro consistentes e amigáveis ao usuário.
    *   **Cálculo Básico de Estoque:** Adicionar lógica no serviço ou métodos no repositório para calcular o nível de estoque atual de um produto com base em seus movimentos.

*   **Nível 3: Lógica de Negócio & Testes**
    *   **Regras de Negócio Avançadas:** Implementar lógica mais complexa (ex: impedir que o estoque fique negativo em movimentos de saída, lidar com expiração de lotes - FEFO/PEPS).
    *   **Testes Unitários:** Adicionar testes unitários para Serviços e potencialmente Controllers usando frameworks como xUnit ou NUnit e bibliotecas de mock (ex: Moq).
    *   **Testes de Integração:** Implementar testes de integração para verificar a interação entre diferentes camadas, potencialmente usando `WebApplicationFactory` e uma instância de banco de dados de teste.
    *   **Logging:** Integrar um framework de logging robusto (ex: Serilog) para registrar eventos e erros da aplicação de forma eficaz.

*   **Nível 4: Segurança & Implantação (Deployment)**
    *   **Autenticação & Autorização:** Implementar autenticação de usuário (ex: tokens JWT Bearer) e políticas de autorização para proteger os endpoints.
    *   **Gerenciamento de Configuração:** Melhorar o tratamento de configurações usando o padrão `IOptions` e configurações específicas por ambiente.
    *   **Prontidão para Produção:** Refinamentos gerais, otimizações de performance, e health checks.
    *   **Dockerização:** Empacotar a aplicação em um contêiner Docker para facilitar a implantação e portabilidade.

---

## 👤 Autor

*   **Felipe Melo** - *Trabalho inicial*

---
