using System.Collections.Generic;

namespace Literature
{
    public interface IBookSearch
    {
        List<Book> Search(
            IEnumerable<Book> books,
            string query);
    }
}