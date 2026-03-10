using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesMovie.Data;
using RazorPagesMovie.Models;

namespace RazorPagesMovie.Pages
{
    public class IndexModel : PageModel
    {
        private readonly RazorPagesMovieContext _context;

        public IndexModel(RazorPagesMovieContext context)
        {
            _context = context;
        }

        public IList<RazorPagesMovie.Models.Movie> Movies { get; set; } = new List<RazorPagesMovie.Models.Movie>();

        public async Task OnGetAsync()
        {
            Movies = await _context.Movie
                .OrderBy(m => m.Rank)
                .ThenBy(m => m.Title)
                .ToListAsync();
        }
    }
}
