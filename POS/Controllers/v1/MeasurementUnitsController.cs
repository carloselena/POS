using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using POS.Core.Application.Features.MeassurementUnits.Commands.CreateMeassurementUnit;
using POS.Core.Application.Features.MeassurementUnits.Commands.UpdateMeasurementUnit;
using System.Net.Mime;

namespace POS.WebApi.Controllers.v1
{
    [ApiVersion("1.0")]
    public class MeasurementUnitsController : BaseApiController
    {
        [HttpPost]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(int), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Post([FromBody] CreateMeasurementUnitCommand command)
        {
            var result = await Mediator.Send(command);
            return StatusCode(StatusCodes.Status201Created, result);
        }

        [HttpPut("{id:int:min(1)}")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateMeasurementUnitCommand command)
        {
            await Mediator.Send(command with { Id = id });
            return NoContent();
        }
    }
}
