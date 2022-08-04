using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.DBOperations;

namespace WebApi.BookOperations.CreateBook
{
    public class CreateBookCommand
    {
        public CreateBookModel Model { get; set; }
        private readonly BookStoreDbContext _bookStoreDbContext;

        public CreateBookCommand(BookStoreDbContext bookStoreDbContext)
        {
            _bookStoreDbContext = bookStoreDbContext;
        }

        public void Handle()
        {
            var book = _bookStoreDbContext.Books.SingleOrDefault(x => x.Title == Model.Title);
            if (book is not null)
            {
                 throw new InvalidOperationException("Kitap zaten var");
            }

            book = new Book();
            book.Title = Model.Title;
            book.GenreId = Model.GenreId;
            book.PublishDate = Model.PublishDate;
            book.PageCount = Model.PageCount;

            _bookStoreDbContext.Books.Add(book);
            _bookStoreDbContext.SaveChanges();

        }

        public class CreateBookModel
        {
            public string Title { get; set; }
            public int GenreId { get; set; }
            public int PageCount { get; set; }
            public DateTime PublishDate { get; set; }
        }
    }
}
