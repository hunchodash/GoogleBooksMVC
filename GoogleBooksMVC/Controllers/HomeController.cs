using GoogleBooksMVC.Services;
using Microsoft.AspNetCore.Mvc;

namespace GoogleBooksMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly GoogleBooksService _booksService;

        public HomeController(GoogleBooksService booksService)
        {
            _booksService = booksService;
        }

        public async Task<IActionResult> Index(string searchQuery = "dotnet", int maxResults = 10)
        {
            var result = await _booksService.SearchBooksAsync(searchQuery, maxResults);
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> Search(string searchQuery, int maxResults = 10)
        {
            var result = await _booksService.SearchBooksAsync(searchQuery, maxResults);
            return View("Index", result);
        }
    }
}