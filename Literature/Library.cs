using System.Collections.Generic;
using System.Linq;

namespace Literature
{
    public class Library
    {
        public BookCollection Collection { get; } = new BookCollection();
        public List<Author> Authors { get; } = new List<Author>();
        public List<Genre> Genres { get; } = new List<Genre>();
        public List<Hall> Halls { get; } = new List<Hall>();
        public List<Publisher> Publishers { get; } = new List<Publisher>();

        private int nextBookId = 1;

        public Library()
        {
            CreateData();
        }

        private void CreateData()
        {
            Authors.AddRange(new[]
            {
                new Author(1, "А. С. Пушкин", 1799),
                new Author(2, "Ф. М. Достоевский", 1821),
                new Author(3, "Л. Н. Толстой", 1828),
                new Author(4, "А. П. Чехов", 1860),
                new Author(5, "М. Ю. Лермонтов", 1814),
                new Author(6, "Н. В. Гоголь", 1809),
                new Author(7, "И. С. Тургенев", 1818),
                new Author(8, "М. А. Булгаков", 1891),
                new Author(9, "А. И. Куприн", 1870),
                new Author(10, "И. А. Крылов", 1769),
                new Author(11, "Н. А. Некрасов", 1821),
                new Author(12, "А. А. Блок", 1880),
                new Author(13, "С. А. Есенин", 1895),
                new Author(14, "М. Горький", 1868),
                new Author(15, "И. А. Гончаров", 1812),
                new Author(16, "Д. И. Фонвизин", 1745),
                new Author(17, "А. Н. Островский", 1823),
                new Author(18, "Р. Брэдбери", 1920),
                new Author(19, "Дж. Оруэлл", 1903),
                new Author(20, "Дж. Р. Р. Толкин", 1892)
            });

            Genres.AddRange(new Genre[]
            {
                new FictionGenre("Роман"),
                new FictionGenre("Повесть"),
                new FictionGenre("Рассказ"),
                new FictionGenre("Поэма"),
                new FictionGenre("Стихотворение"),
                new FictionGenre("Комедия"),
                new FictionGenre("Фантастика"),
                new FictionGenre("Басня"),
                new FictionGenre("Антиутопия"),
                new FictionGenre("Фэнтези"),
                new EducationalGenre("Учебная литература"),
                new EducationalGenre("Научная литература")
            });

            Halls.AddRange(new[]
            {
                new Hall(1, "Художественный зал",
                    "Романы, повести и рассказы"),
                new Hall(2, "Поэтический зал",
                    "Поэзия и драматургия"),
                new Hall(3, "Учебный зал",
                    "Учебная и научная литература")
            });

            Publishers.AddRange(new[]
            {
                new Publisher("Эксмо", "Москва"),
                new Publisher("АСТ", "Москва"),
                new Publisher("Азбука", "Санкт-Петербург"),
                new Publisher("Просвещение", "Москва")
            });

            // начальный каталог
            AddBook("Евгений Онегин", 1, "Поэма", 1833, 224, 2);
            AddBook("Капитанская дочка", 1, "Повесть", 1836, 192, 1);
            AddBook("Дубровский", 1, "Роман", 1841, 224, 1);
            AddBook("Пиковая дама", 1, "Повесть", 1834, 96, 1);
            AddBook("Руслан и Людмила", 1, "Поэма", 1820, 160, 2);

            AddBook("Преступление и наказание", 2, "Роман", 1866, 672, 1);
            AddBook("Идиот", 2, "Роман", 1869, 640, 1);
            AddBook("Братья Карамазовы", 2, "Роман", 1880, 880, 1);
            AddBook("Игрок", 2, "Роман", 1866, 256, 1);
            AddBook("Белые ночи", 2, "Повесть", 1848, 128, 1);

            AddBook("Война и мир", 3, "Роман", 1869, 1300, 1);
            AddBook("Анна Каренина", 3, "Роман", 1877, 864, 1);
            AddBook("Воскресение", 3, "Роман", 1899, 640, 1);
            AddBook("Детство", 3, "Повесть", 1852, 192, 1);
            AddBook("Кавказский пленник", 3, "Рассказ", 1872, 64, 1);

            AddBook("Вишнёвый сад", 4, "Комедия", 1904, 128, 2);
            AddBook("Чайка", 4, "Комедия", 1896, 144, 2);
            AddBook("Палата № 6", 4, "Рассказ", 1892, 96, 1);

            AddBook("Герой нашего времени", 5, "Роман", 1840, 256, 1);
            AddBook("Мцыри", 5, "Поэма", 1840, 80, 2);

            AddBook("Мёртвые души", 6, "Роман", 1842, 352, 1);
            AddBook("Ревизор", 6, "Комедия", 1836, 160, 2);

            AddBook("Отцы и дети", 7, "Роман", 1862, 320, 1);
            AddBook("Муму", 7, "Рассказ", 1854, 64, 1);

            AddBook("Мастер и Маргарита", 8, "Роман", 1967, 480, 1);
            AddBook("Собачье сердце", 8, "Повесть", 1925, 160, 1);

            AddBook("Гранатовый браслет", 9, "Повесть", 1911, 128, 1);
            AddBook("Олеся", 9, "Повесть", 1898, 160, 1);

            AddBook("Ворона и Лисица", 10, "Басня", 1808, 16, 2);
            AddBook("Квартет", 10, "Басня", 1811, 16, 2);

            AddBook("Кому на Руси жить хорошо", 11, "Поэма", 1877, 320, 2);
            AddBook("Мороз, Красный нос", 11, "Поэма", 1863, 128, 2);

            AddBook("Двенадцать", 12, "Поэма", 1918, 64, 2);
            AddBook("Незнакомка", 12, "Стихотворение", 1906, 32, 2);

            AddBook("Анна Снегина", 13, "Поэма", 1925, 80, 2);
            AddBook("Чёрный человек", 13, "Поэма", 1925, 48, 2);

            AddBook("На дне", 14, "Комедия", 1902, 160, 2);
            AddBook("Детство", 14, "Повесть", 1913, 224, 1);

            AddBook("Обломов", 15, "Роман", 1859, 640, 1);
            AddBook("Обыкновенная история", 15, "Роман", 1847, 384, 1);
        }

        private void AddBook(
            string title,
            int authorId,
            string genreName,
            int year,
            int pages,
            int hallId)
        {
            Author author = Authors.First(a => a.Id == authorId);
            Genre genre = Genres.First(g => g.Name == genreName);
            Hall hall = Halls.First(h => h.Id == hallId);
            Publisher publisher = Publishers[(nextBookId - 1) % Publishers.Count];

            Collection.Add(new Book(
                nextBookId++,
                title,
                author,
                genre,
                publisher,
                hall,
                year,
                pages));
        }

        public void AddBook(Book book)
        {
            Collection.Add(book);
            nextBookId = System.Math.Max(nextBookId, book.Id + 1);
        }

        public void ShowAuthors()
        {
            foreach (Author author in Authors)
            {
                System.Console.WriteLine(author);
            }
        }

        public void ShowGenres()
        {
            foreach (Genre genre in Genres)
            {
                System.Console.WriteLine(genre.GetInfo());
            }
        }

        public void ShowHalls()
        {
            foreach (Hall hall in Halls)
            {
                System.Console.WriteLine(hall);
            }
        }
    }
}