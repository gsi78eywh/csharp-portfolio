using Microsoft.AspNetCore.Mvc.RazorPages;
using PortfolioWeb.Models;
using PortfolioWeb.Services;

namespace PortfolioWeb.Pages;

public class IndexModel(IDailyQuoteService dailyQuoteService) : PageModel
{
    public string Name { get; } = "Seth Andrey Jabagat";
    public string Location { get; } = "Dalaguete, Cebu, Philippines";
    public string LocationMapUrl { get; } =
        "https://www.google.com/maps/place/Tabon+Basketball+Court/@9.7981585,123.4582484,3a,75y,108.54h,73.58t/data=!3m7!1e1!3m5!1sGzEBHVwtvuhXC13VygCQRQ!2e0!6shttps:%2F%2Fstreetviewpixels-pa.googleapis.com%2Fv1%2Fthumbnail%3Fcb_client%3Dmaps_sv.tactile%26w%3D900%26h%3D600%26pitch%3D16.420519482182442%26panoid%3DGzEBHVwtvuhXC13VygCQRQ%26yaw%3D108.5382099495906!7i16384!8i8192!4m6!3m5!1s0x33abbfdcddb94675:0xbe784992ef73d705!8m2!3d9.7872168!4d123.4482756!16s%2Fg%2F11g_jg31y?entry=ttu&g_ep=EgoyMDI2MDkwOC4wIKXMDSoASAFQAw%3D%3D";
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
        new("Microsoft Power Platform & Cloud",
        [
            new("Power Apps", 9, "Advanced (9/10)", "purple", "powerapps", "Custom Canvas & Model-driven applications with responsive multi-screen UX"),
            new("Power Automate", 9, "Advanced (9/10)", "blue", "powerautomate", "Automated multi-tier approval flows, scheduled jobs, and trigger logic"),
            new("SharePoint", 9, "Advanced (9/10)", "teal", "sharepoint", "Enterprise list data architecture, document libraries, and access controls"),
            new("Microsoft 365", 8, "Proficient (8/10)", "sky", "ms365", "Teams integration, Outlook automation, and organizational workflows"),
            new("Dataverse", 7, "Skilled (7/10)", "indigo", "dataverse", "Common Data Model entities, business rules, and relational data stores")
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
        new("Frontend",
        [
            new("HTML", 9, "Advanced (9/10)", "orange", "html", "Semantic HTML5, accessible layouts, and SEO best practices"),
            new("CSS", 9, "Advanced (9/10)", "blue", "css", "Modern CSS3, responsive Flexbox/Grid systems, and custom properties"),
            new("JavaScript", 7, "Skilled (7/10)", "yellow", "js", "ES6+ syntax, asynchronous fetch, and dynamic DOM manipulation"),
            new("TypeScript", 8, "Proficient (8/10)", "sky", "ts", "Static typing, component contracts, and interface definitions"),
            new("React", 8, "Proficient (8/10)", "cyan", "react", "Component lifecycle, state management, hooks, and responsive SPAs"),
            new("Tailwind CSS", 8, "Proficient (8/10)", "teal", "tailwind", "Utility-first design, fluid responsive sizing, and rapid prototyping")
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
        "Google Data Analytics Professional Specialization",
        "Using Python to Interact with the Operating System (Google)",
        "Crash Course on Python (Google)",
        "Google UI/UX Design Fundamentals"
    ];

    public IReadOnlyList<CourseItem> AcademicCourses { get; } =
    [
        new("Object-Oriented Programming", "C# & Java Architecture", "Completed & Validated"),
        new("Database Management Systems", "Relational SQL & Schema Design", "Completed & Validated"),
        new("Rapid Application Development", "Agile Prototyping & Low-Code", "Completed & Validated"),
        new("Data Structures & Algorithms", "Core Computational Logic", "Completed & Validated"),
        new("Web Systems & Technologies", "Full-Stack Web Engineering", "Completed & Validated"),
        new("Systems Integration & Architecture", "Enterprise APIs & Workflows", "Completed & Validated")
    ];

    public int ShippedProjectsCount => Projects.Count;
    public int RepositoriesCount => Projects.Count(p => !string.IsNullOrWhiteSpace(p.RepositoryUrl));

    public IReadOnlyList<PortfolioProject> Projects { get; } =
    [
        new(
            "Library Management System",
            "Academic Platform · Database Architecture",
            "Web-based catalog platform with responsive search, borrowing records, and real-time inventory tracking; streamlined resource access for 70% of student users.",
            ["Responsive UI", "Database Design", "Academic Project"],
            "Completed"),
        new(
            "Hotel Booking System",
            "Full-Stack Web App · Laravel & MySQL",
            "Full-stack reservation platform built with Laravel and MySQL, managing room inventories, guest billing, check-in schedules, and role-based staff workflows.",
            ["PHP", "Laravel", "MySQL"],
            "Full-Stack",
            "https://github.com/gsi78eywh/Saystem"),
        new(
            "Activity Proposal System",
            "Enterprise Workflow · Microsoft Power Platform",
            "Microsoft Power Platform enterprise workflow automating budget requests, organizational proposal compliance, multi-tier approvals, and financial audits for Ramon Aboitiz Foundation Inc.",
            ["Power Apps", "Power Automate", "SharePoint", "Reporting"],
            "Power Platform",
            null,
            "/images/projects/activity-proposal.png",
            "Activity Proposal System login interface at Ramon Aboitiz Foundation Inc."),
        new(
            "REACH System — Relief Automated Messaging",
            "Disaster Relief Platform · React & SMS Automation",
            "Emergency disaster relief system coordinating automated SMS broadcasts, distribution checkpoints, and household duplicate-aid verification.",
            ["React", "SMS Workflow", "Community Data"],
            "Prototype",
            "https://github.com/gsi78eywh/REACH-v4")
    ];

    public IReadOnlyList<WorkExperienceItem> WorkExperience { get; } =
    [
        new(
            "Ramon Aboitiz Foundation Inc.",
            "https://rafi.org.ph/",
            "Software Developer — Microsoft Platforms Developer",
            "6 Months",
            "Internship · 6 Months",
            "Internship",
            "Served as Software Developer focusing on Microsoft Power Platform, custom enterprise applications, workflow automations, and backend developer support across foundation initiatives.",
            [
                new(
                    "Seat Booking App",
                    "Full-Stack / Power Platform Developer",
                    "Developed an internal hot-desking and office seat reservation application utilizing Power Apps, automated booking validation via Power Automate, and SharePoint list data architecture to streamline on-site workspace allocation.",
                    "Internal Solution"),
                new(
                    "Activity Proposal System",
                    "Backend Developer Support",
                    "Delivered backend logic, validation checks, and multi-tier approval routing to handle organization-wide event budgets, organizational proposal compliance, and audit requirements.",
                    "Enterprise Workflow",
                    null,
                    "/images/projects/activity-proposal.png"),
                new(
                    "VPIN Platform",
                    "Developer Support",
                    "Assisted in technical maintenance, feature support, and system integration for the foundation's VPIN initiative.",
                    "Foundation Initiative"),
                new(
                    "User Manual & Documentation",
                    "Technical Enablement Support",
                    "Authored comprehensive end-user manuals and step-by-step procedural guides to ensure smooth onboarding, operational adherence, and system adoption.",
                    "Documentation")
            ],
            ["Power Apps", "Power Automate", "SharePoint", "Full-Stack", "Backend Support", "Microsoft 365", "Technical Writing"]),

        new(
            "Oasis Infobyte",
            "https://oasisinfobyte.com/",
            "Application Developer Intern",
            "1 Month",
            "Internship · 1 Month",
            "Internship",
            "Built and shipped core mobile and interactive software utilities, focusing on clean software architecture, responsive UI components, persistent data storage, and AI-accelerated delivery.",
            [
                new(
                    "Todo App",
                    "Android & Mobile Developer",
                    "Task management and productivity application featuring task scheduling, dynamic status updates, and local database persistence.",
                    "Mobile App",
                    "https://github.com/gsi78eywh/OIBSIP"),
                new(
                    "Stopwatch",
                    "Application Developer",
                    "High-precision timer utility with responsive start/pause/lap recording controls and smooth millisecond tick rendering.",
                    "Mobile Utility",
                    "https://github.com/gsi78eywh/OIBSIP"),
                new(
                    "Quiz App",
                    "Application Developer",
                    "Interactive assessment application featuring category-based question sets, dynamic countdown timers, and immediate scoring metrics.",
                    "Interactive App",
                    "https://github.com/gsi78eywh/OIBSIP"),
                new(
                    "Unit Converter",
                    "Application Developer",
                    "Multi-category conversion platform supporting weight, length, temperature, and currency with real-time reactive calculation.",
                    "Utility Tool",
                    "https://github.com/gsi78eywh/OIBSIP")
            ],
            ["Java", "Android Studio", "XML", "Supabase", "SQLite", "JavaScript", "Mobile UI/UX"],
            "AI-Assisted Coding & Agent Support (Accelerated prototyping, prompt engineering, and code quality workflows)",
            "https://github.com/gsi78eywh/OIBSIP")
    ];

    public IReadOnlyList<ExperienceItem> Experience { get; } =
    [
        new(
            "Youth Empowerment Participant",
            "January 2025 – Present",
            "Build leadership, technical communication, and digital collaboration skills through workshops and community peer learning."),
        new(
            "Alliance Student Developer",
            "August – December 2025",
            "Collaborated on low-code applications, workflow improvements, and rapid prototypes that became functional team solutions."),
        new(
            "Industry Learning — Accenture & AI Talks",
            "January – February 2026",
            "Studied practical AI, cloud infrastructure, and enterprise technology trends through technical talks, case examples, and Q&A sessions.")
    ];

    public async Task OnGetAsync(CancellationToken cancellationToken)
    {
        Quote = await dailyQuoteService.GetTodayAsync(cancellationToken);
    }
}
