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

public sealed record SkillRating(
    string Name,
    int Rating,
    string Level,
    string DotColor = "blue",
    string IconKey = "",
    string Description = "")
{
    public int Percentage => Rating * 10;
}

public sealed record SkillCategoryWithRatings(
    string Category,
    IReadOnlyList<SkillRating> Skills);

public sealed record ExperienceItem(
    string Role,
    string Period,
    string Description);

public sealed record DailyQuote(
    string Text,
    string Author,
    bool IsFromApi);
