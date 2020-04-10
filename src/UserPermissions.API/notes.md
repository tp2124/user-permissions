# Initialization of Project
## General .NET
1. `dotnet new webapi -n UserPermissions.API`
1. Launch Settings change "applicationUrl". Remove https
    1. Comment out `app.UseHttpsRedirection()` from Startup.cs
    1. You should be able to get the templated values at [Link](http://localhost:5000/WeatherForecast)
1. Create Applicable controllers from copied template in the initial commits of the new Controllers in this first commit.

## EF Core