using Microsoft.AspNetCore.Mvc.RazorPages;
using PortfolioWeb.Models;

namespace PortfolioWeb.Pages;

public class IndexModel : PageModel
{
    public string Name { get; } = "Seth Andrey Jabagat";
    public string Role { get; } = "Aspiring C# Web Developer";

    public IReadOnlyList<string> CoreSkills { get; } =
    [
        "C#",
        ".NET 8",
        "ASP.NET Core",
        "Razor Pages",
        "HTML & CSS",
        "Git"
    ];

    public IReadOnlyList<PortfolioProject> Projects { get; } =
    [
        new(
            "C# Practice Lab",
            "A menu-driven console application for practicing variables, conditions, loops, methods, and collections.",
            ["C#", ".NET", "Console"],
            "Practice project"),
        new(
            "Developer Portfolio",
            "A responsive portfolio built with ASP.NET Core Razor Pages and a C#-powered content model.",
            ["ASP.NET Core", "Razor", "CSS"],
            "You are viewing it"),
        new(
            "Next Project",
            "Reserved for the next application I build as I continue learning backend and web development.",
            ["Coming soon"],
            "In progress")
    ];

    public int CurrentYear => DateTime.Now.Year;

    public void OnGet()
    {
    }
}
