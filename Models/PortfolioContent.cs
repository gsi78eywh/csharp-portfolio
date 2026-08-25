namespace PortfolioWeb.Models;

public sealed record EducationItem(
    string Program,
    string Period,
    string School,
    string ImagePath,
    string ImageAlt,
    string WebsiteUrl,
    bool UseContainedImage = false);

public sealed record SkillGroup(
    string Category,
    IReadOnlyList<string> Skills);

public sealed record ExperienceItem(
    string Role,
    string Period,
    string Description);

public sealed record DailyQuote(
    string Text,
    string Author,
    bool IsFromApi);
