using NSubstitute;
using NSubstitute.ExceptionExtensions;
using NSubstitute.ReturnsExtensions;
using POS.Core.Application.Exceptions;
using POS.Core.Application.Features.MeassurementUnits.Commands.UpdateMeasurementUnit;
using POS.Core.Application.Interfaces.Persistence;
using POS.Core.Application.Interfaces.Repositories;
using POS.Core.Domain.Entities;

namespace POS.Tests.Application.Features.MeasurementUnits
{
    [TestClass]
    public class UpdateMeasurementUnitTests
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
        private IMeasurementUnitRepository repository;
        private IUnitOfWork unitOfWork;
        private UpdateMeasurementUnitCommandHandler handler;
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.

        [TestInitialize]
        public void Setup()
        {
            repository = Substitute.For<IMeasurementUnitRepository>();
            unitOfWork = Substitute.For<IUnitOfWork>();
            handler = new(repository, unitOfWork);
        }

        [TestMethod]
        public async Task Handle_WhenExists_UpdatedSuccessfully()
        {
            var measurementUnit = new MeasurementUnit("Libra", "Lb");
            var command = new UpdateMeasurementUnitCommand(1, "Kilogramo", "Kg");

            repository.GetByIdAsync(command.Id).Returns(measurementUnit);

            await handler.Handle(command, CancellationToken.None);
            await repository.Received(1).UpdateAsync(measurementUnit);
            await unitOfWork.Received(1).CommitAsync();
        }

        [TestMethod]
        public async Task Handle_WhenNotExists_ThrowsNotFoundException()
        {
            var command = new UpdateMeasurementUnitCommand(1, "Kilogramo", "Kg");
            repository.GetByIdAsync(command.Id).ReturnsNull();

            await Assert.ThrowsExactlyAsync<NotFoundException>(async () =>
            {
                await handler.Handle(command, CancellationToken.None);
            });
        }

        [TestMethod]
        public async Task Handle_WhenException_WeDoARollBack()
        {
            var measurementUnit = new MeasurementUnit("Libra", "Lb");
            var command = new UpdateMeasurementUnitCommand(1, "Kilogramo", "Kg");

            repository.GetByIdAsync(1).Returns(measurementUnit);
            repository.UpdateAsync(measurementUnit).Throws<Exception>();

            await Assert.ThrowsExactlyAsync<Exception>(async () =>
            {
                await handler.Handle(command, CancellationToken.None);
            });

            await unitOfWork.Received(1).RollbackAsync();
        }
    }
}
