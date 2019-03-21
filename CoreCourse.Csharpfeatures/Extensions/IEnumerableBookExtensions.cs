using System;
using System.Collections.Generic;
using System.Text;
using CoreCourse.Csharpfeatures.Models;

namespace CoreCourse.Csharpfeatures.Extensions
{
    public static class IEnumerableBookExtensions
    {
        public static int TotalPages(this IEnumerable<Book> bookCollection)
        {
            int totalPages = 0;
            foreach (Book book in bookCollection)
                totalPages += book?.Pages ?? 0;
            return totalPages;
        }

        public static IEnumerable<Book> GetByMinimumPages(this IEnumerable<Book> bookCollection, int minimumPages)
        {
            var booksFound = new List<Book>();

            //foreach (Book book in bookCollection)
            //    if ((book?.Pages ?? 0) >= minimumPages)
            //        booksFound.Add(book);
            // return booksFound;
            
            /*Enumeratie via yield*/

            foreach (Book book in bookCollection)
                if ((book?.Pages ?? 0) >= minimumPages)
                yield return book;
        }

        public static IEnumerable<Book> GetByFirstLetter(this IEnumerable<Book> bookCollection, char firstLetter)
        {
            foreach(var book in bookCollection)
                if (book?.Title?[0] == firstLetter)
                    yield return book;
        }

        public static IEnumerable<Book> GetByFilter(this IEnumerable<Book> bookCollection, Func<Book, bool> selector)
        {
            foreach (var book in bookCollection)
            {
                if (selector(book))
                    yield return book;
            }
        }
    }
}
