using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.BookOperations.CreateBook;
using WebApi.BookOperations.DeleteBook;
using WebApi.BookOperations.GetBooks;
using WebApi.BookOperations.UpdateBook;
using WebApi.DBOperations;
using static WebApi.BookOperations.CreateBook.CreateBookCommand;
using static WebApi.BookOperations.UpdateBook.UpdateBook;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]s")]
    public class BookController : ControllerBase
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
        public IActionResult GetBooks()
        {
            //var bookList = _context.Books.OrderBy(x => x.Id).ToList<Book>();
            //return bookList;

            try
            {
                GetBooksQuery query = new GetBooksQuery(_context);
                var result = query.Handle();
                return Ok(result);
            }
            catch (Exception exception)
            {

                return BadRequest(exception.Message);
            }
        }

        //[HttpGet("{id}")]
        //public Book GetId(int id)
        //{
        //    var book = BookList.Where(book => book.Id == id).SingleOrDefault();
        //    return book;
        //}

        [HttpGet("{id}")]
        public IActionResult GetId(int id)
        {
            GetBookQuery getBookQuery = new GetBookQuery(_context);
            try
            {
                var result = getBookQuery.Handle();
                getBookQuery.BookId = id;
                GetBooksQueryValidation validator = new GetBooksQueryValidation();
                validator.ValidateAndThrow(getBookQuery);
                return Ok(result);
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
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
        public IActionResult AddBook([FromBody] CreateBookModel newBook)
        {
            //var book = _context.Books.SingleOrDefault(x => x.Title == newBook.Title);
            //if (book is not null)
            //{
            //    return BadRequest();
            //}
            //_context.Books.Add(newBook);
            //_context.SaveChanges();
            //return Ok();
            CreateBookCommand createBook = new CreateBookCommand(_context);
            try
            {
                createBook.Model = newBook;
                CreateBookCommandValidator validator = new CreateBookCommandValidator();
                validator.ValidateAndThrow(createBook);
                //ValidationResult result = validator.Validate(createBook);
                //if (!result.IsValid)
                //{
                //    foreach (var error in result.Errors)
                //    {
                //        Console.WriteLine("Ozellik:" + error.PropertyName + " Error Message: " + error.ErrorMessage);
                //    }
                //}
                //else
                //{
                //    createBook.Handle();
                //}
                createBook.Handle();
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
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
        public IActionResult UpdateBook(int id, [FromBody] UpdateViewModel updateBook)
        {
            //var book = _context.Books.SingleOrDefault(x => x.Id == id);
            //if (book is null)
            //{
            //    return BadRequest();
            //}

            //book.GenreId = updateBook.GenreId != default ? updateBook.GenreId : book.GenreId;
            //book.PageCount = updateBook.PageCount != default ? updateBook.PageCount : book.PageCount;
            //book.PublishDate = updateBook.PublishDate != default ? updateBook.PublishDate : book.PublishDate;
            //book.Title = updateBook.Title != default ? updateBook.Title : book.Title;

            //_context.SaveChanges();
            //return Ok();

            UpdateBook updateBook1 = new UpdateBook(_context);
            try
            {
                updateBook1.Model = updateBook;
                UpdateBookValidation validator = new UpdateBookValidation();
                validator.ValidateAndThrow(updateBook1);
                updateBook1.Handle(id);
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
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
            //var book = _context.Books.SingleOrDefault(x => x.Id == id);
            //if (book is null)
            //{
            //    return BadRequest();
            //}

            //_context.Remove(book);
            //_context.SaveChanges();
            //return Ok();

            try
            {
                DeleteBook deleteBook = new DeleteBook(_context);
                deleteBook.BookId = id;
                DeleteBookValidation validator = new DeleteBookValidation();
                validator.ValidateAndThrow(deleteBook);
                deleteBook.Handle();

            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
            return Ok();

        }
    }
}