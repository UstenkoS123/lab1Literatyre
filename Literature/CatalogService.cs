using System.Collections.Generic;

namespace Literature
{
    public class CatalogService : IBookSearch
    {
        public List<Book> Search(
            IEnumerable<Book> books,
            string query)
            // query - поисковый запрос пользователя
        {
            List<Book> result = new List<Book>();

            foreach (Book book in books)
            {
                if (book.Title.Contains(query, System.StringComparison.OrdinalIgnoreCase)
                    || book.Author.Name.Contains(query, System.StringComparison.OrdinalIgnoreCase)
                    || book.Genre.Name.Contains(query, System.StringComparison.OrdinalIgnoreCase))
                {
                    result.Add(book);
                }
            }

            return result;
        }

        public List<Book> FilterByGenre(
            IEnumerable<Book> books,
            string genre)
        {
            List<Book> result = new List<Book>();

            foreach (Book book in books)
            {
                if (book.Genre.Name.Contains(
                    genre,
                    System.StringComparison.OrdinalIgnoreCase))
                {
                    result.Add(book);
                }
            }

            return result;
        }

        public List<Book> FilterByHall(
            IEnumerable<Book> books,
            int hallId)
        {
            List<Book> result = new List<Book>();

            foreach (Book book in books)
            {
                if (book.Hall.Id == hallId)
                {
                    result.Add(book);
                }
            }

            return result;
        }
    }
}
