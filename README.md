# Seth Andrey Jabagat — Developer Portfolio

A responsive portfolio and printable résumé built with C#, ASP.NET Core 8, and Razor Pages.

## Highlights

- Profile, education, tech stack, certifications, and academic, company, and community-focused projects
- Responsive desktop and mobile design
- Print-friendly résumé page at `/Resume`
- Server-side daily motivation from the ZenQuotes API
- Daily in-memory quote caching with a reliable built-in fallback
- Docker and Render deployment configuration
- Lightweight health endpoint at `/health`

## Run locally

```powershell
dotnet run --launch-profile http
```

Open <http://localhost:5247>. Stop the server with `Ctrl+C`.

## Deploy to Render

[![Deploy to Render](https://render.com/images/deploy-to-render-button.svg)](https://render.com/deploy?repo=https://github.com/gsi78eywh/csharp-portfolio)

The included `render.yaml` creates a free Docker web service in Render's Singapore region. The service checks `/health` and automatically deploys new commits from `main`.

Free Render services can spin down during periods without traffic, so the first request after inactivity can take longer.

## Important files

```text
PortfolioWeb/
|-- Program.cs                            Application and deployment setup
|-- Models/                               C# portfolio data records
|-- Services/ZenQuotesDailyQuoteService.cs Daily quote API integration
|-- Pages/Index.cshtml                    Main portfolio page
|-- Pages/Index.cshtml.cs                 Portfolio content model
|-- Pages/Resume.cshtml                   Printable résumé
|-- Pages/Shared/_Layout.cshtml           Navigation and shared layout
|-- wwwroot/css/                          Portfolio and résumé styling
|-- Dockerfile                            Production container image
`-- render.yaml                           Render deployment blueprint
```

## Update the portfolio

- Edit biography and links in `Pages/Index.cshtml`.
- Edit education, stack, certifications, projects, and experience in `Pages/Index.cshtml.cs`.
- Keep the résumé synchronized in `Pages/Resume.cshtml`.
