using System.ComponentModel.DataAnnotations;

namespace WebApplication1.ViewModels
{
    public class BookViewModel
    {
        [Key]
        public Guid Id { get; set; }
        [StringLength(50)]
        [Required(ErrorMessage = "Необходимо заполнить поле")]
        [Display(Name = "Название книги")]

        public string Title { get; set; }
        [Required(ErrorMessage = "Необходимо заполнить поле")]
        [StringLength(50, ErrorMessage = "Длина не может быть больше 50 символов")]
        [Display(Name = "Автор книги")]
        public string Author { get; set; }
        [Display(Name = "Жанр книги")]
        [Required(ErrorMessage = "Выберите жанр книги")]
        public Genre Genre { get; set; }
        [Display(Name = "Год издания книги" )]
        [Required(ErrorMessage = "Необходимо заполнить поле")]
        [Range(0, int.MaxValue, ErrorMessage = "Год издания должен быть положительным числом")]
        public int Year { get; set; }

    }
}

public enum Genre
{
    [Display(Name = "Научная литература")] Fiction,
    [Display(Name = "Документальная литература")] NonFiction,
    [Display(Name = "Детективная литература")] Mystery,
    [Display(Name = "Научная фантастика")] ScienceFiction,
    [Display(Name = "Фэнтези")] Fantasy,
    [Display(Name = "Биография")] Biography,
    [Display(Name = "Историческая литература")] History,
    [Display(Name = "Романтическая комедия")] RomCom,
    [Display(Name = "Романтическая литература")] Romance,
    [Display(Name = "Триллер")] Thriller
}

/*

2) Создайте ViewModel «BookViewModel», который будет использоваться для передачи данных о книгах между контроллерами и представлениями. В этой ViewModel могут быть только те поля, которые необходимы для отображения и ввода пользователем, например, Title, Author, Genre, Year.



*/