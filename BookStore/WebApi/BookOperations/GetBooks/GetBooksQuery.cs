using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Common;
using WebApi.DBOperations;

namespace WebApi.BookOperations.GetBooks
{
    public class GetBooksQuery
    {
        private readonly BookStoreDbContext _bookStoreDbContext;
        public GetBooksQuery(BookStoreDbContext bookStoreDbContext)
        {
            _bookStoreDbContext = bookStoreDbContext;
        }


        public List<BooksViewModel> Handle()
        {
            var bookList = _bookStoreDbContext.Books.OrderBy(x => x.Id).ToList<Book>();
            if (bookList is null)
            {
                throw new InvalidOperationException("Herhangi bir kitap bulunmadı!");
            }
            List<BooksViewModel> vm = new List<BooksViewModel>();
            foreach (var book in bookList)
            {
                vm.Add(new BooksViewModel()
                {
                    Title = book.Title,
                    PageCount = book.PageCount,
                    PublishDate = book.PublishDate.Date.ToString("dd/MM/yyyy"),
                    Genre = ((GenreEnum)book.GenreId).ToString(),
                });
            }
            return vm;
        }
    }

    public class BooksViewModel
    {
        public string Title { get; set; }
        public string Genre { get; set; }
        public int PageCount { get; set; }
        public string PublishDate { get; set; }
    }
}
