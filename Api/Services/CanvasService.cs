
using Api.Data;
using Api.Models;
using Microsoft.EntityFrameworkCore;

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
    private IQueryable<Canvas> Owned(string userId) => db.Canvases.Where(c => c.UserId == userId);

    public async Task<CanvasResponse> CreateAsync(string userId, CreateCanvasRequest req)
    {
        var canvas = new Canvas { Data = req.Data, IsPrimary = false, UserId = userId };
        db.Canvases.Add(canvas);
        await db.SaveChangesAsync();
        return ToResponse(canvas);
    }

    public async Task<bool> DeleteAsync(string userId, int canvasId)
    {
        var canvas = await Owned(userId).FirstOrDefaultAsync(c => c.Id == canvasId);
        if (canvas == null) return false;

        db.Canvases.Remove(canvas);
        await db.SaveChangesAsync();
        return true;
    }

    public async Task<List<CanvasResponse>> GetAllAsync(string userId)
    {
        var all = await Owned(userId).ToListAsync();
        return [.. all.Select(ToResponse)];
    }

    public async Task<CanvasResponse?> GetAsync(string userId, int canvasId)
    {
        var canvas = await Owned(userId).FirstOrDefaultAsync(c => c.Id == canvasId);
        if (canvas == null) return null;

        return ToResponse(canvas);
    }

    public async Task<bool> SetPrimaryAsync(string userId, int canvasId)
    {
        var all = Owned(userId);
        if (!all.Any(c => c.Id == canvasId)) return false;

        ClearPrimary(all.ToListAsync());

        foreach (var c in all) c.IsPrimary = (c.Id == canvasId);
        await db.SaveChangesAsync();
        return true;
    }

    public async Task<CanvasResponse?> UpdateAsync(string userId, int canvasId, UpdateCanvasRequest req)
    {
        var canvas = await Owned(userId).FirstOrDefaultAsync(c => c.Id == canvasId);
        if (canvas == null) return null;

        if (req.Data != null) canvas.Data = req.Data;
        if (req.Name != null) canvas.Name = req.Name;

        db.Canvases.Update(canvas);
        await db.SaveChangesAsync();
        return ToResponse(canvas);
    }

    private static CanvasResponse ToResponse(Canvas c) => new(c.Id, c.UserId);

    private static async void ClearPrimary(Task<List<Canvas>> canvases)
    {
        foreach (var c in await canvases)
            c.IsPrimary = false;
    }
}
