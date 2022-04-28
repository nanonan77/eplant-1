# E-Plant

### This Project use DDD Plattern as much as posiple

start dev at 01/2022 with Sketec Team's



## Architecture

- Core
- Infrastructure
- Domain
- Application
- API 
- Identity Server (Providing Auth0 and OpenId)

## Framwork

### Authentication & Authorization
- Identity Core

Use Identity Core for Account management

- Identity Server

Use Identity Server for  authen&auth and use for login session with Identity Core

### SQL
- Entity Core
- Dapper

Use EF Core as ORM & Dapper for SQL/PL

### Other

- AutoMapper
- FluentValidation



## Installation

Please follow this step below to install depencency and migration/seeding data

### Migration
There are three DB Context to migration as below


- MainContext
- PersistedGrantDbContext  (ID Provider)
- ConfigurationDbContext  (ID Provider)


use NugetPackge's command for migration these DbContext

(you need to set Sketec.IdentityServer as Startup Project for configuration Connection string and set default Project to Sketec.IdentityServer)

#### MainContext 
```bashxxxx
update-database -Context MainContext
```

#### PersistedGrantDbContext 
```bashxxxx
update-database -Context PersistedGrantDbContext
```

#### ConfigurationDbContext  
```bashxxxx
update-database -Context ConfigurationDbContext  
```

### Client App (UI)

Install Package dependency

```
npm install
```

## Usage

- Set Sketec.Api & Sketec.IdentityServer to Startup Project
- go to Client App and run follow command

```
npm start
```

## Contributors 

### Special Thank 
 
 - BoyzaVasabi
 - Boy Lego
 - Boy พิฆาตชายฝั่ง
 - Boy คอแข็ง
