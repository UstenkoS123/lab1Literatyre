using System;
using System.Linq;

namespace Literature
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Library library = new Library();
            CatalogService service = new CatalogService();
            bool running = true;

            while (running)
            {
                Console.WriteLine("\n=== Литература ===");
                Console.WriteLine("1. Показать каталог");
                Console.WriteLine("2. Найти книгу");
                Console.WriteLine("3. Показать авторов");
                Console.WriteLine("4. Показать жанры");
                Console.WriteLine("5. Показать залы");
                Console.WriteLine("6. Фильтр по жанру");
                Console.WriteLine("7. Фильтр по залу");
                Console.WriteLine("8. Добавить книгу");
                Console.WriteLine("0. Выход");
                Console.Write("Выберите действие: ");

                string choice = Console.ReadLine() ?? "";

                switch (choice)
                {
                    case "1":
                        foreach (Book book in library.Collection.GetAll())
                        {
                            Console.WriteLine(book.GetInfo());
                        }

                        Console.WriteLine(
                            $"Всего наименований: {library.Collection.Count()}");
                        break;

                    case "2":
                        Console.Write("Название, автор или жанр: ");
                        string query = Console.ReadLine() ?? "";

                        var found = service.Search(
                            library.Collection.Books, query);

                        if (found.Count == 0)
                            Console.WriteLine("Ничего не найдено.");

                        foreach (Book book in found)
                            Console.WriteLine(book.GetInfo());
                        break;

                    case "3":
                        library.ShowAuthors();
                        break;

                    case "4":
                        library.ShowGenres();
                        break;

                    case "5":
                        library.ShowHalls();
                        break;

                    case "6":
                        Console.Write("Введите название жанра: ");
                        string genre = Console.ReadLine() ?? "";

                        var genreBooks = service.FilterByGenre(
                            library.Collection.Books, genre);

                        if (genreBooks.Count == 0)
                            Console.WriteLine("Книги не найдены.");

                        foreach (Book book in genreBooks)
                            Console.WriteLine(book.GetInfo());
                        break;

                    case "7":
                        library.ShowHalls();
                        Console.Write("Введите номер зала: ");

                        if (!int.TryParse(Console.ReadLine(), out int hallId))
                        {
                            Console.WriteLine("Некорректный номер.");
                            break;
                        }

                        var hallBooks = service.FilterByHall(
                            library.Collection.Books, hallId);

                        if (hallBooks.Count == 0)
                            Console.WriteLine("В этом зале книг нет.");

                        foreach (Book book in hallBooks)
                            Console.WriteLine(book.GetInfo());
                        break;

                    case "8":
                        AddBook(library);
                        break;

                    case "0":
                        running = false;
                        break;

                    default:
                        Console.WriteLine("Неверный пункт меню.");
                        break;
                }
            }

            Console.WriteLine("Программа завершена.");
        }

        static void AddBook(Library library)
        {
            Console.Write("Название книги: ");
            string title = Console.ReadLine() ?? "";

            Console.Write("Имя автора: ");
            string authorName = Console.ReadLine() ?? "";

            Console.Write("Год рождения автора: ");
            if (!int.TryParse(Console.ReadLine(), out int birthYear))
            {
                Console.WriteLine("Некорректный год.");
                return;
            }

            Console.Write("Год издания: ");
            if (!int.TryParse(Console.ReadLine(), out int year))
            {
                Console.WriteLine("Некорректный год.");
                return;
            }

            Console.Write("Количество страниц: ");
            if (!int.TryParse(Console.ReadLine(), out int pages)
                || pages < 1)
            {
                Console.WriteLine("Некорректное количество страниц.");
                return;
            }

            library.ShowGenres();
            Console.Write("Введите название существующего жанра: ");
            string genreName = Console.ReadLine() ?? "";

            Genre? genre = library.Genres.FirstOrDefault(g =>
                g.Name.Equals(
                    genreName,
                    StringComparison.OrdinalIgnoreCase));

            if (genre == null)
            {
                Console.WriteLine("Такого жанра нет в каталоге.");
                return;
            }

            library.ShowHalls();
            Console.Write("Введите номер зала: ");

            if (!int.TryParse(Console.ReadLine(), out int hallId))
            {
                Console.WriteLine("Некорректный номер.");
                return;
            }

            Hall? hall = library.Halls.FirstOrDefault(h => h.Id == hallId);

            if (hall == null)
            {
                Console.WriteLine("Такого зала нет.");
                return;
            }

            Author? author = library.Authors.FirstOrDefault(a =>
                a.Name.Equals(
                    authorName,
                    StringComparison.OrdinalIgnoreCase));

            if (author == null)
            {
                author = new Author(
                    library.Authors.Count + 1,
                    authorName,
                    birthYear);

                library.Authors.Add(author);
            }

            Console.WriteLine("Выберите издательство:");

            for (int i = 0; i < library.Publishers.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {library.Publishers[i].Name}");
            }

            Console.Write("Номер издательства: ");

            if (!int.TryParse(Console.ReadLine(), out int publisherId)
                || publisherId < 1
                || publisherId > library.Publishers.Count)
            {
                Console.WriteLine("Некорректное издательство.");
                return;
            }

            Publisher publisher = library.Publishers[publisherId - 1];

            Book book = new Book(
                library.Collection.Count() + 1,
                title,
                author,
                genre,
                publisher,
                hall,
                year,
                pages);

            library.AddBook(book);

            Console.WriteLine("Книга добавлена в каталог.");
        }
    }
}