using System.Collections.Generic;
using System.Linq;

namespace Literature
{
    // класс для хранения, добавления и получения списка книг
    public class BookCollection
    {
        private List<Book> books = new List<Book>();

        // свойство только для чтения для списка books
        public IReadOnlyList<Book> Books => books;

        public void Add(Book book)
        {
            books.Add(book);
        }

        // ? явно указывает на то что может быть возвращен null
        public Book? FindById(int id)
        {
            // возвращаем тот элемент списка book, в котором нужный id
            return books.FirstOrDefault(book => book.Id == id);
        }

        public List<Book> GetAll()
        {
            return books.ToList();
        }

        public int Count()
        {
            return books.Count;
        }
    }
}