using MediatR;
using POS.Core.Application.Common.DTOs;

namespace POS.Core.Application.Features.MeassurementUnits.Queries.GetAllMeasurementUnits
{
    public class GetAllMeasurementUnitsQuery : PaginationFilter, IRequest<PagedResult<MeasurementUnitDto>>;
}
