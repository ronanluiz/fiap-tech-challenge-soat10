## Descrição

Uma breve descrição sobre o que é o projeto, sua finalidade e o problema que ele resolve.

## Objetivos

-**Objetivo 1**: Descrever um dos principais objetivos do projeto.

## Organização do projeto

### Domain

Este projeto contém a lógica central do domínio, seguindo as regras de negócio. Ele é **independente de qualquer tecnologia ou infraestrutura** .

```
Domain/
|-- Aggregates/       # Agregados e agregados-raiz
|-- Base/             # Classes base de domain (ex.: Entity, AggragateRoot, ValueObject, etc)
|-- Entities/         # Classes principais do domínio
|-- ValueObjects/     # Objetos de valor do domínio
|-- Interfaces/       # Interfaces do domínio (ex.: repositórios)
|-- Events/           # Eventos de domínio
|-- Exceptions/       # Exceções específicas do domínio
|-- Services/         # Serviços de domínio (para lógica complexa)

```

### Application

Este projeto contém casos de uso (Application Services) e a interação entre o domínio e o mundo externo. Ele é responsável por orquestrar as chamadas para os componentes do domínio.

```
Application/
|-- UseCases/           # Casos de uso (uma pasta por caso de uso) com suas respectivas interface, classe de implementação e classe que representes o comando
|   |-- <UseCaseFolder>/   
|       |-- <UseCaseInterface>  
|       |-- <UseCaseClass>   
|       |-- <UseCaseCommand>   
|-- Mappers/            # Mapeamento entre Commands e Entities
|-- Exceptions/         # Exceções específicas da aplicação

```

### Infrastructure

Este projeto lida com a implementação de interfaces externas (adapters) e detalhes específicos de infraestrutura, como persistência e serviços externos.

```
Infrastructure/
|-- Persistence/
|   |-- Context/         # DbContext (Entity Framework ou outro ORM)
|   |-- Repositories/    # Implementações de repositórios
|-- ExternalServices/    # Comunicação com APIs externas
|-- Logging/             # Configurações de logging
|-- Configurations/      # Mapeamentos e configurações

```

### API

O projeto da API expõe os endpoints e configurações específicas para comunicação com o mundo externo. É o principal ponto de entrada da aplicação.

```
API/
|-- Controllers/        # Controladores da API
|-- Filters/            # Filtros globais (ex.: validação e erros)
|-- Middlewares/        # Middlewares customizados
|-- Configurations/     # Configurações da API (CORS, Swagger, etc.)
|-- DependencyInjection/ # Registro de serviços e injeções

```

### Regras

- Domain: não referencia nenhuma outra camada.
- Application: referencia apenas o Domain.
- Infrastructure: referencia o Domain e Application e implementa interfaces declaradas neles.
- API: referencia o Application e o Infrastructure.
- Entities: nem toda entidade vai possuir um id. O ideal é que somente entidades de sejam AggragateRoot, e que, na grande partes do casos, serão persitistidos, tenham um id único.

## Tecnologias e Configurações utilizadas

* **Framework:** .NET 8 devido a maior longeviade de suporte da Microsoft. Referência: [.Net Support Policy](https://dotnet.microsoft.com/en-us/platform/support/policy)
* **ORM**: Entity Framework Core.
* **Injeção de Dependência**: `Microsoft.Extensions.DependencyInjection`.
* **Documentação**: Swagger/OpenAPI.
* **Validação** : FluentValidation.
* **Banco de Dados**: PostgreSQL.
* **Docker:** Utilizado para containerização da aplicação.
* **Docker Compose**: Utilizado para permitir a execução da aplicação localmente com orquestração da execução e inicialização do banco de dados local já sendo populado com alguns dados para permitir a execução da aplicação.

## Pré-requisitos

Antes de começar, você vai precisar ter instalado em sua máquina:

- .Net 8
- Para sistema operacional Windows: WSL2
- Docker e Docker Compose

## Instruções para Iniciar o Projeto Localmente

Siga os passos abaixo para rodar o projeto na sua máquina:

1 - Execute do docker compose para orquestrar o inicio da aplicação com o banco de dados à partir ddo diretório raiz da aplicação

```bash
docker-compose up
```

