﻿using LibraryAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestFull.Repositories.Interfaces;

namespace RestFull.Controllers
{
    [Route("api/books")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookInterface bookInterface;

        public BookController(IBookInterface bookInterface)
        {
            this.bookInterface = bookInterface;
        }

        [HttpGet("Get")]
        public async Task<ActionResult> GetAllBooks()
        {
            var books = await bookInterface.GetAllBooks();

            if (books != null)
            {
                return Ok(books);
            }
            return BadRequest();
        }

        [HttpPost("Post")]
        public async Task<ActionResult<string>> AddNewBook(string id, Book book)
        {
            var result = await bookInterface.AddNewBook(id, book);
            if (result.Contains("sikeres"))
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpGet("GetByID")]
        public async Task<ActionResult<Book>> GetById(int id)
        {
            var book = await bookInterface.GetBookById(id);
            if (book != null)
            {
                return Ok(book);
            }
            return NotFound();
        }

        [HttpPut("Put")]
        public async Task<ActionResult<Book>> Put(int id, Book book)
        {
            var result = await bookInterface.Put(id, book);
            if (result != null)
            {
                return Ok(book);
            }
            return NotFound();
        }
        [HttpDelete("Delete")]
        public async Task<ActionResult<string>> Delete(int id)
        {
            var result = await bookInterface.Delete(id);
            if (result.Contains("sikeres"))
            {
                return Ok();
            }
            return NotFound();
        }
    }
}