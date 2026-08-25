namespace PortfolioWeb.Models;

public sealed record PortfolioProject(
    string Title,
    string Period,
    string Description,
    IReadOnlyList<string> Technologies,
    string Status);
