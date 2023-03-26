using Books;
using System;
using System.Linq;

namespace Books
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new BookContext())
            {
                // Insert book
                var book = new Book { Title = "A Game of Thrones", Publisher = new Publisher { Name = "Ahmetcan" } };
                context.Books.Add(book);
                context.SaveChanges();

                // Update book
                var bookToUpdate = context.Books.FirstOrDefault(b => b.Id == book.Id);
                if (bookToUpdate != null)
                {
                    bookToUpdate.Title = "A Clash of Kings";
                    context.SaveChanges();
                }

                // Get book with Id
                var bookWithId = context.Books.FirstOrDefault(b => b.Id == book.Id);
                Console.WriteLine($"Book with Id {book.Id}: {book.Title}");

                // Get all books
                var allBooks = context.Books.ToList();
                Console.WriteLine("All books:");
                foreach (var b in allBooks)
                {
                    Console.WriteLine($"{b.Title} ({b.Publisher.Name})");
                }
            }
        }
    }
}

