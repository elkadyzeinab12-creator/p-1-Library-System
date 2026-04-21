 
using System;
using System.ComponentModel.DataAnnotations;
class Book
{
    public string Title { get; set; }
    public string Author { get; set; }
    private double price;
    public double Price
    {
       
        get { return price; }
        set
        {
           double input = value;
           while (input < 0){
            Console.WriteLine("Price cannot be negative! Enter a valid price");
                input = Convert.ToDouble(Console.ReadLine());
            }
            price = input;
        }
    }
    public bool IsDiscounted { get; set; }
    public double DiscountedPrice
    {
        get
        { return IsDiscounted ? Price * 0.9 : Price; }
      
    }
    public string FullTitle {
        get { return $"{Title} by {Author}"; }
        set         {
            var parts = value.Split(" by ");
            if (parts.Length == 2)
            {
                Title = parts[0];
                Author = parts[1];
            }
        }
    }
    public string ISPN { get; init; }

        public Book(string title, string author, double price, string ispn,bool isdisaccounted)
        {
            Title = title;
            Author = author;
            Price = price;
            ISPN = ispn;
            IsDiscounted = isdisaccounted;

            FullTitle = $"{Title} by {Author}";
        }
}

class Library
{
    private List<Book> books = new List<Book>();
    public Book this[int index]
    {
        get { return books[index]; }
        set { books[index] = value; }
    }
    public int LengthAttribute
    {
        get { return books.Count; }
    }

    public void AddBook(Book book)
    {
        books.Add(book);
    }
   public  void DisplayBookInfo(int indx)
    {
        Console.WriteLine($"Title: {books[indx].Title}");
        Console.WriteLine($"Author: {books[indx].Author}");
        Console.WriteLine($"Price: {books[indx].Price}");
        Console.WriteLine($"Is Discounted: {books[indx].IsDiscounted}");
        Console.WriteLine($"Discounted Price: {books[indx].DiscountedPrice}");
        Console.WriteLine($"Full Title: {books[indx].FullTitle}");
        Console.WriteLine($"ISPN: {books[indx].ISPN}");
    }
   public void replaceBook(int index, Book newBook)
    {
        if (index >= 0 && index < books.Count)
        {
            books[index] = newBook;
        }
        else
        {
            Console.WriteLine("Index out of range.");
        }
        
    }
}
   public void DeleteBook(int index)
{
    if (index >= 0 && index < books.Count)
    {
        books.RemoveAt(index);
        Console.WriteLine("Book deleted successfully.");
    }
    else
    {
        Console.WriteLine("Index out of range.");
    }
}
class Program
    {
    static void Main()
    {
        Book book1 = new Book("The Great Gatsby", "F. Scott Fitzgerald", 10, "1234567890", true);
        Book book2 = new Book("To Kill a Mockingbird", "Harper Lee", 15, "0987654321", false);
        Book book3 = new Book("1984", "George Orwell", 20, "1122334455", true);

        Book[] books = new Book[]{ book1, book2, book3 };

        Library library = new Library();
        library.AddBook(book1);
            library.AddBook(book2);
            library.AddBook(book3);

        while (true)
        {
            //main menue:
            Console.WriteLine("Enter 1 to GET A BOOK");
            Console.WriteLine("Enter 2 to GET all BOOKS");
            Console.WriteLine("Enter 3 to ADD A BOOK");
            Console.WriteLine("Enter 4 to REPLACE A BOOK");
            Console.WriteLine("Enter 0 EXIT");

            int choice = Convert.ToInt32(Console.ReadLine());
            if (choice == 0) { Console.WriteLine("Exiting the program."); break; }
            switch (choice)
            {
                case 1:
                    Console.WriteLine("Enter the index of the book to get:");
                    int index = Convert.ToInt32(Console.ReadLine());
                    library.DisplayBookInfo(index);
                    break;
                case 2:
                    {
                        for (int i = 0; i < library.LengthAttribute; i++)
                        {
                            library.DisplayBookInfo(i);
                            Console.WriteLine();
                        }
                    }
                    break;
                case 3:
                    {
                       
                        Console.WriteLine("Enter the title of the new book:");
                        string newTitle = Console.ReadLine();
                        Console.WriteLine("Enter the author of the new book:");
                        string newAuthor = Console.ReadLine();
                        Console.WriteLine("Enter the price of the new book:");
                        double newPrice = Convert.ToDouble(Console.ReadLine());
                        Console.WriteLine("Enter the ISPN of the new book:");
                        string newISPN = Console.ReadLine();
                        Console.WriteLine("Is the new book discounted? (true/false):");
                        bool newIsDiscounted = Convert.ToBoolean(Console.ReadLine());

                        Book newBook = new Book(newTitle, newAuthor, newPrice, newISPN, newIsDiscounted);
                        library.AddBook(newBook);

                        Console.WriteLine(" Book is ADDED SUCCESSFULY");
                        Console.WriteLine();
                    }
                    break;

                case 4:
                    {
                        Console.WriteLine("Enter the index of the book to REPLACE:");
                        int replaceIndex = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter the title of the new book:");
                        string newTitle = Console.ReadLine();
                        Console.WriteLine("Enter the author of the new book:");
                        string newAuthor = Console.ReadLine();
                        Console.WriteLine("Enter the price of the new book:");
                        double newPrice = Convert.ToDouble(Console.ReadLine());
                        Console.WriteLine("Enter the ISPN of the new book:");
                        string newISPN = Console.ReadLine();
                        Console.WriteLine("Is the new book discounted? (true/false):");
                        bool newIsDiscounted = Convert.ToBoolean(Console.ReadLine());
                        Book newBook = new Book(newTitle, newAuthor, newPrice, newISPN, newIsDiscounted);
                        library.replaceBook(replaceIndex, newBook);
                        Console.WriteLine(" Book is REPLACED SUCCESSFULY");
                    }
                    break;
                  
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
            Console.WriteLine("---------------------------------------------------------------------------");
        }
    }
}
