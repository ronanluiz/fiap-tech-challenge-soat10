## Descrição

O projeto visa desenvolver um sistema de autoatendimento para uma lanchonete em expansão que está enfrentando desafios no controle de pedidos. O sistema gerenciará todo o fluxo, desde o pedido inicial até a entrega, incluindo:

- Autoatendimento com identificação opcional do cliente
- Gestão de pedidos
- Acompanhamento em tempo real do status do pedido
- Gerenciamento administrativo de produtos, clientes e pedidos
- Gestão de pagamentos(Implementação posterior a versão 1.0.0)

## Objetivos

- **Desenvolvimento da Solução**: Criar uma aplicação completa de autoatendimento que inclui:
  - Sistema de pedidos com categorias definidas (Lanche, Acompanhamento, Bebida, Sobremesa)
  - Painel de acompanhamento de pedidos
  - Interface administrativa para gestão(Implementação posterior a versão 1.0.0)
  - Integração com sistema de pagamento(Implementação posterior a versão 1.0.0)
- **Entregas Técnicas**:
  - Documentação completa usando DDD e Event Storming
  - Desenvolvimento de APIs RESTful
  - Implementação usando arquitetura hexagonal
  - Ambiente containerizado com Docker
  - Banco de dados para gestão de pedidos

## Organização do projeto

### Domain

Este projeto contém a lógica central do domínio, seguindo as regras de negócio. Ele é **independente de qualquer tecnologia ou infraestrutura** .

```
Domain/
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
|-- DTOs/                     # Classes utilizadas nas interfaces de aplicação
|-- Interfaces/               # Interfaces de aplicação (ex.: serviços externos)
|-- UseCases/                 # Casos de uso (uma pasta por caso de uso) com suas respectivas interface, classe de implementação e classe que representes o comando
|   |-- <UseCaseFolder>/   
|       |-- <UseCaseInterface>  
|       |-- <UseCaseClass>   
|       |-- <UseCaseRequest>
|       |-- <UseCaseResponse>
|-- Exceptions/               # Exceções específicas da aplicação
|-- ApplicationBootstrapper  # Classe responsável pelo mapeamento e configuração para injeção das dependências

```

### Infrastructure

Este projeto lida com a implementação de interfaces externas (adapters) e detalhes específicos de infraestrutura, como persistência e serviços externos.

```
Infrastructure/
|-- Persistence/
|   |-- Context/                # DbContext (Entity Framework ou outro ORM)
|   |-- Repositories/           # Implementações de repositórios
|-- ExternalServices/           # Comunicação com APIs externas
|-- InfrastructureBootstrapper  # Classe responsável pelo mapeamento e configuração para injeção das dependências
```

### API

O projeto da API expõe os endpoints e configurações específicas para comunicação com o mundo externo. É o principal ponto de entrada da aplicação.

```
API/
|-- Controllers/        # Controladores da API que expôem os endpoints
|-- Middlewares/        # Middlewares customizados que interceptam as requisições dos endpoints

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
docker-compose up --build
```

2 - Após validar que a aplicação subiu sem erros, acessar a seguinte url no browser para listagem do swagger de todos os endpoints disponíveis:

[http://localhost:8080/swagger](http://localhost:8080/swagger)

### Outros comandos
- Para cenários onde for necessário eliminar as instências dos conteiners da aplicação incluindo o processo de reiniciar o banco de dados ou limpar os dados iniciais carregados executar o seguinte comando:

```bash
docker-compose down --volumes
```

## Rodando com o Kubernetes

1 - Pré-requisitos:
- Verifique se você possui o kubectl instalado e configurado
```bash
kubectl version
```
- Certifique-se de ter um cluster Kubernetes disponível (via Minikube, GKE, AKS, DockerHub, etc...)
```bash
kubectl cluster-info
```

2 - Aplicar as configurações no Kubernetes:
Primeiramente, você precisará aplicar os manifests YML do Kubernetes (Deployment, Service, ConfigMap, etc.). 
No diretório do projeto, execute o script para aplicar as configurações: 

```bash
./deploy.sh
```

3 - Valide que tudo funcionou sem problemas com os comandos:
```bash
kubectl get all
```

Com esse comando é possível visualizar todos os recursos disponíveis e os seus status.

4 - Após validar que a aplicação subiu sem erros, acessar a seguinte url no browser para listagem do swagger de todos os endpoints disponíveis:

[http://localhost:31000/swagger](http://localhost:31000/swagger)

### Outros comandos kubectl interessantes:

```bash
kubectl delete pvc postgres-pvc # Exclui o pvc caso ocorra algum problema com as tabelas do banco
kubectl delete pod -l app=fiap-tech-challenge # Exclui o pod para forçar a criação de um novo pod
kubectl exec -it <nome_do_pod> -- psql -U fiap_user -d fiap_db -c "\dt" # Para visualizar as tabelas criadas
kubectl get pods --watch # Visualizar o status dos pods em tempo real
kubectl logs fiap-tech-challenge # Visualizar os logs do pod da aplicação
```