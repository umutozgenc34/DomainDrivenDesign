using DomainDrivenDesign.Domain.Categories;
using DomainDrivenDesign.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace DomainDrivenDesign.Infrastructure.Repositories;

public class CategoryRepository(AppDbContext context) : ICategoryRepository
{
    public async Task CreateAsync(string name, CancellationToken cancellationToken = default)
    {
        Category category = new(Guid.NewGuid(), new(name));
        await context.Categories.AddAsync(category, cancellationToken);
    }

    public async Task<List<Category>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await context.Categories.ToListAsync(cancellationToken);
    }
}
