using System.Net.Http.Json;
using GoogleBooksMVC.Models;

namespace GoogleBooksMVC.Services
{
    public class GoogleBooksService
    {
        private readonly HttpClient _httpClient;
        private const string ApiBaseUrl = "https://www.googleapis.com/books/v1/";

        public GoogleBooksService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(ApiBaseUrl);
        }

        public async Task<BookSearchResult> SearchBooksAsync(string query, int maxResults = 10)
        {
            try
            {
                var response = await _httpClient.GetFromJsonAsync<GoogleBooksApiResponse>(
                    $"volumes?q={Uri.EscapeDataString(query)}&maxResults={maxResults}");

                return response?.ToBookSearchResult() ?? new BookSearchResult();
            }
            catch (HttpRequestException)
            {
                return new BookSearchResult();
            }
        }
    }


    public class GoogleBooksApiResponse
    {
        public int TotalItems { get; set; }
        public List<GoogleBookItem> Items { get; set; } = new();

        public BookSearchResult ToBookSearchResult() => new()
        {
            TotalItems = TotalItems,
            Items = Items.Select(item => item.ToBook()).ToList()
        };
    }

    public class GoogleBookItem
    {
        public string Id { get; set; } = string.Empty;
        public VolumeInfo VolumeInfo { get; set; } = new();

        public Book ToBook() => new()
        {
            Id = Id,
            Title = VolumeInfo.Title ?? "N/A",
            Authors = VolumeInfo.Authors?.ToArray() ?? new[] { "Autore sconosciuto" },
            Publisher = VolumeInfo.Publisher ?? "N/A",
            PublishedDate = VolumeInfo.PublishedDate ?? "N/A",
            Description = VolumeInfo.Description ?? "Nessuna descrizione disponibile",
            PageCount = VolumeInfo.PageCount ?? 0,
            Thumbnail = VolumeInfo.ImageLinks?.Thumbnail?.Replace("http://", "https://")
                       ?? "https://via.placeholder.com/128x196?text=No+Cover",
            PreviewLink = VolumeInfo.PreviewLink ?? $"https://books.google.com/books?id={Id}"
        };
    }

    public class VolumeInfo
    {
        public string? Title { get; set; }
        public List<string>? Authors { get; set; }
        public string? Publisher { get; set; }
        public string? PublishedDate { get; set; }
        public string? Description { get; set; }
        public int? PageCount { get; set; }
        public ImageLinks? ImageLinks { get; set; }
        public string? PreviewLink { get; set; }
    }

    public class ImageLinks
    {
        public string? Thumbnail { get; set; }
    }
}