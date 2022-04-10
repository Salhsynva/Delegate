using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary1
{
    public class Library
    {
        public List<Book> Books { get; set; } = new List<Book>();
        public List<Book> FilteredByPrice(double min , double max)
        {
            List<Book> filteredPriceBooks  = new List<Book>();
            foreach (var book in Books.FindAll(x => x.Price >= min && x.Price <= max))
            {
                    filteredPriceBooks.Add(book);
            }
            return filteredPriceBooks;
        }
        public List<Book> FilteredByGenre(GenreType type)
        {
            List<Book> filteredByGenreBooks = new List<Book>();
            foreach (var item in Books.FindAll(x => x.Genre == type))
            {
                filteredByGenreBooks.Add(item);
            }
            return filteredByGenreBooks;
        }
        public Book FindBookByNo(int no)
        {
            return Books.Find(x => x.No == no);
            return null;
        }
        public bool isExistBookByNo(int no)
        {
            return Books.Exists(x => x.No == no);
        }
        public void RemoveAll(Predicate<Book> predicate)
        {
            Books.RemoveAll(predicate);
        }

    }
}
