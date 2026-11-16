
using Api.Data;
using Microsoft.EntityFrameworkCore;

namespace Api.Services;

public interface IAuthService
{

}

public class AuthService(IDbContextFactory<AppDbContext> context) : IAuthService
{

}
