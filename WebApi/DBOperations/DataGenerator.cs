using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.DBOperations
{
    public class DataGenerator
    {
        public static void Initiliaze(IServiceProvider serviceProvider)
        {
            using (var context = new BookStoreDbContext(serviceProvider.GetRequiredService<DbContextOptions<BookStoreDbContext>>()))
            {
                if (context.Books.Any())
                {
                    return;
                }
                context.Books.AddRange(

                new Book
                {
                    //Id = 1,
                    GenreId = 1,
                    PageCount = 200,
                    PublishDate = new DateTime(2001, 06, 01),
                    Title = "Forest Gump"
                },

                new Book
                {
                    //Id = 2,
                    GenreId = 2,
                    PageCount = 500,
                    PublishDate = new DateTime(2006, 10, 3),
                    Title = "Gump"
                },
                 new Book
                 {
                     //Id = 3,
                     GenreId = 5,
                     PageCount = 800,
                     PublishDate = new DateTime(2006, 7, 8),
                     Title = "Mehmet"
                 }
                );
                context.SaveChanges();
            }
        }
    }
}
