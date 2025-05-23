using System.Collections.Generic;

namespace GoogleBooksMVC.Models
{
    public class BookSearchResult
    {
        public int TotalItems { get; set; }
        public List<Book> Items { get; set; } = new List<Book>();
    }
}