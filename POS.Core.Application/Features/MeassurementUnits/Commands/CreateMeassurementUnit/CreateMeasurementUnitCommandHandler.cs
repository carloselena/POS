using MediatR;
using POS.Core.Application.Interfaces.Persistence;
using POS.Core.Application.Interfaces.Repositories;
using POS.Core.Domain.Entities;

namespace POS.Core.Application.Features.MeassurementUnits.Commands.CreateMeassurementUnit
{
    public class CreateMeasurementUnitCommandHandler : IRequestHandler
                                                            <CreateMeasurementUnitCommand, int>
    {
        private readonly IMeasurementUnitRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateMeasurementUnitCommandHandler(IMeasurementUnitRepository repository,
                                                   IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }
        public async Task<int> Handle(CreateMeasurementUnitCommand request, CancellationToken cancellationToken)
        {
            var measurementUnit = new MeasurementUnit(request.Name, request.Abbreviation);

            try
            {
                measurementUnit = await _repository.AddAsync(measurementUnit);
                await _unitOfWork.CommitAsync();
                return measurementUnit.Id;
            }
            catch (Exception)
            {
                await _unitOfWork.RollbackAsync();
                throw;
            }
        }
    }
}
