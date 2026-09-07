using Microsoft.AspNetCore.Mvc.RazorPages;
using PortfolioWeb.Models;
using PortfolioWeb.Services;

namespace PortfolioWeb.Pages;

public class IndexModel(IDailyQuoteService dailyQuoteService) : PageModel
{
    public string Name { get; } = "Seth Andrey Jabagat";
    public string Location { get; } = "Dalaguete, Cebu, Philippines";
    public string Role { get; } = "Junior Software Developer | Microsoft Power Platform & Web";
    public string MicrosoftTeamsChatUrl { get; } =
        "https://teams.microsoft.com/l/chat/0/0?users=sethandreyabrasado@gmail.com&message=Hi%20Seth%2C%20I%20visited%20your%20portfolio%20and%20would%20like%20to%20connect.";

    public DailyQuote Quote { get; private set; } = new(
        "Always focus on your own lane. No one finds happiness by pursuing someone else's life path.",
        "Sylvia Salow",
        false);

    public IReadOnlyList<EducationItem> Education { get; } =
    [
        new(
            "Associate in Computer Technology",
            "2024 – 2026",
            "University of San Jose – Recoletos",
            "/images/education/usjr-logo.png",
            "University of San Jose – Recoletos seal",
            "https://usjr.edu.ph/",
            true),
        new(
            "Senior High School",
            "2021 – 2023",
            "Mantalongon National High School, Dalaguete, Cebu",
            "/images/education/mantalongon-logo.jpg",
            "Mantalongon National High School seal",
            "https://mantalongonnhs.weebly.com/",
            true),
        new(
            "Technology Scholarship Program",
            "Class of 2026",
            "Passerelles Numériques Philippines",
            "/images/education/pn-logo.png",
            "Passerelles Numériques logo",
            "https://www.passerellesnumeriques.org/what-we-do/philippines/",
            true)
    ];

    public IReadOnlyList<SkillGroup> TechStack { get; } =
    [
        new("Microsoft & Low-Code", ["Power Apps", "Power Automate", "SharePoint", "Microsoft 365", "Dataverse", "C#", "ASP.NET Core"]),
        new("Web Development", ["HTML5", "CSS3", "JavaScript", "TypeScript", "React", "Tailwind CSS", "PHP", "Laravel", "MySQL", "Node.js", "Python"]),
        new("Cloud & Delivery", ["Microsoft Azure", "Vercel", "Render", "Docker", "GitHub"]),
        new("Design & AI Workflow", ["AI & Agent-Assisted Dev", "GitHub Copilot", "Microsoft Copilot", "ChatGPT", "VS Code", "Postman"])
    ];

