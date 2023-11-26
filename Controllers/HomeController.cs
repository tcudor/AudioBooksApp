using AudioBooksApp.Data;
using AudioBooksApp.Data.Services;
using AudioBooksApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace AudioBooksApp.Controllers
{
    public class HomeController : Controller
    {

        private readonly IBooksService _service;

        public HomeController(IBooksService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            var allBooks = await _service.GetAllBooks();
            return View(allBooks);
        }

        public async Task<IActionResult> Search(string searchString)
        {
            var allBooks = await _service.GetAllBooks();

            if (!string.IsNullOrEmpty(searchString))
            {
                var filteredResultNew = allBooks.Where(n => n.Title.Contains(searchString, StringComparison.CurrentCultureIgnoreCase)).ToList();
                return View("Index", filteredResultNew);
            }

            return View("Index", allBooks);
        }

        public async Task<IActionResult> Sorted(string sortOrder)
        {
            ViewBag.TitleSortParam = sortOrder == "title_desc" ? "title_asc" : "title_desc";
            ViewBag.PriceSortParam = sortOrder == "price" ? "price_desc" : "price";
            var allBooks = await _service.GetAllBooks();

            switch (sortOrder)
            {
                case "title_desc":
                    allBooks = allBooks.OrderBy(n => n.Title).ToList();
                    break;
                case "title_asc":
                    allBooks = allBooks.OrderByDescending(n => n.Title).ToList();
                    break;
                case "price":
                    allBooks = allBooks.OrderBy(n => n.Price).ToList();
                    break;
                case "price_desc":
                    allBooks = allBooks.OrderByDescending(n => n.Price).ToList();
                    break;
                default:
                    allBooks = allBooks.OrderBy(n => n.Title).ToList();
                    break;
            }

            return View("Index", allBooks);
        }





        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}