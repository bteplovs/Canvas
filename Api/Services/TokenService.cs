
using Api.Data;
using Microsoft.EntityFrameworkCore;

namespace Api.Services;

public interface ITokenService
{

}

public class TokenService(IDbContextFactory<AppDbContext> context) : ITokenService
{

}
