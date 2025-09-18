using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TeledocTestTask.Application.Commands.Founders.AddFounder;
using TeledocTestTask.Application.Commands.Founders.DeleteFounder;
using TeledocTestTask.Application.Commands.Founders.EditFounder;
using TeledocTestTask.Application.Queries.Founders.GetClientsFounders;
using TeledocTestTask.Application.Queries.Founders.GetFounderById;

namespace TeledocTestTask.Controllers
{
    [Route("api/founders")]
    [ApiController]
    public class FoundersController : ControllerBase
    {
        private readonly ISender _sender;

        public FoundersController(ISender sender)
        {
            _sender = sender;
        }

        /// <summary>
        /// Получение всех учредителей клиента
        /// </summary>
        /// <param name="clientId"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("/api/clients/{clientId:guid}/founders")]
        public async Task<IActionResult> GetClientsFounders([FromRoute]Guid clientId, CancellationToken ct)
        {
            var data = await _sender.Send(new GetClientsFoundersQuery(clientId), ct);
            return Ok(data);
        }

        /// <summary>
        /// Получение учредителя по его идентификационному номеру
        /// </summary>
        /// <param name="id"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetFounderById([FromRoute]Guid id, CancellationToken ct)
        {
            var data = await _sender.Send(new GetFounderByIdQuery(id), ct);
            return Ok(data);
        }

        /// <summary>
        /// Создание учредителя
        /// </summary>
        /// <param name="request"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AddFounder([FromBody]AddFounderCommand request, CancellationToken ct)
        {
            var id = await _sender.Send(request, ct);
            return Ok(id);
        }

        /// <summary>
        /// Изменения данных учредителя
        /// </summary>
        /// <param name="id"></param>
        /// <param name="editModel"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> EditFounder([FromRoute] Guid id, [FromBody]EditFounderModel editModel, CancellationToken ct)
        {
            await _sender.Send(new EditFounderCommand(editModel, id), ct);
            return Ok();
        }

        /// <summary>
        /// Удаление учредителя
        /// </summary>
        /// <param name="id"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteFounder([FromRoute]Guid id, CancellationToken ct)
        {
            await _sender.Send(new DeleteFounderCommand(id), ct);
            return Ok();
        }
    }
}
