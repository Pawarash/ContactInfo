# What is ContactInfo ? 
The best path to **leverage your ASP.NET Core** skills. Onboarding to **Full Stack .Net Core Developer** jobs. Boilerplate for **ASP.NET Core reference application** with **Entity Framework Core**, demonstrating a layered application architecture with DDD best practices. Implements NLayer **Hexagonal architecture** (Core, Application, Infrastructure and Presentation Layers) and **Domain Driven Design** (Entities, Repositories, Domain/Application Services, DTO's...) 
and aimed to be a **Clean Architecture**, with applying **SOLID principles** in order to use for a project template. 
Also implements **best practices** like **loosely-coupled, dependency-inverted** architecture and using **design patterns** such as **Dependency Injection**, logging, validation, exception handling, localization and so on.

You can check full repository documentations and step by step development of **[100+ page e-book PDF](https://aspnetrun.azurewebsites.net)** from here - **https://aspnetrun.azurewebsites.net**. Also detail introduction of book and project structure exists on **[medium aspnetrun page](https://medium.com/aspnetrun)**. You can follow **aspnetrun repositories** for building **step by step** asp.net core **web development skills**.

# ContactInfo Repositories
Here you can find all of the **ContactInfo repositories from easy to difficult**

## Bonus
For this repo, there is also **implemented base repository** and **applying real-world crud examples** with developing new enterprice features for example Add, Update, Delete, Edit Check below repository;

* **[ContactInfo-realworld](https://github.com/Pawarash/ContactInfo)** - implemented run-aspnetcore repository and build **sample of CRUD reference application** on Multi-Page Web Applications(MPA) using ASP.NET Core Razor Pages templates.


# ContactInfo
Here is CRUD operations of contactInfo template project;

**contactInfo** is a general purpose to implement the **Default Web Application template of .Net** with **layered architecture** for building modern web applications with latest ASP.NET Core & Web API & EF Core technologies. 

## Give a Star! :star:
If you liked the project or if AspnetRun helped you, please **give a star**. And also please **fork** this repository and send us **pull-requests**. If you find any problem please open **issue**.

## Getting Started
Use these instructions to get the project up and running.

### Prerequisites
You will need the following tools:

* [Visual Studio 2019](https://visualstudio.microsoft.com/downloads/)
* [.Net Core 3.1](https://dotnet.microsoft.com/download/dotnet-core/3.1)
* EF Core 3.1 

### Installing
Follow these steps to get your development environment set up:
1. Clone the repository
2. At the root directory, restore required packages by running:
```csharp
dotnet restore
```
3. Next, build the solution by running:
```csharp
dotnet build
```
4. Next, within the ContactInfoWeb directory, launch the back end by running:
```csharp
dotnet run
```
5. Launch http://localhost:55935/ in your browser to view the Web UI.

If you have **Visual Studio** after cloning Open solution with your IDE, ContactInfoWeb should be the start-up project. Directly run this project on Visual Studio with **F5 or Ctrl+F5**. You will see index page of project, you can navigate  Home and Contact pages and you can perform crud operations on your browser.

### Usage
After cloning or downloading the sample you should be able to run it using an In Memory database immediately. The default configuration of Entity Framework Database is **"InMemoryDatabase"**.
If you wish to use the project with a persistent database, you will need to run its Entity Framework Core **migrations** before you will be able to run the app, and update the ConfigureDatabases method in **Startup.cs** (see below).

```csharp
  public void ConfigureDatabases(IServiceCollection services)
        {
            // use in-memory database
            services.AddDbContext<ContactInfoContext>(c =>
                c.UseInMemoryDatabase("ContactInfoConnection"));

            //// use real database
            //services.AddDbContext<ContactInfoContext>(c =>
            //    c.UseSqlServer(Configuration.GetConnectionString("ContactInfoConnection")));
        }
```

1. Ensure your connection strings in ```appsettings.json``` point to a local SQL Server instance.

2. Open a command prompt in the Web folder and execute the following commands:

```csharp
dotnet restore
dotnet ef database update -c ContactInfoContext -p ../ContactInfo.Infrastructure.csproj -s ContactInfoWeb.csproj
```
Or you can direct call ef commands from Visual Studio **Package Manager Console**. Open Package Manager Console, set default project to ContactInfo.Infrastructure and run below command;
```csharp
update-database
```
These commands will create ContactInfo database which include Contact table. You can see from **ContactInfoContext.cs**.
1. Run the application.
The first time you run the application, it will seed ContactInfo sql server database with a few data such that you should see Contact.

If you modify-change or add new some of entities to Core project, you should run ef migrate commands in order to update your database as the same way but below commands;
```csharp
add migration YourCustomEntityChanges
update-database
```

## Layered Architecture
ContactInfo implements NLayer **Hexagonal architecture** (Core, Application, Infrastructure and Presentation Layers) and **Domain Driven Design** (Entities, Repositories, Domain/Application Services, DTO's...). Also implements and provides a good infrastructure to implement **best practices** such as Dependency Injection, logging, validation, exception handling, localization and so on.
Aimed to be a **Clean Architecture** also called **Onion Architecture**, with applying **SOLID principles** in order to use for a project template. Also implements and provides a good infrastructure to implement **best practices** like **loosely-coupled, dependency-inverted** architecture
The below image represents ContactInfo approach of development architecture of run repository series;

![DDD_png_pure](https://user-images.githubusercontent.com/1147445/54773098-e1efe700-4c19-11e9-9150-74f7e770de42.png)

### Structure of Project
Repository include layers divided by **4 project**;
* Core
    * Entities    
    * Interfaces
    * Exceptions
* Application    
    * Interfaces    
    * Services
    * Dtos
    * Mapper
    * Exceptions
* Infrastructure
    * Data
    * Repository
    * Services
    * Migrations
    * Logging
    * Exceptions
* Web
    * Interfaces
    * Services
    * Pages
    * ViewModels
    * AutoMapper

### Core Layer
Development of Domain Logic with abstraction. Interfaces drives business requirements with light implementation. The Core project is the **center of the Clean Architecture** design, and all other project dependencies should point toward it.. 

#### Entities
Includes Entity Framework Core Entities which creates sql table with **Entity Framework Core Code First Aproach**. Some Aggregate folders holds entity and aggregates.
You can see example of **code-first** Entity definition as below;

```csharp
/// <summary>
    /// The contact.
    /// </summary>
    public class Contact : Entity
    {
        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the phone number.
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether status.
        /// </summary>
        public bool Status { get; set; }

        /// <summary>
        /// The create.
        /// </summary>
        /// <param name="firstName">
        /// The first name.
        /// </param>
        /// <param name="lastName">
        /// The last name.
        /// </param>
        /// <param name="email">
        /// The email.
        /// </param>
        /// <param name="phoneNumber">
        /// The phone number.
        /// </param>
        ///  /// <param name="status">
        /// The status.
        /// </param>
        /// <returns>
        /// The <see cref="Contact"/>.
        /// </returns>
        public static Contact Create(int contactId, string firstName, string lastName, string email, string phoneNumber, bool status)
        {
            var contact = new Contact
            {    
                 Id = contactId,
                 FirstName = firstName,
                 LastName = lastName,
                 Email = email,
                 PhoneNumber = phoneNumber,
                 Status = status
            };
            return contact;
        }
    }
```
Applying domain driven approach, Contact class responsible to create Product instance. 

#### Interfaces
Abstraction of Repository - Domain repositories (IAsyncRepository - IContactInfoRepository) etc.. This interfaces include database operations without any application and ui responsibilities.


### Infrastructure Layer
Implementation of Core interfaces in this project with **Entity Framework Core** and other dependencies.
Most of your application's dependence on external resources should be implemented in classes defined in the Infrastructure project. These classes must implement the interfaces defined in Core. If you have a very large project with many dependencies, it may make sense to have more than one Infrastructure project (eg Infrastructure.Data), but in most projects one Infrastructure project that contains folders works well.
This could be includes, for example, **file access, web api clients**, etc. For now this repository only dependend sample data access and basic domain actions, by this way there will be no direct links to your Core or UI projects.

#### Data
Includes **Entity Framework Core Context** and tables in this folder. When new entity created, it should add to context and configure in context.
The Infrastructure project depends on Microsoft.**EntityFrameworkCore.SqlServer** and EF.Core related nuget packages, you can check nuget packages of Infrastructure layer. If you want to change your data access layer, it can easily be replaced with a lighter-weight ORM like Dapper. 

#### Migrations
EF add-migration classes.
#### Repository
EF Repository and implementation. This class responsible to create queries, includes, where conditions etc..
#### Services
Custom services implementation.

### Application Layer
Development of **Domain Logic with implementation**. Interfaces drives business requirements and implementations in this layer.
Application layer defines that user required actions in app services classes as below way;

```csharp
  public interface IContactInfoService
    {
        /// <summary>
        /// The get contact list.
        /// </summary>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task<IEnumerable<ContactInfoModel>> GetContactList();

        /// <summary>
        /// The get contact by id.
        /// </summary>
        /// <param name="contactId">
        /// The contact id.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task<ContactInfoModel> GetContactById(int contactId);

        /// <summary>
        /// The create.
        /// </summary>
        /// <param name="contactInfoModel">
        /// The contact info model.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task<ContactInfoModel> Create(ContactInfoModel contactInfoModel);

        /// <summary>
        /// The update.
        /// </summary>
        /// <param name="contactInfoModel">
        /// The contact info model.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task Update(ContactInfoModel contactInfoModel);

        /// <summary>
        /// The delete.
        /// </summary>
        /// <param name="contactInfoModel">
        /// The contact info model.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task Delete(ContactInfoModel contactInfoModel);
    }
```
Also implementation located same places in order to choose different implementation at runtime when DI bootstrapped.
```csharp
 /// <summary>
    /// The contact info service.
    /// </summary>
    public class ContactInfoService : IContactInfoService
    {
        /// <summary>
        /// The _i contact info repository.
        /// </summary>
        private readonly IContactInfoRepository _contactInfoRepository;

        /// <summary>
        /// The _logger.
        /// </summary>
        private readonly IAppLogger<ContactInfoService> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="ContactInfoService"/> class.
        /// </summary>
        /// <param name="iContactInfoRepository">
        /// The i contact info repository.
        /// </param>
        /// <param name="logger">
        /// The logger.
        /// </param>
        public ContactInfoService(IContactInfoRepository contactInfoRepository, IAppLogger<ContactInfoService> logger)
        {
            _contactInfoRepository = contactInfoRepository ?? throw new ArgumentNullException(nameof(contactInfoRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// The get contact list.
        /// </summary>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task<IEnumerable<ContactInfoModel>> GetContactList()
        {
            var contactInfoList = await _contactInfoRepository.GetContactListAsync();
            var mapped = ObjectMapper.Mapper.Map<IEnumerable<ContactInfoModel>>(contactInfoList);
            return mapped;
        }

        /// <summary>
        /// The get contact by id.
        /// </summary>
        /// <param name="contactId">
        /// The contact id.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task<ContactInfoModel> GetContactById(int contactId)
        {
            var contactInfo = await _contactInfoRepository.GetByIdAsync(contactId);
            var mapped = ObjectMapper.Mapper.Map<ContactInfoModel>(contactInfo);
            return mapped;
        }

        /// <summary>
        /// The create.
        /// </summary>
        /// <param name="contactInfoModel">
        /// The contact info model.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        /// <exception cref="ApplicationException">
        /// </exception>
        public async Task<ContactInfoModel> Create(ContactInfoModel contactInfoModel)
        {
            await ValidateContactIfExist(contactInfoModel);

            var mappedEntity = ObjectMapper.Mapper.Map<Contact>(contactInfoModel);
            if (mappedEntity == null)
                throw new ApplicationException($"Entity could not be mapped.");

            var newEntity = await _contactInfoRepository.AddAsync(mappedEntity);
            _logger.LogInformation($"Entity successfully added - AspnetRunAppService");

            var newMappedEntity = ObjectMapper.Mapper.Map<ContactInfoModel>(newEntity);
            return newMappedEntity;
        }

        /// <summary>
        /// The update.
        /// </summary>
        /// <param name="contactInfoModel">
        /// The contact info model.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        /// <exception cref="ApplicationException">
        /// </exception>
        public async Task Update(ContactInfoModel contactInfoModel)
        {
            ValidateContactIfNotExist(contactInfoModel);

            var editContact = await _contactInfoRepository.GetByIdAsync(contactInfoModel.Id);
            if (editContact == null)
                throw new ApplicationException($"Entity could not be loaded.");

            ObjectMapper.Mapper.Map<ContactInfoModel, Contact>(contactInfoModel, editContact);

            await _contactInfoRepository.UpdateAsync(editContact);
            _logger.LogInformation($"Entity successfully updated - AspnetRunAppService");
        }

        /// <summary>
        /// The delete.
        /// </summary>
        /// <param name="contactInfoModel">
        /// The contact info model.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        /// <exception cref="ApplicationException">
        /// </exception>
        public async Task Delete(ContactInfoModel contactInfoModel)
        {
            ValidateContactIfNotExist(contactInfoModel);
            var deletedContact = await _contactInfoRepository.GetByIdAsync(contactInfoModel.Id);
            if (deletedContact == null)
                throw new ApplicationException($"Entity could not be loaded.");

            await _contactInfoRepository.DeleteAsync(deletedContact);
            _logger.LogInformation($"Entity successfully deleted - AspnetRunAppService");
        }

        /// <summary>
        /// The validate contact if exist.
        /// </summary>
        /// <param name="contactInfoModel">
        /// The contact info model.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        /// <exception cref="ApplicationException">
        /// </exception>
        private async Task ValidateContactIfExist(ContactInfoModel contactInfoModel)
        {
            var existingEntity = await _contactInfoRepository.GetByIdAsync(contactInfoModel.Id);
            if (existingEntity != null)
                throw new ApplicationException($"{contactInfoModel.ToString()} with this id already exists");
        }

        /// <summary>
        /// The validate contact if not exist.
        /// </summary>
        /// <param name="contactInfoModel">
        /// The contact info model.
        /// </param>
        /// <exception cref="ApplicationException">
        /// </exception>
        private void ValidateContactIfNotExist(ContactInfoModel contactInfoModel)
        {
            var existingEntity = _contactInfoRepository.GetByIdAsync(contactInfoModel.Id);
            if (existingEntity == null)
                throw new ApplicationException($"{contactInfoModel.ToString()} with this id is not exists");
        }
    }
```
In this layer we can add validation , authorization, logging, exception handling etc. -- cross cutting activities should be handled in here.

### Web Layer
Development of UI Logic with implementation. Interfaces drives business requirements and implementations in this layer.
The application's main **starting point** is the ASP.NET Core web project. This is a classical console application, with a public static void Main method in Program.cs. It currently uses the default **ASP.NET Core project template** which based on **Razor Pages** templates. This includes appsettings.json file plus environment variables in order to stored configuration parameters, and is configured in Startup.cs.

Web layer defines that user required actions in page services classes as below way;
```csharp
 public interface IContactInfoService
    {
        /// <summary>
        /// The get contact list.
        /// </summary>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task<IEnumerable<ContactInfoModel>> GetContactList();

        /// <summary>
        /// The get contact by id.
        /// </summary>
        /// <param name="contactId">
        /// The contact id.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task<ContactInfoModel> GetContactById(int contactId);

        /// <summary>
        /// The create.
        /// </summary>
        /// <param name="contactInfoModel">
        /// The contact info model.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task<ContactInfoModel> Create(ContactInfoModel contactInfoModel);

        /// <summary>
        /// The update.
        /// </summary>
        /// <param name="contactInfoModel">
        /// The contact info model.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task Update(ContactInfoModel contactInfoModel);

        /// <summary>
        /// The delete.
        /// </summary>
        /// <param name="contactInfoModel">
        /// The contact info model.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task Delete(ContactInfoModel contactInfoModel);
    }
```
Also implementation located same places in order to choose different implementation at runtime when DI bootstrapped.
```csharp
 /// <summary>
    /// The contact info service.
    /// </summary>
    public class ContactInfoService : IContactInfoService
    {
        /// <summary>
        /// The _i contact info repository.
        /// </summary>
        private readonly IContactInfoRepository _contactInfoRepository;

        /// <summary>
        /// The _logger.
        /// </summary>
        private readonly IAppLogger<ContactInfoService> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="ContactInfoService"/> class.
        /// </summary>
        /// <param name="iContactInfoRepository">
        /// The i contact info repository.
        /// </param>
        /// <param name="logger">
        /// The logger.
        /// </param>
        public ContactInfoService(IContactInfoRepository contactInfoRepository, IAppLogger<ContactInfoService> logger)
        {
            _contactInfoRepository = contactInfoRepository ?? throw new ArgumentNullException(nameof(contactInfoRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// The get contact list.
        /// </summary>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task<IEnumerable<ContactInfoModel>> GetContactList()
        {
            var contactInfoList = await _contactInfoRepository.GetContactListAsync();
            var mapped = ObjectMapper.Mapper.Map<IEnumerable<ContactInfoModel>>(contactInfoList);
            return mapped;
        }

        /// <summary>
        /// The get contact by id.
        /// </summary>
        /// <param name="contactId">
        /// The contact id.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task<ContactInfoModel> GetContactById(int contactId)
        {
            var contactInfo = await _contactInfoRepository.GetByIdAsync(contactId);
            var mapped = ObjectMapper.Mapper.Map<ContactInfoModel>(contactInfo);
            return mapped;
        }

        /// <summary>
        /// The create.
        /// </summary>
        /// <param name="contactInfoModel">
        /// The contact info model.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        /// <exception cref="ApplicationException">
        /// </exception>
        public async Task<ContactInfoModel> Create(ContactInfoModel contactInfoModel)
        {
            await ValidateContactIfExist(contactInfoModel);

            var mappedEntity = ObjectMapper.Mapper.Map<Contact>(contactInfoModel);
            if (mappedEntity == null)
                throw new ApplicationException($"Entity could not be mapped.");

            var newEntity = await _contactInfoRepository.AddAsync(mappedEntity);
            _logger.LogInformation($"Entity successfully added - AspnetRunAppService");

            var newMappedEntity = ObjectMapper.Mapper.Map<ContactInfoModel>(newEntity);
            return newMappedEntity;
        }

        /// <summary>
        /// The update.
        /// </summary>
        /// <param name="contactInfoModel">
        /// The contact info model.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        /// <exception cref="ApplicationException">
        /// </exception>
        public async Task Update(ContactInfoModel contactInfoModel)
        {
            ValidateContactIfNotExist(contactInfoModel);

            var editContact = await _contactInfoRepository.GetByIdAsync(contactInfoModel.Id);
            if (editContact == null)
                throw new ApplicationException($"Entity could not be loaded.");

            ObjectMapper.Mapper.Map<ContactInfoModel, Contact>(contactInfoModel, editContact);

            await _contactInfoRepository.UpdateAsync(editContact);
            _logger.LogInformation($"Entity successfully updated - AspnetRunAppService");
        }

        /// <summary>
        /// The delete.
        /// </summary>
        /// <param name="contactInfoModel">
        /// The contact info model.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        /// <exception cref="ApplicationException">
        /// </exception>
        public async Task Delete(ContactInfoModel contactInfoModel)
        {
            ValidateContactIfNotExist(contactInfoModel);
            var deletedContact = await _contactInfoRepository.GetByIdAsync(contactInfoModel.Id);
            if (deletedContact == null)
                throw new ApplicationException($"Entity could not be loaded.");

            await _contactInfoRepository.DeleteAsync(deletedContact);
            _logger.LogInformation($"Entity successfully deleted - AspnetRunAppService");
        }

        /// <summary>
        /// The validate contact if exist.
        /// </summary>
        /// <param name="contactInfoModel">
        /// The contact info model.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        /// <exception cref="ApplicationException">
        /// </exception>
        private async Task ValidateContactIfExist(ContactInfoModel contactInfoModel)
        {
            var existingEntity = await _contactInfoRepository.GetByIdAsync(contactInfoModel.Id);
            if (existingEntity != null)
                throw new ApplicationException($"{contactInfoModel.ToString()} with this id already exists");
        }

        /// <summary>
        /// The validate contact if not exist.
        /// </summary>
        /// <param name="contactInfoModel">
        /// The contact info model.
        /// </param>
        /// <exception cref="ApplicationException">
        /// </exception>
        private void ValidateContactIfNotExist(ContactInfoModel contactInfoModel)
        {
            var existingEntity = _contactInfoRepository.GetByIdAsync(contactInfoModel.Id);
            if (existingEntity == null)
                throw new ApplicationException($"{contactInfoModel.ToString()} with this id is not exists");
        }
    }
```
### Test Layer
For each layer, there is a test project which includes intended layer dependencies and mock classes. So that means Core-Application-Infrastructure and Web layer has their own test layer. By this way this test projects also divided by **unit, functional and integration tests** defined by in which layer it is implemented. 
Test projects using **xunit and Mock libraries**.  xunit, because that's what ASP.NET Core uses internally to test the product. Moq, because perform to create fake objects clearly and its very modular.


## Technologies
* .NET Core 3.0
* ASP.NET Core 3.0
* Entity Framework Core 3.0 
* .NET Core Native DI
* Razor Pages
* AutoMapper

## Architecture
* Clean Architecture
* Full architecture with responsibility separation of concerns
* SOLID and Clean Code
* Domain Driven Design (Layers and Domain Model Pattern)
* Unit of Work
* Repository and Generic Repository
* Multiple Page Web Application (MPA)
* Monolitic Deployment Architecture


## Disclaimer

* This repository is not intended to be a definitive solution.
* This repository not implemented a lot of 3rd party packages, we are try to avoid the over engineering when building on best practices.
* Beware to use in production way.

