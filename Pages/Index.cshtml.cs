using Microsoft.AspNetCore.Mvc.RazorPages;
using PortfolioWeb.Models;
using PortfolioWeb.Services;

namespace PortfolioWeb.Pages;

public class IndexModel(IDailyQuoteService dailyQuoteService) : PageModel
{
    public string Name { get; } = "Seth Andrey Jabagat";
    public string Location { get; } = "Dalaguete, Cebu, Philippines";
    public string Role { get; } = "Junior Frontend Developer | UI/UX Enthusiast";

    public DailyQuote Quote { get; private set; } = new(
        "Always focus on your own lane. No one finds happiness by pursuing someone else's life path.",
        "Sylvia Salow",
        false);

    public IReadOnlyList<EducationItem> Education { get; } =
    [
        new(
            "Associate in Computer Technology",
            "2024 – 2026",
            "University of San Jose – Recoletos"),
        new(
            "Senior High School",
            "2021 – 2023",
            "Mantalongon National High School, Dalaguete, Cebu")
    ];

    public IReadOnlyList<SkillGroup> TechStack { get; } =
    [
        new("Frontend Development", ["HTML", "CSS", "JavaScript", "React", "Tailwind"]),
        new("Backend Development", ["PHP", "Laravel", "Java", "Node.js", "C#", "ASP.NET Core"]),
        new("Database Development", ["MySQL"]),
        new("Tools & Technologies", ["GitHub", "Docker", "NPM", "Vim", "GitHub Copilot"])
    ];

    public IReadOnlyList<string> Certifications { get; } =
    [
        "Skills to Succeed Academy",
        "Google Data Analytics",
        "Google Coursera Python Automation",
        "Google UI/UX Training Module",
        "Rapid Application Development",
        "Web Development Fundamentals",
        "Database Management Systems"
    ];

    public IReadOnlyList<PortfolioProject> Projects { get; } =
    [
        new(
            "Library Management System",
            "Aug 2025 – Nov 2025",
            "Developed a responsive online library system that improved access to learning resources. In project feedback, 70% of users reported easier access to resources.",
            ["Responsive UI", "Database", "School Project"],
            "Completed"),
        new(
            "Mini E-commerce Frontend",
            "Sep 2025 – Nov 2025",
            "Designed a responsive shopping interface with product browsing, cart management, and a streamlined checkout experience.",
            ["Frontend", "Responsive Design", "UX"],
            "Completed"),
        new(
            "Kombat Console Games",
            "Jul 2025 – Sep 2025",
            "Built a console combat game featuring character selection, turn-based battles, and health tracking to demonstrate programming fundamentals.",
            ["Game Logic", "Console", "Programming Fundamentals"],
            "Completed")
    ];

    public IReadOnlyList<ExperienceItem> Experience { get; } =
    [
        new(
            "Youth Empowerment Participant",
            "January 2025 – Present",
            "Participate in a community initiative focused on leadership and digital skills, collaborating with peers through workshops and discussions."),
        new(
            "AI Talk Participant",
            "February 2026",
            "Explored modern applications of artificial intelligence through speaker sessions and case studies, identifying opportunities for future project integration."),
        new(
            "Tech Talk by Accenture",
            "January 2026",
            "Gained practical insight into industry trends including AI and cloud solutions, with active participation in technical Q&A sessions."),
        new(
            "Alliance Student Developer",
            "Aug – Dec 2025",
            "Collaborated with student developers to create low-code applications, streamline workflows, and turn rapid prototypes into functional solutions.")
    ];

    public async Task OnGetAsync(CancellationToken cancellationToken)
    {
        Quote = await dailyQuoteService.GetTodayAsync(cancellationToken);
    }
}
