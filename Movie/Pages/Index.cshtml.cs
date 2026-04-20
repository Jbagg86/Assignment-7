using Microsoft.AspNetCore.Mvc.RazorPages;
using Assignment9A.Data;
using Assignment9A.Models;

namespace Assignment9A.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IMovieRepo _repo;

        public IndexModel(IMovieRepo repo)
        {
            _repo = repo;
        }

        public IList<Assignment9A.Models.Movie> Movies { get; set; } = new List<Assignment9A.Models.Movie>();

        public async Task OnGetAsync()
        {
            Movies = (await _repo.GetAllAsync()).ToList();
        }
    }
}