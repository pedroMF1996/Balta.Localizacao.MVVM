Bem-vindo ao repositório do Desafio IBGE! Este projeto oferece uma aplicação web com funcionalidades relacionadas a dados de cidades e estados do Brasil, utilizando o [conjunto de dados do IBGE](https://github.com/andrebaltieri/ibge).

## Funcionalidades Base

O projeto oferece as seguintes funcionalidades:

- Autenticação usando Identity
- CRUD de Localidade (Código, Estado, Cidade -- Id, City, State)
- Pesquisa por cidade
- Pesquisa por estado
- Pesquisa por código (IBGE)

## Tecnologias Utilizadas

- Blazor 8 para o desenvolvimento da aplicação web SSR.
- Banco de dados SQL Server.
- Entity Framework Core para a camada de dados.
- Fluent UI Web Components

## Padrões e Patterns

Os seguintes padrões foram adotados no desenvolvimento:

- ServicePattern
- IUnitOfWork
- RepositoryPattern
- Template Method Pattern
- MVVM (Model-View-ViewModel)
- Specification Pattern para os filtros da lista

## Estrutura do Projeto

O projeto foi organizado em quatro camadas:

1. **Core**: Contém classes abstratas e ferramentas para o desenvolvimento, com uma segmentação em pastas representando cada camada posterior.
2. **Domain**: Implementação do modelo, validações, interface de repositório e interface de especificação para filtros de listagem.
3. **Data**: Inclui o DbContext, mapeamento do modelo, migrações, classes relacionadas a especificações e o repositório IbgeRepository.
4. **Presentation**: Classes ViewModel, serviços, configurações e as interfaces de usuário.

## Páginas da Aplicação

O site possui as seguintes páginas:

1. **Sobre o Desafio**: Breve descrição do desafio.
2. **Login**: Página de autenticação.
3. **Cadastro de Usuário**: Registro de novos usuários.
4. **Gerenciamento de Perfil de Usuário**: Configurações de perfil.
5. **Listagem dos Registros IBGE**: Filtragem por cidade, estado e código IBGE.
6. **Inserção de Registro IBGE**: Adição de novos registros.
7. **Edição de Registro IBGE**: Atualização de registros existentes.

## Fluxo de Referência de Projeto

O fluxo de referência de projeto segue a ordem: **Core -> Domain -> Data -> Presentation**.

## Testes Unitários

As camadas de **Domain** e **Presentation** possuem testes unitários para validar diversos cenários que podem ocorrer.

Agradecemos por explorar este projeto! Se tiver alguma dúvida ou sugestão, sinta-se à vontade para contribuir ou entrar em contato.


<details Open> 
  <summary>
   <h1>Artigos & Pesquisas 📑</h1>
  </summary>

## Blazor:
- [Modos de renderização Blazor do ASP.NET Core](https://learn.microsoft.com/pt-br/aspnet/core/blazor/components/render-modes?view=aspnetcore-8.0)
- [ASP.NET Core Blazor authentication and authorization](https://learn.microsoft.com/en-us/aspnet/core/blazor/security/?view=aspnetcore-8.0)
- [ASP.NET Core Blazor forms overview](https://learn.microsoft.com/en-us/aspnet/core/blazor/forms/?view=aspnetcore-8.0)
- [Server-side ASP.NET Core Blazor additional security scenarios](https://learn.microsoft.com/en-us/aspnet/core/blazor/security/server/additional-scenarios?view=aspnetcore-8.0#pass-tokens-to-a-server-side-blazor-app)
- [Autenticação e autorização do Blazor no ASP.NET Core](https://learn.microsoft.com/pt-br/aspnet/core/blazor/security/?view=aspnetcore-8.0)
- [Visão geral dos formulários do ASP.NET Core Blazor](https://learn.microsoft.com/pt-br/aspnet/core/blazor/forms/?view=aspnetcore-8.0)
- [ASP.NET Core Blazor dependency injection](https://learn.microsoft.com/en-us/aspnet/core/blazor/fundamentals/dependency-injection?view=aspnetcore-8.0)

## .NET Core:
- [Using the Specification pattern alongside a generic Repository](https://medium.com/@rudyzio92/net-core-using-the-specification-pattern-alongside-a-generic-repository-318cd4eea4aa)
- [.NET Core — Using the Specification pattern alongside a generic Repository](https://medium.com/@rudyzio92/net-core-using-the-specification-pattern-alongside-a-generic-repository-318cd4eea4aa)

## ASP.NET Core:
- [Access HttpContext in ASP.NET Core](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/http-context?view=aspnetcore-8.0)
- [Overview of ASP.NET Core Authentication](https://learn.microsoft.com/en-us/aspnet/core/security/authentication/?view=aspnetcore-8.0)
- [Choose an identity management solution](https://learn.microsoft.com/en-us/aspnet/core/security/how-to-choose-identity-solution?view=aspnetcore-8.0)
- [Prevent Cross-Site Request Forgery (XSRF/CSRF) attacks in ASP.NET Core](https://learn.microsoft.com/en-us/aspnet/core/security/anti-request-forgery?view=aspnetcore-8.0#refresh-tokens-after-authentication-1)

## C#:
- [Trabalhando com Tasks assíncronas em C#](https://dev.to/marcosbelorio/trabalhando-com-tasks-assincronas-em-c-pjp)

## WPF .NET:
- [Como implementar notificação de alteração da propriedade - WPF .NET](https://learn.microsoft.com/pt-br/dotnet/desktop/wpf/data/how-to-implement-property-change-notification?view=netframeworkdesktop-4.8)

## Miscelânea:
- [Introdução ao MVVM (Model-View-ViewModel)](https://medium.com/netcoders/introdução-ao-mvvm-model-view-viewmodel-cb5920b4ca58)
- [.NET Core — Using the Specification pattern alongside a generic Repository](https://medium.com/@rudyzio92/net-core-using-the-specification-pattern-alongside-a-generic-repository-318cd4eea4aa)
- [C# Blazor Server: Display live data using INotifyPropertyChanged](https://stackoverflow.com/questions/65813816/c-sharp-blazor-server-display-live-data-using-inotifypropertychanged)
- [ASP.NET Core 2.1.0-preview1: Introducing Identity UI as a library](https://devblogs.microsoft.com/dotnet/aspnetcore-2-1-identity-ui/)


</details>
