
using Api.Data;
using Api.Models;

namespace Api.Services;

public interface ICanvasService
{
    Task<List<Canvas>> GetAllAsync(string userId);
    Task<Canvas?> GetAsync(string userId, int canvasId);
    Task<Canvas> CreateAsync(string userId, CreateCanvasRequest req);
    Task<Canvas?> UpdateAsync(string userId, int canvasId, UpdateCanvasRequest req);
    Task<bool> SetPrimaryAsync(string userId, int canvasId);
    Task<bool> DeleteAsync(string userId, int canvasId);
}

public class CanvasService(AppDbContext context) : ICanvasService
{
    public async Task<Canvas> CreateAsync(string userId, CreateCanvasRequest req)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> DeleteAsync(string userId, int canvasId)
    {
        throw new NotImplementedException();
    }

    public async Task<List<Canvas>> GetAllAsync(string userId)
    {
        throw new NotImplementedException();
    }

    public async Task<Canvas?> GetAsync(string userId, int canvasId)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> SetPrimaryAsync(string userId, int canvasId)
    {
        throw new NotImplementedException();
    }

    public async Task<Canvas?> UpdateAsync(string userId, int canvasId, UpdateCanvasRequest req)
    {
        throw new NotImplementedException();
    }
}
