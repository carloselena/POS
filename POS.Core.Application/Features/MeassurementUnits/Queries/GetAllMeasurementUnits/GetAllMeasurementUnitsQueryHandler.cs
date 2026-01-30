using AutoMapper;
using MediatR;
using POS.Core.Application.Common.DTOs;
using POS.Core.Application.Interfaces.Repositories;

namespace POS.Core.Application.Features.MeassurementUnits.Queries.GetAllMeasurementUnits
{
    public class GetAllMeasurementUnitsQueryHandler : IRequestHandler<GetAllMeasurementUnitsQuery,
                                                                      PagedResult<MeasurementUnitDto>>
    {
        private readonly IMeasurementUnitRepository _repository;
        private readonly IMapper _mapper;

        public GetAllMeasurementUnitsQueryHandler(IMeasurementUnitRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<PagedResult<MeasurementUnitDto>> Handle(GetAllMeasurementUnitsQuery request, CancellationToken cancellationToken)
        {
            var measurementUnits = await _repository.GetAllAsync(request);
            var totalRows = await _repository.GetTotalRowsAsync();
            var pagedResult = new PagedResult<MeasurementUnitDto>
            {
                Items = _mapper.Map<List<MeasurementUnitDto>>(measurementUnits),
                TotalCount = totalRows
            };

            return pagedResult;
        }
    }
}
