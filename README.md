# Amir Apparel Demo API Dotnet (.NET)

This project is the API of the client-server architecture Amir Apparel Demo. You can find the rest of the repositories on this page: https://github.com/amirfounder.

## Dependencies

- C# Installed
- UI version - Found here: https://github.com/amirfounder
- Visual Studio (Recommended)

## How to run:

- Launch Visual Studio
- Open the `amir-apparel-demo-api-dotnet-5.sln` solution file
- Run the Amir.Apparel.Demo.Api.Dotnet project

# Developer Note

My motivation for this project was to upskill in .NET and learn C#. This project includes basic features such as pagination and filtering. Included frameworks / libraries:

- ASP.NET
- Entity Framework
- AutoMapper

## Challenges

As of writing, the 2 biggest challenges I ran into were:

- Using and being restricted by the use of generics when creating my domains
- Writing dynamic / complex queries that would execute on the server (database) rather than the client (API)

## Lessons

While building out this project, I learned a lot of lessons. Several of which:

- How to write generics
- Dependency inversion
- Expression trees
- Do not over optimize. Get the card done and move on (Generic Repository for filtering)

## Inspiration

- https://github.com/nbarbettini/BeautifulRestApi/blob/master/src/Startup.cs
- https://github.com/FabianGosebrink/ASPNETCore-WebAPI-Sample
- https://github.com/kilicars/AspNetCoreRepositoryPattern
