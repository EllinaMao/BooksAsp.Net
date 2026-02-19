using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Services;
using WebApplication1.ViewModels;

public class BookController : Controller
{
    private readonly BookService _bookService;

    public BookController(BookService bookService)
    {
        _bookService = bookService;
    }

    public IActionResult Index() => View(_bookService.GetBooks());

    [HttpGet]
    public IActionResult Add() => View();

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Add(BookViewModel model)
    {
        if (!ModelState.IsValid) return View(model);

        var newBook = new BookModel
        {
            Id = Guid.NewGuid(),
            Title = model.Title,
            Author = model.Author,
            Genre = model.Genre, 
            Year = model.Year
        };

        _bookService.AddBook(newBook);
        return RedirectToAction(nameof(Index));
    }

    public IActionResult Delete(Guid id)
    {
        _bookService.RemoveBook(id);
        return RedirectToAction(nameof(Index));
    }
    public IActionResult Edit(Guid id)
    {
        var book = _bookService.GetBookById(id);
        if (book == null) return NotFound();
        var model = new BookViewModel
        {
            Id = book.Id,
            Title = book.Title,
            Author = book.Author,
            Genre = book.Genre,
            Year = book.Year
        };
        return View(model);
    }


}