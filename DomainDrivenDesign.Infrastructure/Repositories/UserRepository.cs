using DomainDrivenDesign.Domain.Users;
using DomainDrivenDesign.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System.IO;

namespace DomainDrivenDesign.Infrastructure.Repositories;

public class UserRepository(AppDbContext context) : IUserRepository
{
    public async Task<User> CreateAsync(string name, string email, string password, string country, string postalCode, string fullAddress, CancellationToken cancellationToken = default)
    {
        User user = User.CreateUser(name, email, password, country, postalCode, fullAddress);
        await context.Users.AddAsync(user, cancellationToken);

        return user;
    }

    public Task<List<User>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return context.Users.ToListAsync(cancellationToken);
    }
}
