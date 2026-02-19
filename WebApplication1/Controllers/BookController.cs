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

    public IActionResult Index()
    {
        var books = _bookService.GetBooks();

        var viewModel = books.Select(book => new BookViewModel
        {
            Id = book.Id,
            Title = book.Title,
            Author = book.Author,
            Genre = book.Genre,
            Year = book.Year
        }).ToList();

        return View(viewModel);
    }

    [HttpGet]
    public IActionResult Create() => View(); 

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(BookViewModel model) 
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

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(Guid id, BookViewModel model) 
    {
        if (!ModelState.IsValid) return View(model);

        var updatedBook = new BookModel
        {
            Title = model.Title,
            Author = model.Author,
            Genre = model.Genre,
            Year = model.Year
        };

        _bookService.UpdateBook(id, updatedBook); 
        return RedirectToAction(nameof(Index));
    }

    public IActionResult Delete(Guid id)
    {
        _bookService.RemoveBook(id);
        return RedirectToAction(nameof(Index));
    }

    public IActionResult Details(Guid id)
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