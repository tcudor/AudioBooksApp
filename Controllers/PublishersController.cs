using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using AudioBooksApp.Models;
using AudioBooksApp.Services;
using AudioBooksApp.Data.Services;

public class PublishersController : Controller
{
    private readonly IPublishersService _service;

    public PublishersController(IPublishersService service)
    {
        _service = service;
    }

    public async Task<IActionResult> Index()
    {
        var allPublishers = await _service.GetAllAsync();
        return View(allPublishers);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(Publisher publisher)
    {
        if (!ModelState.IsValid)
        {
            return View(publisher);
        }

        await _service.AddAsync(publisher);
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Edit(int id)
    {
        var publisherDetails = await _service.GetByIdAsync(id);

        if (publisherDetails == null)
        {
            return View("NotFound");
        }

        return View(publisherDetails);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(int id, Publisher publisher)
    {
        if (!ModelState.IsValid)
        {
            return View(publisher);
        }

        await _service.UpdateAsync(id, publisher);
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Details(int id)
    {
        var publisherDetails = await _service.GetByIdAsync(id);

        if (publisherDetails == null)
        {
            return View("NotFound");
        }

        return View(publisherDetails);
    }

    public async Task<IActionResult> Delete(int id)
    {
        var publisherDetails = await _service.GetByIdAsync(id);

        if (publisherDetails == null)
        {
            return View("NotFound");
        }

        return View(publisherDetails);
    }

    [HttpPost, ActionName("Delete")]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        await _service.DeleteAsync(id);
        return RedirectToAction(nameof(Index));
    }
}
