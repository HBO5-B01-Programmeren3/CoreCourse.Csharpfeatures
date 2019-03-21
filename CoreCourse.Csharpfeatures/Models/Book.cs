using System;
using System.Collections.Generic;
using System.Text;

namespace CoreCourse.Csharpfeatures.Models
{
    public class Book
    {
        //private string genre = "Novel";
        //public string Genre
        //{
        //    get { return genre; }
        //    set { genre = value; }
        //}


        //private bool islent = true;
        //public bool IsLent
        //{
        //    get { return islent; }
        //}


        public string Title { get; set; }
        public int? Pages { get; set; }
        public string Genre { get; set; } = "Novel";
        public bool IsLent { get; } = true;
        public Book Sequel { get; set; }

        public Book(bool isLent = false)
        {
            IsLent = isLent;
        }

        public static Book[] GetAll()
        {
            Book littleprince = new Book(true)
            {
                Title = "The Little Prince",
                Pages = 83,
                Sequel = null
            };
            Book programming = new Book
            {
                Title = "C# Programming",
                Pages = null,
                Genre = "Programming",
                Sequel = null
            };
            Book warandpeace = new Book
            {
                Title = "War and Peace",
                Pages = 1392,
                Sequel = null
            };
            Book lotr3 = new Book
            {
                Title = "The Return of the King",
                Pages = 490,
                Genre = "Fantasy",
                Sequel = null
            }; Book lotr2 = new Book
            {
                Title = "The Two Towers",
                Pages = 322,
                Genre = "Fantasy",
                Sequel = lotr3
            }; Book lotr1 = new Book
            {
                Title = "The Fellowship of the Ring",
                Pages = 398,
                Genre = "Fantasy",
                Sequel = lotr2
            };

            return new Book[] { littleprince, programming, null, warandpeace, lotr1, lotr2, lotr3 };
        }

    }
}
