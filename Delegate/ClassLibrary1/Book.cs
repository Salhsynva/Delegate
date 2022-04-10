using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary1
{
    public class Book
    {
        public Book()
        {
            _totalcount++;
            No = _totalcount;
        }
        static int _totalcount;
        public int No { get; }
        public string Name { get; set; }
        public string AuthorName { get; set; }
        public double Price { get; set; }
        public GenreType Genre { get; set; }

        public override string ToString()
        {
            return $"kitabin nomresi: {No} - adi:{Name} - muellif adi: {AuthorName} - qiymeti: {Price} - janri: {Genre} ";
        }
    }
}
