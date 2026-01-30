using AutoMapper;
using POS.Core.Application.Features.MeassurementUnits.Queries;
using POS.Core.Domain.Entities;

namespace POS.Core.Application.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            #region MeasurementUnit
            CreateMap<MeasurementUnit, MeasurementUnitDto>();
            #endregion
        }
    }
}
