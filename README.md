# Desafio IBGE - Sistema de Localidades

Bem-vindo ao Desafio IBGE, um projeto que oferece uma aplicação web avançada para gerenciar dados de cidades e estados do Brasil, utilizando o [conjunto de dados do IBGE](https://github.com/andrebaltieri/ibge).

## Funcionalidades Principais

- **Autenticação Robusta:** Utilizando Identity para garantir segurança e controle de acesso.
- **CRUD de Localidades:** Gerencie dados de cidades e estados de forma eficiente.
- **Pesquisas Avançadas:** Realize pesquisas por cidade, estado e código IBGE.
- **Tecnologia Moderna:** Desenvolvido com Blazor 8, SQL Server e EF Core.

## Padrões e Práticas de Desenvolvimento

- **Arquitetura em Camadas:** Organizado em Core, Domain, Data e Presentation.
- **Design Patterns:** Implementação de ServicePattern, RepositoryPattern, Specification Pattern, e outros.
- **MVVM (Model-View-ViewModel):** Adotando boas práticas para a interação entre a lógica de negócios e a interface do usuário.

## Estrutura do Projeto

1. **Core:** Classes abstratas e ferramentas fundamentais.
2. **Domain:** Implementação do modelo, validações e interfaces.
3. **Data:** Contém DbContext, migrações e repositório especializado.
4. **Presentation:** ViewModel, serviços e interfaces do usuário.

## Páginas da Aplicação

- **Sobre o Desafio:** Visão geral do projeto e do desafio proposto.
- **Login:** Autenticação segura para acesso à plataforma.
- **Cadastro de Usuário:** Registro intuitivo de novos usuários.
- **Gerenciamento de Perfil:** Configurações de perfil de usuário personalizadas.
- **Listagem de Registros IBGE:** Pesquisa eficiente por cidade, estado e código IBGE.
- **Inserção e Edição de Registros IBGE:** Adição e atualização de informações de forma simplificada.

## Fluxo de Referência de Projeto

- **Fluxo de Camadas:** Core -> Domain -> Data -> Presentation.
- **Testes Unitários:** Cobertura de testes nas camadas Domain e Presentation.

## Contato

Para dúvidas ou mais informações, entre em contato com nossa equipe de desenvolvimento.


<details Closed> 
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
