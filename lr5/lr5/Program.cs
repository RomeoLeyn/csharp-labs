using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace LibrarySystem
{
    enum Genre
    {
        Fiction,
        NonFiction,
        Science,
        Fantasy,
        History,
        Romance,
        Thriller,
        Other
    }

    struct Book
    {
        public int ReaderCardNumber; 
        public string FullName;      
        public string IssueDate;   
        public Genre BookGenre;      
        public int ReturnPeriod;     
        public string Author;        
        public string Title;         
        public int Year;             
        public string Publisher;     
        public decimal Price;        

        public override string ToString()
        {
            return $"Reader Card: {ReaderCardNumber}, Name: {FullName}, Issue Date: {IssueDate:d}, " +
                   $"Genre: {BookGenre}, Return in: {ReturnPeriod} days, Author: {Author}, " +
                   $"Title: {Title}, Year: {Year}, Publisher: {Publisher}, Price: {Price:C}";
        }
    }

    class Program
    {
        static string filePath = "books.txt";
        static List<Book> books = new List<Book>();

        static void Main(string[] args)
        {
            LoadBooksFromFile();

            while (true)
            {
                Console.WriteLine("\nLibrary Menu:");
                Console.WriteLine("1. Add a new book");
                Console.WriteLine("2. View all books");
                Console.WriteLine("3. Search by reader card number");
                Console.WriteLine("4. Search by author");
                Console.WriteLine("5. Search by publisher");
                Console.WriteLine("6. Exit");

                Console.Write("Choose an option: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddNewBook();
                        break;
                    case "2":
                        ViewAllBooks();
                        break;
                    case "3":
                        SearchByReaderCardNumber();
                        break;
                    case "4":
                        SearchByAuthor();
                        break;
                    case "5":
                        SearchByPublisher();
                        break;
                    case "6":
                        return;
                    default:
                        Console.WriteLine("Invalid option. Try again.");
                        break;
                }
            }
        }

        static void LoadBooksFromFile()
        {
            if (File.Exists(filePath))
            {
                var lines = File.ReadAllLines(filePath);
                foreach (var line in lines)
                {
                    var parts = line.Split('|');
                    books.Add(new Book
                    {
                        ReaderCardNumber = int.Parse(parts[0]),
                        FullName = parts[1],
                        IssueDate = parts[2],
                        BookGenre = Enum.Parse<Genre>(parts[3]),
                        ReturnPeriod = int.Parse(parts[4]),
                        Author = parts[5],
                        Title = parts[6],
                        Year = int.Parse(parts[7]),
                        Publisher = parts[8],
                        Price = decimal.Parse(parts[9])
                    });
                }
            }
        }

        static void SaveBooksToFile()
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (var book in books)
                {
                    writer.WriteLine($"{book.ReaderCardNumber}|{book.FullName}|{book.IssueDate}|{book.BookGenre}|{book.ReturnPeriod}|{book.Author}|{book.Title}|{book.Year}|{book.Publisher}|{book.Price}");
                }
            }
        }

        static void AddNewBook()
        {
            Console.Write("Enter reader card number: ");
            int readerCardNumber = int.Parse(Console.ReadLine());

            Console.Write("Enter full name: ");
            string fullName = Console.ReadLine();

            Console.Write("Enter issue date (day/month/year): ");
            string issueDate = Console.ReadLine();

            Console.Write("Enter genre (Fiction, NonFiction, Science, etc.): ");
            Genre bookGenre = Enum.Parse<Genre>(Console.ReadLine());

            Console.Write("Enter return period (days): ");
            int returnPeriod = int.Parse(Console.ReadLine());

            Console.Write("Enter author: ");
            string author = Console.ReadLine();

            Console.Write("Enter title: ");
            string title = Console.ReadLine();

            Console.Write("Enter year: ");
            int year = int.Parse(Console.ReadLine());

            Console.Write("Enter publisher: ");
            string publisher = Console.ReadLine();

            Console.Write("Enter price: ");
            decimal price = decimal.Parse(Console.ReadLine());

            Book newBook = new Book
            {
                ReaderCardNumber = readerCardNumber,
                FullName = fullName,
                IssueDate = issueDate,
                BookGenre = bookGenre,
                ReturnPeriod = returnPeriod,
                Author = author,
                Title = title,
                Year = year,
                Publisher = publisher,
                Price = price
            };

            books.Add(newBook);
            SaveBooksToFile();
            Console.WriteLine("Book added successfully!");
        }

        static void ViewAllBooks()
        {
            Console.WriteLine("\nAll Books:");
            foreach (var book in books)
            {
                Console.WriteLine(book);
            }
        }

        static void SearchByReaderCardNumber()
        {
            Console.Write("Enter reader card number: ");
            int cardNumber = int.Parse(Console.ReadLine());
            var results = books.Where(b => b.ReaderCardNumber == cardNumber).ToList();
            DisplayResults(results);
        }

        static void SearchByAuthor()
        {
            Console.Write("Enter author: ");
            string author = Console.ReadLine();
            var results = books.Where(b => b.Author.Equals(author, StringComparison.OrdinalIgnoreCase)).ToList();
            DisplayResults(results);
        }

        static void SearchByPublisher()
        {
            Console.Write("Enter publisher: ");
            string publisher = Console.ReadLine();
            var results = books.Where(b => b.Publisher.Equals(publisher, StringComparison.OrdinalIgnoreCase)).ToList();
            DisplayResults(results);
        }

        static void DisplayResults(List<Book> results)
        {
            if (results.Count > 0)
            {
                foreach (var book in results)
                {
                    Console.WriteLine(book);
                }
            }
            else
            {
                Console.WriteLine("No results found.");
            }
        }
    }
}
