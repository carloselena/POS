using AutoMapper;
using Blocks.Domain.Abstractions;
using Blocks.Domain.ValueObjects;
using Inventory.Domain.Products;
using Inventory.Domain.Products.ValueObjects;
using MediatR;

namespace Inventory.Application.Features.Products.Commands.CreateProduct;

public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, ProductDto>
{
    private readonly IProductRepository _productRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateProductCommandHandler(IProductRepository productRepository, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _productRepository = productRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    public async Task<ProductDto> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        // todo - validate BarCode is not already in the DB
        
        var product = new Product(
            new BarCode(request.BarCode),
            request.Description,
            new Money(request.Cost),
            new Money(request.Price),
            new Quantity(request.WholesaleQuantity),
            new Money(request.WholesalePrice),
            new Stock(request.Stock),
            request.MinStock
            );

        await _productRepository.AddAsync(product, cancellationToken);
        await _unitOfWork.CommitAsync(cancellationToken);

        return _mapper.Map<ProductDto>(product);
    }
}