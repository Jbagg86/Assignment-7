using Assignment9A.Models;

namespace Assignment9A.Data
{
    public interface IMovieRepo
    {
        IEnumerable<Assignment9A.Models.Movie> GetAll();
        Task<IEnumerable<Assignment9A.Models.Movie>> GetAllAsync();

        Assignment9A.Models.Movie? GetById(int id);
        Task<Assignment9A.Models.Movie?> GetByIdAsync(int id);

        void Add(Assignment9A.Models.Movie movie);
        Task AddAsync(Assignment9A.Models.Movie movie);

        void Update(Assignment9A.Models.Movie movie);
        Task UpdateAsync(Assignment9A.Models.Movie movie);

        void Delete(Assignment9A.Models.Movie movie);
        Task DeleteAsync(Assignment9A.Models.Movie movie);

        bool Exists(int id);
        Task<bool> ExistsAsync(int id);
    }
}