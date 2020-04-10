# Initialization of Project
## General .NET
1. `dotnet new webapi -n UserPermissions.API`
1. Launch Settings change "applicationUrl". Remove https
    1. Comment out `app.UseHttpsRedirection()` from Startup.cs
    1. You should be able to get the templated values at [Link](http://localhost:5000/WeatherForecast)
1. Create Applicable controllers from copied template in the initial commits of the new Controllers in this first commit.

## EF Core
### API Setup
1. Create `Models` directory.
    1. Create Model class that will be represented in the DB.
    1. A convention to get a default Primary Key is by the name `Id`
1. Need to tell Entity Framework about the Model (Entity) we just defined above. To do that, we make a Data Context class.
    1. Create `Data` directory.
    1. Initialize `DataContext.cs` class. See this commit.
    1. To get the reference for `DbContext` inheritence, use nuget package manager to get:  `Microsoft.EntityFrameworkCore` and get the `Microsoft.EntityFrameworkCore` package with the version that matches your .NET (3.1.1 for this example).
1. Add `DataContext` as a service to the API to allow it to be used in various locations throughout the API.
    1. To add the reference for `UseSqlite` in `Startup.cs` changes to add the service, add nuget package: `Microsoft.EntityFrameworkCore.Sqlite`.
1. Adding a `ConnectionStrings` to `appsettings.json` and using that in `Startup.cs`.
### EF Core Tool Usage
1. Ensure you have the tools installed: `dotnet tool install --global dotnet-ef`
    1. check with `dotnet ef --version`
1. `dotnet ef migrations add InitialCreate`
    1. You might get an error on this. 
        1. If the output is `Build failed.`, ensure you do not have the API running.
        1. If there is output about dependencies, add the missing depednency, likely `Microsoft.EntityFrameworkCore.Design`, package via nuget.
    1. This only creates the migration. This has not touched the DB at this point.
1. `dotnet ef database update` -> Pushes the migrations to the DB.
    1. Check the `.db` file generated in DB Browser for SQLite
