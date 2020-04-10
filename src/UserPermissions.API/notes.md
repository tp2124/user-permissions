# Initialization of Project
## General .NET
1. `dotnet new webapi -n UserPermissions.API`
1. Launch Settings change "applicationUrl". Remove https
    1. Comment out `app.UseHttpsRedirection()` from Startup.cs
    1. You should be able to get the templated values at [Link](http://localhost:5000/WeatherForecast)
1. Create Applicable controllers from copied template in the initial commits of the new Controllers in this first commit.

## EF Core
1. Create `Models` directory.
    1. Create Model class that will be represented in the DB.
1. Need to tell Entity Framework about the Model (Entity) we just defined above. To do that, we make a Data Context class.
    1. Create `Data` directory.
    1. Initialize `DataContext.cs` class. See this commit.
    1. To get the reference for `DbContext` inheritence, use nuget package manager to get:  `Microsoft.EntityFrameworkCore` and get the `Microsoft.EntityFrameworkCore` package with the version that matches your .NET (3.1.1 for this example).
1. Add `DataContext` as a service to the API to allow it to be used in various locations throughout the API.
    1. To add the reference for `UseSqlite` in `Startup.cs` changes to add the service, add nuget package: `Microsoft.EntityFrameworkCore.Sqlite`.
1. Adding a `ConnectionStrings` to `appsettings.json` and using that in `Startup.cs`.

