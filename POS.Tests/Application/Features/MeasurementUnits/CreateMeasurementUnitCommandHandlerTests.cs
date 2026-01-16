using NSubstitute;
using NSubstitute.ExceptionExtensions;
using POS.Core.Application.Features.MeassurementUnits.Commands.CreateMeassurementUnit;
using POS.Core.Application.Interfaces.Persistence;
using POS.Core.Application.Interfaces.Repositories;
using POS.Core.Domain.Entities;
using POS.Core.Domain.Exceptions;

namespace POS.Tests.Application.Features.MeasurementUnits
{
    [TestClass]
    public class CreateMeasurementUnitCommandHandlerTests
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
        private IMeasurementUnitRepository repository;
        private IUnitOfWork unitOfWork;
        private CreateMeasurementUnitCommandHandler handler;
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.

        [TestInitialize]
        public void Setup()
        {
            repository = Substitute.For<IMeasurementUnitRepository>();
            unitOfWork = Substitute.For<IUnitOfWork>();
            handler = new CreateMeasurementUnitCommandHandler(repository, unitOfWork);
        }

        [TestMethod]
        public async Task Handle_ValidCommand_CreatedSuccessfully()
        {
            var command = new CreateMeasurementUnitCommand { Name = "Libra", Abbreviation = "Lb" };

            var measurementUnit = new MeasurementUnit(command.Name, command.Abbreviation);
            repository.AddAsync(Arg.Any<MeasurementUnit>()).Returns(measurementUnit);

            var result = await handler.Handle(command, CancellationToken.None);
            await repository.Received(1).AddAsync(Arg.Any<MeasurementUnit>());
            await unitOfWork.Received(1).CommitAsync();
        }

        [TestMethod]
        public async Task Handle_WhenException_WeDoARollBack()
        {
            var command = new CreateMeasurementUnitCommand { Name = "Libra", Abbreviation = "Lb" };
            repository.AddAsync(Arg.Any<MeasurementUnit>()).Throws<Exception>();

            await Assert.ThrowsExactlyAsync<Exception>(async () =>
            {
                var result = await handler.Handle(command, CancellationToken.None);
            });

            await unitOfWork.Received(1).RollbackAsync();
        }
    }
}
