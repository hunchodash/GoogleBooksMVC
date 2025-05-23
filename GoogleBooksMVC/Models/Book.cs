namespace GoogleBooksMVC.Models
{
    public class Book
    {
        public string Id { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string[] Authors { get; set; } = Array.Empty<string>();
        public string Publisher { get; set; } = string.Empty;
        public string PublishedDate { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int PageCount { get; set; }
        public string Thumbnail { get; set; } = string.Empty;
        public string PreviewLink { get; set; } = string.Empty;
    }
}
