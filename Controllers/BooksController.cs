using AudioBooksApp.Data.Services;
using AudioBooksApp.Data.ViewModels;
using AudioBooksApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;

namespace AudioBooksApp.Controllers
{
    
    public class BooksController : Controller
    {
        private readonly IBooksService _service;

        public BooksController(IBooksService service)
        {
            _service = service;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var allBooks = await _service.GetAllBooks();
            return View(allBooks);
        }

        public async Task<IActionResult> Details(int id)
        {
            var bookDetails = await _service.GetBookByIdAsync(id);
            if (bookDetails == null) return View("NotFound");
            return View(bookDetails);
        }

        public async Task<IActionResult> Create()
        {
            var bookDropdownsData = await _service.GetNewBookDropdownsValues();
            ViewBag.Readers = new SelectList(bookDropdownsData.Readers, "Id", "Name");
            ViewBag.Publishers = new SelectList(bookDropdownsData.Publishers, "Id", "Name");
            ViewBag.Authors = new SelectList(bookDropdownsData.Authors, "Id", "Name");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(NewBookVM book)
        {
            if (!ModelState.IsValid)
            {
                var bookDropdownsData = await _service.GetNewBookDropdownsValues();
                ViewBag.Readers = new SelectList(bookDropdownsData.Readers, "Id", "Name");
                ViewBag.Publishers = new SelectList(bookDropdownsData.Publishers, "Id", "Name");
                ViewBag.Authors = new SelectList(bookDropdownsData.Authors, "Id", "Name");
                return View(book);
            }

            await _service.AddNewBookAsync(book);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var bookDetails = await _service.GetBookByIdAsync(id);
            if (bookDetails == null) return View("NotFound");

            var response = new NewBookVM()
            {
                Id = bookDetails.Id,
                Title = bookDetails.Title,
                Price = bookDetails.Price,
                Length = bookDetails.Length,
                ImageUrl = bookDetails.ImageUrl,
                AudioFilePath = bookDetails.AudioFilePath,
                PublicationDate = bookDetails.PublicationDate,
                Category = bookDetails.Category,
                AuthorId = bookDetails.AuthorId,
                PublisherId = bookDetails.PublisherId,
                ReaderId = bookDetails.ReaderId
            };

            var bookDropdownsData = await _service.GetNewBookDropdownsValues();
            ViewBag.Readers = new SelectList(bookDropdownsData.Readers, "Id", "Name");
            ViewBag.Publishers = new SelectList(bookDropdownsData.Publishers, "Id", "Name");
            ViewBag.Authors = new SelectList(bookDropdownsData.Authors, "Id", "Name");

            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, NewBookVM book)
        {
            if (id != book.Id) return View("NotFound");
            if (!ModelState.IsValid)
            {
                var bookDropdownsData = await _service.GetNewBookDropdownsValues();
                ViewBag.Readers = new SelectList(bookDropdownsData.Readers, "Id", "Name");
                ViewBag.Publishers = new SelectList(bookDropdownsData.Publishers, "Id", "Name");
                ViewBag.Authors = new SelectList(bookDropdownsData.Authors, "Id", "Name");
                return View(book);
            }

            await _service.UpdateBookAsync(book);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var bookDetails = await _service.GetBookByIdAsync(id);
            if (bookDetails == null) return View("NotFound");
            return View(bookDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> Delete(int id, NewBookVM book)
        {
            var bookDetails = await _service.GetBookByIdAsync(id);
            if (id != book.Id) return View("NotFound");
            await _service.DeleteAsync(id);
            return RedirectToAction("Index");
        }
    }
}
