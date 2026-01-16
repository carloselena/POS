using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using POS.Core.Application.Features.MeassurementUnits.Commands.CreateMeassurementUnit;
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
    }
}
