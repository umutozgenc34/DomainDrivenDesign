using DomainDrivenDesign.Domain.Abstractions;
using DomainDrivenDesign.Domain.Categories;
using MediatR;

namespace DomainDrivenDesign.Application.Features.Categories.Create;

public class CreateCategoryCommandHandler(ICategoryRepository categoryRepository,IUnitOfWork unitOfWork) : IRequestHandler<CreateCategoryCommand>
{
    public async Task Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        await categoryRepository.CreateAsync(request.Name, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);
    }
}

