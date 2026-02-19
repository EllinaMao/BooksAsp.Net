using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class BookService
    {
        private readonly List<BookModel> _books;

        public BookService()
        {
            _books = new List<BookModel>();
        }

        public List<BookModel> GetBooks()
        {
            return _books;
        }

        public void AddBook(BookModel book)
        {
            if (book == null)
                throw new ArgumentNullException(nameof(book));
            if (_books.Contains(book))
                throw new ArgumentException("Book already exists in the collection.", nameof(book));
            _books.Add(book);
        }
        public void RemoveBook(Guid id)
        {
            var book = _books.FirstOrDefault(b => b.Id == id);
            if (book == null)
                throw new ArgumentException("Book not found in the collection.", nameof(id));
            _books.Remove(book);
        }

        public BookModel GetBookById(Guid id)
        {
            var book = _books.FirstOrDefault(b => b.Id == id);
            if (book == null)
                throw new ArgumentException("Book not found in the collection.", nameof(id));
            return book;
        }

        public void UpdateBook(Guid id, BookModel updatedBook)
        {
            if (updatedBook == null)
                throw new ArgumentNullException(nameof(updatedBook));
            var book = _books.FirstOrDefault(b => b.Id == id);
            if (book == null)
                throw new ArgumentException("Book not found in the collection.", nameof(id));
            book.Title = updatedBook.Title;
            book.Author = updatedBook.Author;
            book.Genre = updatedBook.Genre;
            book.Year = updatedBook.Year;
        }





        }
}

/*
 3) Создайте класс «BookService», который будет содержать коллекцию книг и опосредствует к ним доступ. Данный класс добавьте в коллекцию сервисов, с жизненным циклом - Singleton. В качестве альтернативы, можете использовать базу данных через ADO.NET.

 */