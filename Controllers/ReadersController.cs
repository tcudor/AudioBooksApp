using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using AudioBooksApp.Models;
using AudioBooksApp.Services;
using AudioBooksApp.Data.Services;

public class ReadersController : Controller
{
    private readonly IReadersService _service;

    public ReadersController(IReadersService service)
    {
        _service = service;
    }

    public async Task<IActionResult> Index()
    {
        var allReaders = await _service.GetAllAsync();
        return View(allReaders);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(Reader reader)
    {
        if (!ModelState.IsValid)
        {
            return View(reader);
        }

        await _service.AddAsync(reader);
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Edit(int id)
    {
        var readerDetails = await _service.GetByIdAsync(id);

        if (readerDetails == null)
        {
            return View("NotFound");
        }

        return View(readerDetails);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(int id, Reader reader)
    {
        if (!ModelState.IsValid)
        {
            return View(reader);
        }

        await _service.UpdateAsync(id, reader);
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Details(int id)
    {
        var readerDetails = await _service.GetByIdAsync(id);

        if (readerDetails == null)
        {
            return View("NotFound");
        }

        return View(readerDetails);
    }

    public async Task<IActionResult> Delete(int id)
    {
        var readerDetails = await _service.GetByIdAsync(id);

        if (readerDetails == null)
        {
            return View("NotFound");
        }

        return View(readerDetails);
    }

    [HttpPost, ActionName("Delete")]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        await _service.DeleteAsync(id);
        return RedirectToAction(nameof(Index));
    }
}
