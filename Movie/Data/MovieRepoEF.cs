using Microsoft.EntityFrameworkCore;
using Assignment9A.Models;

namespace Assignment9A.Data
{
    public class MovieRepoEf : IMovieRepo
    {
        private readonly Assignment9AContext _context;

        public MovieRepoEf(Assignment9AContext context)
        {
            _context = context;
        }

        public IEnumerable<Assignment9A.Models.Movie> GetAll()
        {
            return _context.Movie.OrderBy(m => m.Rank).ThenBy(m => m.Title).ToList();
        }

        public async Task<IEnumerable<Assignment9A.Models.Movie>> GetAllAsync()
        {
            return await _context.Movie
                .OrderBy(m => m.Rank)
                .ThenBy(m => m.Title)
                .ToListAsync();
        }

        public Assignment9A.Models.Movie? GetById(int id)
        {
            return _context.Movie.FirstOrDefault(m => m.Id == id);
        }

        public async Task<Assignment9A.Models.Movie?> GetByIdAsync(int id)
        {
            return await _context.Movie.FirstOrDefaultAsync(m => m.Id == id);
        }

        public void Add(Assignment9A.Models.Movie movie)
        {
            _context.Movie.Add(movie);
            _context.SaveChanges();
        }

        public async Task AddAsync(Assignment9A.Models.Movie movie)
        {
            _context.Movie.Add(movie);
            await _context.SaveChangesAsync();
        }

        public void Update(Assignment9A.Models.Movie movie)
        {
            _context.Movie.Update(movie);
            _context.SaveChanges();
        }

        public async Task UpdateAsync(Assignment9A.Models.Movie movie)
        {
            _context.Movie.Update(movie);
            await _context.SaveChangesAsync();
        }

        public void Delete(Assignment9A.Models.Movie movie)
        {
            _context.Movie.Remove(movie);
            _context.SaveChanges();
        }

        public async Task DeleteAsync(Assignment9A.Models.Movie movie)
        {
            _context.Movie.Remove(movie);
            await _context.SaveChangesAsync();
        }

        public bool Exists(int id)
        {
            return _context.Movie.Any(m => m.Id == id);
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.Movie.AnyAsync(m => m.Id == id);
        }
    }
}