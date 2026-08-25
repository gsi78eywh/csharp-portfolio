using PortfolioWeb.Models;

namespace PortfolioWeb.Services;

public interface IDailyQuoteService
{
    Task<DailyQuote> GetTodayAsync(CancellationToken cancellationToken = default);
}
