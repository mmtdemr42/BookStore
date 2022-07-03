using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.DBOperations;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]s")]
    public class BookController:ControllerBase
    {
        //private static List<Book> BookList = new List<Book>()
        //{
        //    new Book
        //    {
        //        Id = 1,
        //        GenreId = 1,
        //        PageCount = 200,
        //        PublishDate = new DateTime(2001,06,01),
        //        Title = "Forest Gump"
        //    },

        //    new Book
        //    {
        //        Id = 2,
        //        GenreId = 2,
        //        PageCount = 500,
        //        PublishDate = new DateTime(2006,10,3),
        //        Title = "Gump"
        //    },
        //};

        private readonly BookStoreDbContext _context;
        public BookController(BookStoreDbContext context)
        {
            _context = context;
        }

        //[HttpGet]
        //public List<Book> GetBooks()
        //{
        //    var bookList = BookList.OrderBy(x => x.Id).ToList<Book>();
        //    return bookList;
        //}

        [HttpGet]
        public List<Book> GetBooks()
        {
            var bookList = _context.Books.OrderBy(x => x.Id).ToList<Book>();
            return bookList;
        }

        //[HttpGet("{id}")]
        //public Book GetId(int id)
        //{
        //    var book = BookList.Where(book => book.Id == id).SingleOrDefault();
        //    return book;
        //}

        [HttpGet("{id}")]
        public Book GetId(int id)
        {
            var book = _context.Books.Where(book => book.Id == id).SingleOrDefault();
            return book;
        }

        //[HttpGet]
        //public Book GetIdBy([FromQuery] string id)
        //{
        //    var book = BookList.Where(book => book.Id == Convert.ToInt32(id)).SingleOrDefault();
        //    return book;
        //}

        //[HttpPost]
        //public IActionResult AddBook([FromBody] Book newBook)
        //{
        //    var book = BookList.SingleOrDefault(x => x.Title == newBook.Title);
        //    if (book is not null)
        //    {
        //        return BadRequest();
        //    }
        //    BookList.Add(newBook);
        //    return Ok();
        //}


        [HttpPost]
        public IActionResult AddBook([FromBody] Book newBook)
        {
            var book = _context.Books.SingleOrDefault(x => x.Title == newBook.Title);
            if (book is not null)
            {
                return BadRequest();
            }
            _context.Books.Add(newBook);
            _context.SaveChanges();
            return Ok();
        }

        //[HttpPut("{id}")]
        //public IActionResult UpdateBook(int id, [FromBody] Book updateBook)
        //{
        //    var book = BookList.SingleOrDefault(x => x.Id == id);
        //    if (book is null)
        //    {
        //        return BadRequest();
        //    }

        //    book.GenreId = updateBook.GenreId != default ? updateBook.GenreId : book.GenreId;
        //    book.PageCount = updateBook.PageCount != default ? updateBook.PageCount : book.PageCount;
        //    book.PublishDate = updateBook.PublishDate != default ? updateBook.PublishDate : book.PublishDate;
        //    book.Title = updateBook.Title != default ? updateBook.Title : book.Title;

        //    return Ok();
        //}

        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, [FromBody] Book updateBook)
        {
            var book = _context.Books.SingleOrDefault(x => x.Id == id);
            if (book is null)
            {
                return BadRequest();
            }

            book.GenreId = updateBook.GenreId != default ? updateBook.GenreId : book.GenreId;
            book.PageCount = updateBook.PageCount != default ? updateBook.PageCount : book.PageCount;
            book.PublishDate = updateBook.PublishDate != default ? updateBook.PublishDate : book.PublishDate;
            book.Title = updateBook.Title != default ? updateBook.Title : book.Title;

            _context.SaveChanges();
            return Ok();
        }

        //[HttpDelete]
        //public IActionResult Delete(int id)
        //{
        //    var book = BookList.SingleOrDefault(x => x.Id == id);
        //    if (book is null)
        //    {
        //        return BadRequest();
        //    }

        //    BookList.Remove(book);
        //    return Ok();
        //}


        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var book = _context.Books.SingleOrDefault(x => x.Id == id);
            if (book is null)
            {
                return BadRequest();
            }

            _context.Remove(book);
            _context.SaveChanges();
            return Ok();
        }
    }
}
