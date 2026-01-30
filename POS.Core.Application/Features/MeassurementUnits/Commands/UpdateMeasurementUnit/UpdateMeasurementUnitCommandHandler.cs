using MediatR;
using POS.Core.Application.Exceptions;
using POS.Core.Application.Interfaces.Persistence;
using POS.Core.Application.Interfaces.Repositories;

namespace POS.Core.Application.Features.MeassurementUnits.Commands.UpdateMeasurementUnit
{
    public class UpdateMeasurementUnitCommandHandler : IRequestHandler<UpdateMeasurementUnitCommand>
    {
        private readonly IMeasurementUnitRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateMeasurementUnitCommandHandler(IMeasurementUnitRepository repository,
                                                   IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }
        public async Task Handle(UpdateMeasurementUnitCommand request, CancellationToken cancellationToken)
        {
            var measurementUnit = await _repository.GetByIdAsync(request.Id);
            if (measurementUnit == null)
                throw new NotFoundException($"No se encontró la unidad de medida con id {request.Id}");

            measurementUnit.Update(request.Name, request.Abbreviation);
            try
            {
                await _repository.UpdateAsync(measurementUnit);
                await _unitOfWork.CommitAsync();
            }
            catch (Exception)
            {
                await _unitOfWork.RollbackAsync();
                throw;
            }
        }
    }
}
