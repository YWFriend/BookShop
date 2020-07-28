using BookShop.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new BookShopContext(serviceProvider.GetRequiredService<DbContextOptions<BookShopContext>>()))
            {
                if (context.Book.Any())
                {
                    return;
                }

                context.Book.AddRange(
                    new Book
                    {
                        Title = "Another horror",
                        Author = "Author 1",
                        Genre = "Horror",
                        InStock = 20,
                        Price = 450,
                        Rating = "16",
                        ReleaseDate = DateTime.Parse("2020-01-01")
                    },

                    new Book
                    {
                        Title = "Another drama",
                        Author = "Author 2",
                        Genre = "Drama",
                        InStock = 6,
                        Price = 300,
                        Rating = "14",
                        ReleaseDate = DateTime.Parse("2020-05-07")
                    },

                    new Book
                    {
                        Title = "Another Comedy",
                        Author = "Author 3",
                        Genre = "Comedy",
                        InStock = 12,
                        Price = 500,
                        Rating = "16",
                        ReleaseDate = DateTime.Parse("2011-05-02")
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
