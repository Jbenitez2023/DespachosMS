namespace DispatchService.Repositories
{
    public interface ICrud<TResponse,TRequest> 
    {
        Task<TResponse> AddAsync(TRequest entity);
        Task<bool> DeleteAsync(int id);
        Task<IEnumerable<TResponse>> GetAllAsync();
        Task<TResponse> GetByIdAsync(int id);
        Task<TResponse> UpdateAsync(TResponse entity);
    }
}
