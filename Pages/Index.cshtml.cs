using Microsoft.AspNetCore.Mvc.RazorPages;
using PortfolioWeb.Models;
using PortfolioWeb.Services;

namespace PortfolioWeb.Pages;

public class IndexModel(IDailyQuoteService dailyQuoteService) : PageModel
{
    public string Name { get; } = "Seth Andrey Jabagat";
    public string Location { get; } = "Dalaguete, Cebu, Philippines";
    public string Role { get; } = "Microsoft Power Platform Developer | UI/UX Designer";
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
            "University of San Jose – Recoletos"),
        new(
            "Senior High School",
            "2021 – 2023",
            "Mantalongon National High School, Dalaguete, Cebu")
    ];

    public IReadOnlyList<SkillGroup> TechStack { get; } =
    [
        new("Microsoft Ecosystem", ["Microsoft Power Platform", "Microsoft 365", "C#", "ASP.NET Core"]),
        new("Web & Data", ["HTML", "CSS", "JavaScript", "PHP", "Laravel", "MySQL"]),
        new("Cloud & Deployment", ["Microsoft Azure", "Vercel", "Render", "Docker", "GitHub"]),
        new("AI & Design Workflow", ["GitHub Copilot", "Microsoft Copilot", "ChatGPT", "VS Code", "UI/UX Design"])
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
            "Hotel Booking System",
            "School Project",
            "Developed a hotel booking system using PHP and the Laravel framework, applying full-stack development practices to organize reservations and booking workflows.",
            ["PHP", "Laravel", "Full-Stack Development"],
            "PHP / Laravel"),
        new(
            "Activity Proposal System",
            "Company Project",
            "Built a Microsoft Power Platform solution that generates activity proposals, captures budget and audit requirements, and produces budget and financial reports for review.",
            ["Microsoft Power Platform", "Process Automation", "Financial Reporting"],
            "Power Platform"),
        new(
            "REACH System — Relief Automated Messaging",
            "Community Solution",
            "Designed an automated messaging and relief-coordination system that uses SIM-card notifications to inform residents about aid distribution, barangay events, floods, and earthquakes. The solution also helps identify duplicate aid claims within the same family or household to support fair distribution.",
            ["SMS Automation", "Relief Coordination", "Community Safety"],
            "Solution Design")
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
