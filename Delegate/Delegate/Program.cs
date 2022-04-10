using ClassLibrary1;
using System;

namespace Delegate
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("nece book elave isteyirsiniz?");
            int numberOfBook = ConvertToInt();
            Library library = new Library();
            for (int i = 0; i < numberOfBook; i++)
            {
                Console.WriteLine($"{i+1}. kitabin adini daxil edin");
                string bookName = Console.ReadLine();
                Console.WriteLine($"{i + 1}. kitabin muellifini adini daxil edin");
                string authorName = Console.ReadLine();
                Console.WriteLine($"{i+1}. kitabin janrini daxil edin");
                int bookGenre = FindGenreType();
                Console.WriteLine($"{i + 1}. kitabin qiymetini daxil edin");
                double bookPrice = ConvertToDouble();
                Book book = new Book()
                {
                    Name = bookName,
                    Price = bookPrice,
                    AuthorName = authorName,
                    Genre = (GenreType)bookGenre
                };
                library.Books.Add(book);
            }
            string answer;
            do
            {
                Console.WriteLine("======MENU======");
                Console.WriteLine("1.Qiymete gore cesidlemek \n2.Janra gore cesidlemek \n3.Nomre ile axtaris etmek \n4.Kitabi siyahidan silmek \n0.Proqrami bitirmek \nSeciminizi edin");
                answer = Console.ReadLine();
                switch (answer)
                {
                    case "1":
                        Console.WriteLine("min deyeri daxil edin:");
                        double min = ConvertToDouble();
                        Console.WriteLine("max deyeri daxil edin: ");
                        double max = ConvertToDouble();
                        foreach (var item in library.FilteredByPrice(min, max))
                        {
                            Console.WriteLine(item);
                        }
                        break;
                    case "2":
                        Console.WriteLine("axtardiginiz janri daxil edin");
                        int wantedGenre = FindGenreType();
                        foreach (var item in library.FilteredByGenre((GenreType)wantedGenre))
                        {
                            Console.WriteLine(item);
                        }
                        break;
                    case "3":
                        Console.WriteLine("kitab nomresi daxil edin: ");
                        int wantedNo = ConvertToInt();
                        Console.WriteLine(library.FindBookByNo(wantedNo));
                        break;
                    case "4":
                        Console.WriteLine("hansi muellifin kitablarini silmek isteyirsiniz?");
                        string wantedAuthorName = Console.ReadLine();
                        library.RemoveAll(x => x.AuthorName == wantedAuthorName);
                        foreach (var item in library.Books)
                        {
                            Console.WriteLine(item);
                        }
                        break;
                    case "0":
                        Console.WriteLine("proqram dayandirildi ;(");
                        break;
                    default:
                        Console.WriteLine("bele secim yoxdur!");
                        break;
                }
            } while (answer !="0");
        }
        static int FindGenreType()
        {
            foreach (var item in Enum.GetValues(typeof(GenreType)))
            {
                Console.WriteLine(item + " - " + Convert.ToInt32(item));
            }
            string bookGenreStr = Console.ReadLine();
            int bookGenre;
            while (!int.TryParse(bookGenreStr, out bookGenre))
            {
                Console.WriteLine("eded daxil edin!");
                bookGenreStr = Console.ReadLine();
            }
            while (!Enum.IsDefined(typeof(GenreType), bookGenre))
            {
                Console.WriteLine("duzgun deyer daxil edin!");
                bookGenreStr = Console.ReadLine();
                while (!int.TryParse(bookGenreStr, out bookGenre))
                {
                    Console.WriteLine("eded daxil edin!");
                    bookGenreStr = Console.ReadLine();
                }
            }
            return bookGenre;
        }
        static int ConvertToInt()
        {
            string intStr = Console.ReadLine();
            int value = 0;
            while (!int.TryParse(intStr, out value))
            {
                Console.WriteLine("eded daxil edin");
                intStr = Console.ReadLine();
            }
            return value;
        }
        static double ConvertToDouble()
        {
            string doubleStr = Console.ReadLine();
            double value = 0;
            while (!double.TryParse(doubleStr, out value))
            {
                Console.WriteLine("eded daxil edin");
                doubleStr = Console.ReadLine();
            }
            return value;
        }
    }
}
