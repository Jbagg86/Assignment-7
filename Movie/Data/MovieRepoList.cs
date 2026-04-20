using Assignment9A.Models;

namespace Assignment9A.Data
{
    public class MovieRepoList : IMovieRepo
    {
        private readonly List<Assignment9A.Models.Movie> _movies;

        public MovieRepoList()
        {
            _movies = new List<Assignment9A.Models.Movie>
            {
                new Assignment9A.Models.Movie { Id = 1, Title = "When Harry Met Sally", ReleaseDate = DateTime.Parse("1989-2-12"), Genre = "Romantic Comedy", Price = 7.99M },
                new Assignment9A.Models.Movie { Id = 2, Title = "Ghostbusters", ReleaseDate = DateTime.Parse("1984-3-13"), Genre = "Comedy", Price = 8.99M },
                new Assignment9A.Models.Movie { Id = 3, Title = "Ghostbusters 2", ReleaseDate = DateTime.Parse("1986-2-23"), Genre = "Comedy", Price = 9.99M },
                new Assignment9A.Models.Movie { Id = 4, Title = "Rio Bravo", ReleaseDate = DateTime.Parse("1959-4-15"), Genre = "Western", Price = 3.99M }
            };
        }

        public IEnumerable<Assignment9A.Models.Movie> GetAll()
        {
            return _movies.OrderBy(m => m.Rank).ThenBy(m => m.Title).ToList();
        }

        public async Task<IEnumerable<Assignment9A.Models.Movie>> GetAllAsync()
        {
            return await Task.FromResult(_movies.OrderBy(m => m.Rank).ThenBy(m => m.Title).ToList());
        }

        public Assignment9A.Models.Movie? GetById(int id)
        {
            return _movies.FirstOrDefault(m => m.Id == id);
        }

        public async Task<Assignment9A.Models.Movie?> GetByIdAsync(int id)
        {
            return await Task.FromResult(_movies.FirstOrDefault(m => m.Id == id));
        }

        public void Add(Assignment9A.Models.Movie movie)
        {
            _movies.Add(movie);
        }

        public async Task AddAsync(Assignment9A.Models.Movie movie)
        {
            _movies.Add(movie);
            await Task.CompletedTask;
        }

        public void Update(Assignment9A.Models.Movie movie)
        {
            var existingMovie = _movies.FirstOrDefault(m => m.Id == movie.Id);
            if (existingMovie != null)
            {
                existingMovie.Title = movie.Title;
                existingMovie.ReleaseDate = movie.ReleaseDate;
                existingMovie.Genre = movie.Genre;
                existingMovie.Price = movie.Price;
                existingMovie.Rank = movie.Rank;
                existingMovie.ImageUri = movie.ImageUri;
            }
        }

        public async Task UpdateAsync(Assignment9A.Models.Movie movie)
        {
            Update(movie);
            await Task.CompletedTask;
        }

        public void Delete(Assignment9A.Models.Movie movie)
        {
            _movies.Remove(movie);
        }

        public async Task DeleteAsync(Assignment9A.Models.Movie movie)
        {
            _movies.Remove(movie);
            await Task.CompletedTask;
        }

        public bool Exists(int id)
        {
            return _movies.Any(m => m.Id == id);
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await Task.FromResult(_movies.Any(m => m.Id == id));
        }
    }
}