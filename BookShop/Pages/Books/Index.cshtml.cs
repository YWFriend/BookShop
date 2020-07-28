using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BookShop.Data;
using BookShop.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BookShop.Pages.Books
{
    public class IndexModel : PageModel
    {
        private readonly BookShop.Data.BookShopContext _context;

        public IndexModel(BookShop.Data.BookShopContext context)
        {
            _context = context;
        }

        public IList<Book> Book { get;set; }

        [BindProperty(SupportsGet = true)]

        //Data for searching
        public string SearchString { get; set; }

        [BindProperty(SupportsGet = true)]
        public string PriceBefore { get; set; }

        [BindProperty(SupportsGet = true)]
        public string PriceAfter { get; set; }

        public SelectList Genres { get; set; }
        
        [BindProperty(SupportsGet = true)]
        public string BookGenre { get; set; }

        public async Task OnGetAsync()
        {
            var books = from m in _context.Book
                        select m;

            // Filter by Title
            if (!string.IsNullOrEmpty(SearchString))
            {
                books = books.Where(s => (s.Title.Contains(SearchString)) || (s.Author.Contains(SearchString)) || (s.Genre.Contains(SearchString)));
            }
            if (!string.IsNullOrEmpty(PriceBefore))
            {
                books = books.Where(s => s.Price > Convert.ToDecimal(PriceBefore));
            }
            if (!string.IsNullOrEmpty(PriceAfter))
            {
                books = books.Where(s => s.Price < Convert.ToDecimal(PriceAfter));
            }
            //Book = await _context.Book.ToListAsync();
            Book = await books.ToListAsync();
        }
    }
}
