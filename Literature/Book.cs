namespace Literature
{
    public class Book
    {
        public int Id { get; private set; }
        public string Title { get; set; }
        public Author Author { get; set; }
        public Genre Genre { get; set; }
        public Publisher Publisher { get; set; }
        public Hall Hall { get; set; }
        public int Year { get; set; }
        public int Pages { get; set; }

        public Book(
            int id,
            string title,
            Author author,
            Genre genre,
            Publisher publisher,
            Hall hall,
            int year,
            int pages)
        {
            Id = id;
            Title = title;
            Author = author;
            Genre = genre;
            Publisher = publisher;
            Hall = hall;
            Year = year;
            Pages = pages;
        }

        public string GetInfo()
        {
            return $"{Id}. {Title} | автор: {Author.Name} | " +
                   $"жанр: {Genre.Name} | год: {Year} | " +
                   $"страниц: {Pages} | зал: {Hall.Name} | " +
                   $"издательство: {Publisher.Name}";
        }
    }
}