    public IReadOnlyList<SkillCategoryWithRatings> RatedSkills { get; } =
    [
        new("Frontend",
        [
            new("HTML", 9, "Advanced (9/10)", "orange", "html", "Semantic HTML5, accessible layouts, and SEO best practices"),
            new("CSS", 9, "Advanced (9/10)", "blue", "css", "Modern CSS3, responsive Flexbox/Grid systems, and custom properties"),
            new("JavaScript", 7, "Skilled (7/10)", "yellow", "js", "ES6+ syntax, asynchronous fetch, and dynamic DOM manipulation"),
            new("TypeScript", 8, "Proficient (8/10)", "sky", "ts", "Static typing, component contracts, and interface definitions"),
            new("React", 8, "Proficient (8/10)", "cyan", "react", "Component lifecycle, state management, hooks, and responsive SPAs"),
            new("Tailwind CSS", 8, "Proficient (8/10)", "teal", "tailwind", "Utility-first design, fluid responsive sizing, and rapid prototyping")
        ]),
        new("Backend & Database",
        [
            new("Laravel", 8, "Proficient (8/10)", "red", "laravel", "MVC architecture, Eloquent ORM, RESTful routing, and Blade templating"),
            new("MySQL", 8, "Proficient (8/10)", "blue", "mysql", "Relational database schema design, indexing, and complex queries"),
            new("Python", 8, "Proficient (8/10)", "yellow", "python", "OS automation scripting, data manipulation, and workflow scripts"),
            new("C#", 7, "Skilled (7/10)", "purple", "csharp", "Object-oriented programming, LINQ data queries, and core logic"),
            new(".NET / ASP.NET", 7, "Skilled (7/10)", "indigo", "dotnet", "ASP.NET Core Razor Pages, Web APIs, and dependency injection"),
            new("PHP", 7, "Skilled (7/10)", "violet", "php", "Backend processing, server scripting, and authentication handling"),
            new("Node.js", 7, "Skilled (7/10)", "green", "nodejs", "Express APIs, npm ecosystem, and asynchronous runtime execution")
        ]),
        new("Microsoft Power Platform & Cloud",
        [
            new("Power Apps", 9, "Advanced (9/10)", "purple", "powerapps", "Custom Canvas & Model-driven applications with responsive multi-screen UX"),
            new("Power Automate", 9, "Advanced (9/10)", "blue", "powerautomate", "Automated multi-tier approval flows, scheduled jobs, and trigger logic"),
            new("SharePoint", 9, "Advanced (9/10)", "teal", "sharepoint", "Enterprise list data architecture, document libraries, and access controls"),
            new("Microsoft 365", 8, "Proficient (8/10)", "sky", "ms365", "Teams integration, Outlook automation, and organizational workflows"),
            new("Dataverse", 7, "Skilled (7/10)", "indigo", "dataverse", "Common Data Model entities, business rules, and relational data stores")
        ]),
        new("Tools & AI Workflow",
        [
            new("AI & Agent-Assisted", 9, "Expert Workflow (9/10)", "indigo", "ai", "Prompt engineering, agentic development, Antigravity, and Copilot workflows"),
            new("VS Code", 9, "Advanced (9/10)", "blue", "vscode", "Extensions ecosystem, integrated terminal, and multi-repo workflows"),
            new("Git", 8, "Proficient (8/10)", "orange", "git", "Version control, branching strategies, and merge resolution"),
            new("GitHub", 8, "Proficient (8/10)", "dark", "github", "Remote repositories, pull request reviews, and open-source collaboration"),
            new("Postman", 8, "Proficient (8/10)", "orange", "postman", "API testing, request collections, and payload inspection"),
            new("Docker & Cloud", 7, "Skilled (7/10)", "cyan", "docker", "Containerization basics, environment isolation, and Render/Azure deploys")
        ])
    ];

    public IReadOnlyList<string> Certifications { get; } =
    [
        "Google Data Analytics",
        "Python Automation with Google",
        "Google UI/UX Design Training",
        "Rapid Application Development",
        "Web Development Fundamentals",
        "Database Management Systems"
    ];

    public int ShippedProjectsCount => Projects.Count;
    public int RepositoriesCount => Projects.Count(p => !string.IsNullOrWhiteSpace(p.RepositoryUrl));

    public IReadOnlyList<PortfolioProject> Projects { get; } =
    [
        new(
            "Library Management System",
            "Aug 2025 – Nov 2025",
            "Web-based catalog platform with responsive search, borrowing records, and real-time inventory tracking; streamlined resource access for 70% of student users.",
            ["Responsive UI", "Database Design", "Academic Project"],
            "Completed"),
        new(
            "Hotel Booking System",
            "Full-Stack Web App",
            "Full-stack reservation platform built with Laravel and MySQL, managing room inventories, guest billing, check-in schedules, and role-based staff workflows.",
            ["PHP", "Laravel", "MySQL"],
            "Full-Stack",
            "https://github.com/gsi78eywh/Saystem"),
        new(
            "Activity Proposal System",
            "Enterprise Workflow",
            "Microsoft Power Platform enterprise workflow automating budget requests, organizational proposal compliance, multi-tier approvals, and financial audits.",
            ["Power Apps", "Power Automate", "Reporting"],
            "Power Platform"),
        new(
            "REACH System — Relief Automated Messaging",
            "Community Platform",
            "Emergency disaster relief system coordinating automated SMS broadcasts, distribution checkpoints, and household duplicate-aid verification.",
            ["React", "SMS Workflow", "Community Data"],
            "Prototype",
            "https://github.com/gsi78eywh/REACH-v4")
    ];

    public IReadOnlyList<ExperienceItem> Experience { get; } =
    [
        new(
            "Youth Empowerment Participant",
            "January 2025 – Present",
            "Build leadership and digital skills through collaborative community workshops and peer learning."),
        new(
            "Industry Learning — Accenture & AI Talks",
            "January – February 2026",
            "Studied practical AI, cloud, and industry trends through technical talks, case examples, and Q&A sessions."),
        new(
            "Alliance Student Developer",
            "Aug – Dec 2025",
            "Collaborated on low-code applications, workflow improvements, and rapid prototypes that became functional team solutions.")
    ];

    public async Task OnGetAsync(CancellationToken cancellationToken)
    {
        Quote = await dailyQuoteService.GetTodayAsync(cancellationToken);
    }
}
