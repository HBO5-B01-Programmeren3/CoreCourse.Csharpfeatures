using System;
using System.Collections.Generic;
using System.Linq;
using CoreCourse.Csharpfeatures.Extensions;
using CoreCourse.Csharpfeatures.Models;

namespace CoreCourse.Csharpfeatures
{
    class Program
    {
        static void Main(string[] args)
        {
            #region EersteVoorbeeld
            //string info = "Account Info: ";
            //string name = "Carlton Banks ";
            //string accountNumber = null;

            //info += name;

            ////if (accountNumber == null) info += "<no account>";
            ////else info += accountNumber;
            ///*Null Coalescing*/
            //info += accountNumber ?? "<no account>";

            //Console.WriteLine(info);
            //Console.ReadKey();
            #endregion

            List<string> bookInfos = new List<string>();
            foreach (Book book in Book.GetAll())
            {
                //string title = null, sequelTitle = null;
                //int? pages = null;
                //if (book != null)
                //{
                //    title = book.Title;
                //    pages = book.Pages;
                //    if (book.Sequel != null)
                //        sequelTitle = book.Sequel.Title;
                //}
                
                /*NULL Conditional Operator*/
                //string title = book?.Title;
                //int? pages = book?.Pages;
                //string sequelTitle = book?.Sequel?.Title;
                
                /*Combinatie van beiden kan*/
                string title = book?.Title ?? "[untitled book]";
                int? pages = book?.Pages ?? 0;
                string sequelTitle = book?.Sequel?.Title ?? "[no sequels]";

                //bookInfos.Add(string.Format("Title: {0}, Pages: {1}, Sequel: {2}", title, pages, sequelTitle));
                bookInfos.Add($"Title: {title}, Pages: {pages:N0}, Sequel: {sequelTitle}");
            }

            BookRepository bookRepository = new BookRepository { Books = Book.GetAll() };
            int totalPages = bookRepository.TotalPages();
            int totalPagesKnownBooks = Book.GetAll().TotalPages();
            int numberOfknownBooksWithOver350p = Book.GetAll().GetByMinimumPages(350).Count();

            bookInfos.Add($"\r\nTotal pages in repository: {totalPages:N0}");
            bookInfos.Add($"Total pages of known books: {totalPagesKnownBooks:N0}");
            bookInfos.Add($"# books with > 350 pages: {numberOfknownBooksWithOver350p:N0}");

            PrintStrings(bookInfos);
        }

        static void PrintStrings(IEnumerable<string> strings)
        {
            foreach (var s in strings)
            {
                Console.WriteLine(s);
            }

            Console.ReadKey();
        }
    }
}
