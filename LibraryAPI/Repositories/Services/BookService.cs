using LibraryAPI.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestFull.Repositories.Interfaces;

namespace RestFull.Repositories.Services
{
    public class BookService : IBookInterface
    {
        private readonly LibrarydbContext _context;
        public BookService(LibrarydbContext context)
        {
            _context = context;
        }

        public async Task<string> AddNewBook(string id, Book book)
        {
            string uid = "FKB3F4FEA09CE43C";
            if (uid == id)
            {
                var bk = new Book()
                {
                    Title = book.Title,
                    PublishDate = DateTime.Now,
                    Author_id = book.Author_id,
                    Category_id = book.Category_id,
                };
                if (bk != null)
                {
                    await _context.AddAsync(bk);
                    await _context.SaveChangesAsync();
                    return "Új könyv hozzadása sikeres.";
                }
                Exception e = new();
                return e.Message;
            }
            return "Nincs jogosultsága új könyv felviteléhez.";
        }

        public async Task<ActionResult<string>> Delete(int id)
        {
            var bk = await _context.Books.FirstOrDefaultAsync(b => b.BookId == id);
            if (bk != null)
            {
                _context.Books.Remove(bk);
                await _context.SaveChangesAsync();
                return "Törlés sikeres.";
            }
            return "Törlés sikertelen";
        }

        public async Task<List<Book>> GetAllBooks()
        {
            var books = await _context.Books.ToListAsync();
            return books;
        }

        public async Task<Book> GetBookById(int id)
        {
            return await _context.Books.FirstOrDefaultAsync(bk => bk.BookId == id);
        }

        public async Task<Book> Put(int id, Book bk)
        {
            var b = await _context.Books.FirstOrDefaultAsync(x => x.BookId == id);
            if (b != null)
            {
                b.Title = bk.Title;
                b.Author_id = bk.Author_id;
                b.Author_id = bk.Author_id;
                b.PublishDate = DateTime.Now;

                _context.Update(b);
                await _context.SaveChangesAsync();

                return b;
            }
            return null;
        }

        Task<string> IBookInterface.Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}