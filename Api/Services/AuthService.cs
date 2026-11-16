
using Api.Data;
using Api.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Api.Services;

public interface IAuthService
{
    Task<User> CreateUserAsync(CreateUserRequest req);
    Task<User?> Login(LoginUserRequest req);
}

public class AuthService(IDbContextFactory<AppDbContext> context, PasswordHasher<object> hasher) : IAuthService
{
    public async Task<User> CreateUserAsync(CreateUserRequest req)
    {
        await using var db = await context.CreateDbContextAsync();

        var user = new User
        {
            Email = req.Email,
            UserName = req.Username,
            FirstName = req.FirstName,
            LastName = req.LastName,
            PasswordHash = hasher.HashPassword(null!, req.Password)
        };

        db.Add(user);
        await db.SaveChangesAsync();

        var createdUser = await db.Users.FirstAsync(u => u.Id == user.Id);
        return createdUser;
    }

    public async Task<User?> Login(LoginUserRequest req)
    {
        await using var db = await context.CreateDbContextAsync();

        var user = await db.Users.FirstOrDefaultAsync(u => u.Email == req.Email);
        if (user == null) { return null; }

        if (!VerifyPassword(user.PasswordHash!, req.Password)) { return null; }

        return user;
    }

    private bool VerifyPassword(string hashedPassword, string providedPassword)
    {
        var result = hasher.VerifyHashedPassword(null!, hashedPassword, providedPassword);
        return result == PasswordVerificationResult.Success;
    }
}
