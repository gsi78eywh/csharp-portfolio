using System.Net.Http.Json;
using System.Text.Json.Serialization;
using Microsoft.Extensions.Caching.Memory;
using PortfolioWeb.Models;

namespace PortfolioWeb.Services;

public sealed class ZenQuotesDailyQuoteService(
    HttpClient httpClient,
    IMemoryCache cache,
    ILogger<ZenQuotesDailyQuoteService> logger) : IDailyQuoteService
{
    private static readonly DailyQuote FallbackQuote = new(
        "Always focus on your own lane. No one finds happiness by pursuing someone else's life path.",
        "Sylvia Salow",
        false);

    public async Task<DailyQuote> GetTodayAsync(CancellationToken cancellationToken = default)
    {
        string cacheKey = $"daily-quote-{DateTime.UtcNow:yyyy-MM-dd}";

        if (cache.TryGetValue(cacheKey, out DailyQuote? cachedQuote) && cachedQuote is not null)
        {
            return cachedQuote;
        }

        try
        {
            IReadOnlyList<ZenQuoteResponse>? response = await httpClient
                .GetFromJsonAsync<IReadOnlyList<ZenQuoteResponse>>("api/today", cancellationToken);

            ZenQuoteResponse? apiQuote = response?.FirstOrDefault();
            if (apiQuote is null || string.IsNullOrWhiteSpace(apiQuote.Quote))
            {
                return CacheFallback(cacheKey);
            }

            var quote = new DailyQuote(
                apiQuote.Quote.Trim(),
                string.IsNullOrWhiteSpace(apiQuote.Author) ? "Unknown" : apiQuote.Author.Trim(),
                true);

            cache.Set(cacheKey, quote, DateTimeOffset.UtcNow.Date.AddDays(1).AddMinutes(5));
            return quote;
        }
        catch (Exception exception) when (exception is HttpRequestException or TaskCanceledException or System.Text.Json.JsonException)
        {
            logger.LogWarning("Daily quote API was unavailable; displaying the built-in fallback quote.");
            return CacheFallback(cacheKey);
        }
    }

    private DailyQuote CacheFallback(string cacheKey)
    {
        cache.Set(cacheKey, FallbackQuote, TimeSpan.FromMinutes(15));
        return FallbackQuote;
    }

    private sealed record ZenQuoteResponse(
        [property: JsonPropertyName("q")] string Quote,
        [property: JsonPropertyName("a")] string Author);
}
