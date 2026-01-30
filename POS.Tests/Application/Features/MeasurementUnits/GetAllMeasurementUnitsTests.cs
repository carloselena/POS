using AutoMapper;
using NSubstitute;
using POS.Core.Application.Common.DTOs;
using POS.Core.Application.Features.MeassurementUnits.Queries;
using POS.Core.Application.Features.MeassurementUnits.Queries.GetAllMeasurementUnits;
using POS.Core.Application.Interfaces.Repositories;
using POS.Core.Application.Mappings;
using POS.Core.Domain.Entities;

namespace POS.Tests.Application.Features.MeasurementUnits
{
    [TestClass]
    public class GetAllMeasurementUnitsTests
    {
        private IMeasurementUnitRepository repository;
        private IMapper mapper;
        private GetAllMeasurementUnitsQueryHandler handler;

        [TestInitialize]
        public void Setup()
        {
            repository = Substitute.For<IMeasurementUnitRepository>();

            var config = new MapperConfiguration(cfg => cfg.AddProfile<GeneralProfile>());
            mapper = config.CreateMapper();
            handler = new(repository, mapper);
        }

        [TestMethod]
        public async Task Handle_WhenThereAreMeasurementUnits_ReturnsPagedMeasurementUnit()
        {
            var measurementUnits = new List<MeasurementUnit>()
            {
                new MeasurementUnit("Libra", "Lb"),
                new MeasurementUnit("Kilogramo", "Kg")
            };

            var request = new GetAllMeasurementUnitsQuery();

            var expected = new PagedResult<MeasurementUnitDto>
            {
                Items = measurementUnits.Select(mu => new MeasurementUnitDto
                {
                    Id = mu.Id,
                    Name = mu.Name,
                    Abbreviation = mu.Abbreviation
                }).ToList(),
                TotalCount = measurementUnits.Count
            };

            repository.GetAllAsync(request).Returns(measurementUnits);
            repository.GetTotalRowsAsync().Returns(expected.TotalCount);

            var result = await handler.Handle(request, CancellationToken.None);

            Assert.AreEqual(expected.TotalCount, result.TotalCount);
            for (int i = 0; i < expected.TotalCount; i++)
            {
                Assert.AreEqual(expected.Items[i].Id, result.Items[i].Id);
                Assert.AreEqual(expected.Items[i].Name, result.Items[i].Name);
                Assert.AreEqual(expected.Items[i].Abbreviation, result.Items[i].Abbreviation);
            }
        }

        [TestMethod]
        public async Task Handle_WhenThereAreNotMeasurementUnits_ReturnsEmptyList()
        {
            var request = new GetAllMeasurementUnitsQuery();
            repository.GetAllAsync(request).Returns(new List<MeasurementUnit>());

            var result = await handler.Handle(request, CancellationToken.None);

            Assert.IsNotNull(result);
            Assert.HasCount(0, result.Items);
        }
    }
}
