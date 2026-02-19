using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class BookModel
    {
        public Guid Id { get; set; } = new Guid();
        public string Title { get; set; }
        public string Author { get; set; }

        public Genre Genre { get; set; }
      
        public int Year { get; set; }

    }
}

