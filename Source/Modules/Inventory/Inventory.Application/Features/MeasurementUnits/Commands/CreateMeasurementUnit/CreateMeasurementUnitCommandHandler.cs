using Blocks.Domain.Abstractions;
using Blocks.Domain.Exceptions;
using Inventory.Domain.MeasurementUnits;
using Inventory.Domain.MeasurementUnits.ValueObjects;
using MediatR;

namespace Inventory.Application.Features.MeasurementUnits.Commands.CreateMeasurementUnit;

public class CreateMeasurementUnitCommandHandler : IRequestHandler<CreateMeasurementUnitCommand>
{
    private readonly IMeasurementUnitRepository _measurementUnitRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateMeasurementUnitCommandHandler(IMeasurementUnitRepository measurementUnitRepository, IUnitOfWork unitOfWork)
    {
        _measurementUnitRepository = measurementUnitRepository;
        _unitOfWork = unitOfWork;
    }
    public async Task Handle(CreateMeasurementUnitCommand command, CancellationToken cancellationToken)
    {
        if (await _measurementUnitRepository.ExistsByNameAsync(command.Name, cancellationToken))
            throw new DomainException("Ya existe una unidad de medida con ese nombre");
        
        if (await _measurementUnitRepository.ExistsByAbbreviationAsync(command.Abbreviation, cancellationToken))
            throw new DomainException("Ya existe una unidad de medida con esa abreviatura");

        var measurementUnit = new MeasurementUnit(new Name(command.Name), new Abbreviation(command.Abbreviation));

        await _measurementUnitRepository.AddAsync(measurementUnit, cancellationToken);
        await _unitOfWork.CommitAsync(cancellationToken);
    }
}