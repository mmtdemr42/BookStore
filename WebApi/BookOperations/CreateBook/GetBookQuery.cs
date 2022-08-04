using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Common;
using WebApi.DBOperations;

namespace WebApi.BookOperations.CreateBook
{
    public class GetBookQuery
    {
        private readonly BookStoreDbContext _bookStoreDbContext;
        public GetBookQuery(BookStoreDbContext bookStoreDbContext)
        {
            _bookStoreDbContext = bookStoreDbContext;
        }
        public int BookId;

        public GetBookModel Handle()
        {
            var book = _bookStoreDbContext.Books.Where(book => book.Id == BookId).SingleOrDefault();
            if (book is  null)
            {
                throw new InvalidOperationException("Böyle bir kitap bulunamadı!");
            }
            GetBookModel model = new GetBookModel();
            model.Title = book.Title;
            model.PageCount = book.PageCount;
            model.PublishDate = book.PublishDate.Date.ToString("dd/MM/yyyy");
            model.Genre = ((GenreEnum)book.GenreId).ToString();
            return model;
        }
    }

        public class GetBookModel
        {
            public string Title { get; set; }
            public string Genre { get; set; }
            public int PageCount { get; set; }
            public string PublishDate { get; set; }
        }
}

