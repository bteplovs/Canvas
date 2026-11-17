
using Api.Data;
using Api.Models;

namespace Api.Services;

public interface ICanvasService
{
    Task<List<CanvasResponse>> GetAllAsync(string userId);
    Task<CanvasResponse?> GetAsync(string userId, int canvasId);
    Task<CanvasResponse> CreateAsync(string userId, CreateCanvasRequest req);
    Task<CanvasResponse?> UpdateAsync(string userId, int canvasId, UpdateCanvasRequest req);
    Task<bool> SetPrimaryAsync(string userId, int canvasId);
    Task<bool> DeleteAsync(string userId, int canvasId);
}

public class CanvasService(AppDbContext db) : ICanvasService
{
    public Task<CanvasResponse> CreateAsync(string userId, CreateCanvasRequest req)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteAsync(string userId, int canvasId)
    {
        throw new NotImplementedException();
    }

    public Task<List<CanvasResponse>> GetAllAsync(string userId)
    {
        throw new NotImplementedException();
    }

    public Task<CanvasResponse?> GetAsync(string userId, int canvasId)
    {
        throw new NotImplementedException();
    }

    public Task<bool> SetPrimaryAsync(string userId, int canvasId)
    {
        throw new NotImplementedException();
    }

    public Task<CanvasResponse?> UpdateAsync(string userId, int canvasId, UpdateCanvasRequest req)
    {
        throw new NotImplementedException();
    }
}
