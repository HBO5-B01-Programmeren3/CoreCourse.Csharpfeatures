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
                yield return book;
        }
    }
}
