using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.DBOperations;

namespace WebApi.BookOperations.DeleteBook
{
    public class DeleteBook
    {
        private readonly BookStoreDbContext _bookStoreDbContext;
        public int BookId;
        public DeleteBook(BookStoreDbContext bookStoreDbContext)
        {
            _bookStoreDbContext = bookStoreDbContext;
        }

        public void Handle()
        {
            var book = _bookStoreDbContext.Books.SingleOrDefault(x => x.Id == BookId);
            if (book is null)
            {
                throw new InvalidOperationException("Böyle bir kitap bulunamadı!");
            }

            _bookStoreDbContext.Remove(book);
            _bookStoreDbContext.SaveChanges();
        }
    }
}