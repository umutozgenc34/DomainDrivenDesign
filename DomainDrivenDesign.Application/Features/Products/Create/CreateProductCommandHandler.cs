using DomainDrivenDesign.Domain.Abstractions;
using DomainDrivenDesign.Domain.Products;
using MediatR;

namespace DomainDrivenDesign.Application.Features.Products.Create;

public class CreateProductCommandHandler(IProductRepository productRepository, IUnitOfWork unitOfWork) : IRequestHandler<CreateProductCommand>
{
    public async Task Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        await productRepository.CreateAsync(request.Name, request.Quantity, request.Amount, request.Currency, request.CategoryId, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);
    }
}

