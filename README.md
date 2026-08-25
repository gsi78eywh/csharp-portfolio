# Seth's ASP.NET Core Portfolio

A responsive developer portfolio built with C#, ASP.NET Core 8, and Razor Pages.

## Run locally

From the `PortfolioWeb` folder:

```powershell
dotnet run --launch-profile http
```

Open <http://localhost:5247> in a browser. Stop the server with `Ctrl+C`.

## Personalize before publishing

- Update your introduction and location in `Pages/Index.cshtml`.
- Update skills and project information in `Pages/Index.cshtml.cs`.
- Review the email and GitHub URL in `Pages/Index.cshtml`.
- Replace the `SJ` initials with a real photo later if you want one.

## Important files

```text
PortfolioWeb/
|-- Program.cs                      ASP.NET Core application setup
|-- Models/PortfolioProject.cs      C# project data type
|-- Pages/Index.cshtml              Portfolio page markup
|-- Pages/Index.cshtml.cs           C# portfolio content
|-- Pages/Shared/_Layout.cshtml     Navigation and page layout
`-- wwwroot/
    |-- css/site.css                Responsive visual design
    `-- js/site.js                  Menu and scroll effects
```
