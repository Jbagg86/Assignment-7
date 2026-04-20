using System.Net.Http.Json;
using Assignment9A.Models;

namespace Assignment9A.Data
{
    public class MovieRepoApi : IMovieRepo
    {
        private readonly HttpClient _client;

        public MovieRepoApi(HttpClient client)
        {
            _client = client;
        }

        public async Task<IEnumerable<Assignment9A.Models.Movie>> GetAllAsync()
        {
            return await _client.GetFromJsonAsync<IEnumerable<Assignment9A.Models.Movie>>("movies")
                   ?? new List<Assignment9A.Models.Movie>();
        }

        public async Task<Assignment9A.Models.Movie?> GetByIdAsync(int id)
        {
            return await _client.GetFromJsonAsync<Assignment9A.Models.Movie>($"movies/{id}");
        }

        public async Task AddAsync(Assignment9A.Models.Movie movie)
        {
            using var response = await _client.PostAsJsonAsync("movies", movie);
            response.EnsureSuccessStatusCode();
        }

        public async Task UpdateAsync(Assignment9A.Models.Movie movie)
        {
            using var response = await _client.PutAsJsonAsync($"movies/{movie.Id}", movie);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteAsync(Assignment9A.Models.Movie movie)
        {
            using var response = await _client.DeleteAsync($"movies/{movie.Id}");
            response.EnsureSuccessStatusCode();
        }

        public IEnumerable<Models.Movie> GetAll()
        {
            throw new NotImplementedException();
        }

        public Models.Movie? GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Add(Models.Movie movie)
        {
            throw new NotImplementedException();
        }

        public void Update(Models.Movie movie)
        {
            throw new NotImplementedException();
        }

        public void Delete(Models.Movie movie)
        {
            throw new NotImplementedException();
        }

        public bool Exists(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ExistsAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}