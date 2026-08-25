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
        new("Microsoft & Low-Code", ["Power Apps", "Power Automate", "Microsoft 365", "C#", "ASP.NET Core"]),
        new("Web Development", ["HTML", "CSS", "JavaScript", "PHP", "Laravel", "MySQL"]),
        new("Cloud & Delivery", ["Microsoft Azure", "Vercel", "Render", "Docker", "GitHub"]),
        new("Design & AI Workflow", ["UI/UX Design", "Responsive Design", "GitHub Copilot", "Microsoft Copilot", "ChatGPT", "VS Code"])
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

    public IReadOnlyList<PortfolioProject> Projects { get; } =
    [
        new(
            "Library Management System",
            "Aug 2025 – Nov 2025",
            "Responsive school system for catalog access and resource discovery; 70% of surveyed users reported easier access to learning resources.",
            ["Responsive UI", "Database Design", "Academic Project"],
            "Completed"),
        new(
            "Hotel Booking System",
            "School Project",
            "Laravel reservation and operations system covering rooms, guests, bookings, check-in, billing, and role-based workflows.",
            ["PHP", "Laravel", "MySQL"],
            "Full-Stack",
            "https://github.com/gsi78eywh/Saystem"),
        new(
            "Activity Proposal System",
            "Company Project",
            "Power Platform workflow that standardizes proposals, budget requests, audit requirements, approvals, and financial reporting.",
            ["Power Apps", "Power Automate", "Reporting"],
            "Power Platform"),
        new(
            "REACH System — Relief Automated Messaging",
            "Community Solution",
            "Community relief platform for SMS notices, emergency alerts, distribution updates, and household-level duplicate-aid checks.",
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
