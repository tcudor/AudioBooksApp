using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using AudioBooksApp.Models;
using AudioBooksApp.Services;
using AudioBooksApp.Data.Services;
using AudioBooksApp.Data.Static;
using Microsoft.AspNetCore.Authorization;
using System.Data;

[Authorize(Roles = UserRoles.Admin)]
public class AuthorsController : Controller
{
    private readonly IAuthorsService _service;

    public AuthorsController(IAuthorsService service)
    {
        _service = service;
    }

    public async Task<IActionResult> Index()
    {
        var allAuthors = await _service.GetAllAsync();
        return View(allAuthors);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(Author author)
    {
        if (!ModelState.IsValid)
        {
            return View(author);
        }

        await _service.AddAsync(author);
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Edit(int id)
    {
        var authorDetails = await _service.GetByIdAsync(id);

        if (authorDetails == null)
        {
            return View("NotFound");
        }

        return View(authorDetails);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(int id, Author author)
    {
        if (!ModelState.IsValid)
        {
            return View(author);
        }

        await _service.UpdateAsync(id, author);
        return RedirectToAction(nameof(Index));
    }

    [AllowAnonymous]
    public async Task<IActionResult> Details(int id)
    {
        var authorDetails = await _service.GetByIdAsync(id);

        if (authorDetails == null)
        {
            return View("NotFound");
        }

        return View(authorDetails);
    }

    public async Task<IActionResult> Delete(int id)
    {
        var authorDetails = await _service.GetByIdAsync(id);

        if (authorDetails == null)
        {
            return View("NotFound");
        }

        return View(authorDetails);
    }

    [HttpPost, ActionName("Delete")]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        await _service.DeleteAsync(id);
        return RedirectToAction(nameof(Index));
    }
}
