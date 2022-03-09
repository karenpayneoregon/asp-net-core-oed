## Create razor project

From solution level

```
dotnet new webapp --name Demo1
```

## Trust the development certificate

```
dotnet dev-certs https --trust
```

## Run 

```
dotnet watch run
```

Press <kbd>ctrl</kbd> + <kbd>c</kbd> to stop

## View

https://localhost:5001/


## Browser Link in ASP.NET Core

https://docs.microsoft.com/en-us/aspnet/core/client-side/using-browserlink?view=aspnetcore-5.0


# Working on...

Directory.Build.props

```xml
<Project>
  <PropertyGroup>
    <LangVersion>9.0</LangVersion>
  </PropertyGroup>

  <PropertyGroup>
    <Authors>Karen Payne</Authors>
    <Company>OED</Company>
  </PropertyGroup>  
</Project>
```

Startup.cs

```csharp
public void ConfigureServices(IServiceCollection services)
{
    services.AddRazorPages();
    services.AddRazorPages().AddRazorRuntimeCompilation();
}


public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
{

    app.UseHttpsRedirection();
    app.UseStaticFiles();
    app.UseBrowserLink();
    app.UseRouting();
}
```

```bat
@echo off
cls

cd C:\OED\Dotnetland\VS2019\CreateExamples
md RazorSolution
cd RazorSolution
dotnet new sln -n RazorSolution
dotnet new webapp -o Demo1 
dotnet add Demo1\Demo1.csproj package Microsoft.AspNetCore.Mvc.Razor.RuntimeCompilation -v 5.0.11
dotnet add Demo1\Demo1.csproj package Microsoft.VisualStudio.Web.BrowserLink -v 2.2.0
dotnet sln RazorSolution.sln add Demo1\Demo1.csproj --solution-folder RazorPages

pause
```