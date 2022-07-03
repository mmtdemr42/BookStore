using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.DBOperations;

namespace WebApi.BookOperations.UpdateBook
{
    public class UpdateBook
    {
        public UpdateViewModel Model { get; set; }
        private readonly BookStoreDbContext _bookStoreDbContext;
        public UpdateBook(BookStoreDbContext bookStoreDbContext)
        {
            _bookStoreDbContext = bookStoreDbContext;
        }

        public void Handle(int id)
        {
            var book = _bookStoreDbContext.Books.SingleOrDefault(x => x.Id == id);
            if (book is null)
            {
                throw new InvalidOperationException("Böyle bir kitap bulunamadı");
            }

            book.GenreId = Model.GenreId != default ? Model.GenreId : book.GenreId;
            book.PageCount = Model.PageCount != default ? Model.PageCount : book.PageCount;
            book.PublishDate = Model.PublishDate != default ? Model.PublishDate : book.PublishDate;
            book.Title = Model.Title != default ? Model.Title : book.Title;

            _bookStoreDbContext.SaveChanges();
        }

        public class UpdateViewModel
        {
            public string Title { get; set; }
            public int GenreId { get; set; }
            public int PageCount { get; set; }
            public DateTime PublishDate { get; set; }

        }
    }
}
