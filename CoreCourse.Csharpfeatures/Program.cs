﻿using System;
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

            #region NogCsharpVoorbeelden
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
            int numberOfknownBooksWithTheLetterT = Book.GetAll().GetByFirstLetter('T').Count();

            bookInfos.Add($"\r\nTotal pages in repository: {totalPages:N0}");
            bookInfos.Add($"Total pages of known books: {totalPagesKnownBooks:N0}");
            bookInfos.Add($"# books with > 350 pages: {numberOfknownBooksWithOver350p:N0}");
            bookInfos.Add($"# books starting with T: {numberOfknownBooksWithTheLetterT:N0}");

            var knownBooks = Book.GetAll();
            numberOfknownBooksWithOver350p = knownBooks.GetByFilter(koala => (koala?.Pages ?? 0) > 350).Count();
            numberOfknownBooksWithTheLetterT = knownBooks.GetByFilter(krokodil => krokodil?.Title?[0] == 'T').Count();
            int amountBooksLent = knownBooks.GetByFilter(book => book?.IsLent == true).Count();

            bookInfos.Add($"**# books with > 350 pages: {numberOfknownBooksWithOver350p:N0}");
            bookInfos.Add($"**# books starting with T: {numberOfknownBooksWithTheLetterT:N0}");
            bookInfos.Add($"**# books lent: {amountBooksLent:N0}");

            numberOfknownBooksWithOver350p = knownBooks.Count(koala => (koala?.Pages ?? 0) > 350);
            string firstLentBookTitle = knownBooks.FirstOrDefault(p => p?.IsLent == true)?.Title;

            bookInfos.Add($"***First title lent: {firstLentBookTitle}");

            IEnumerable<string> notLentOutTitles = knownBooks.Where(p => p?.IsLent == false)
                                                             .Select(p => p.Title);

            PrintStrings(bookInfos);
            #endregion

            var site = new {Name = "https://www.howest.be", Rating = 99M};


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
