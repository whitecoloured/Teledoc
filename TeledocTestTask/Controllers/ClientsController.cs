using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TeledocTestTask.Application.Commands.Clients.AddClient;
using TeledocTestTask.Application.Commands.Clients.DeleteClient;
using TeledocTestTask.Application.Commands.Clients.EditClient;
using TeledocTestTask.Application.Queries.Clients.GetAllClients;
using TeledocTestTask.Application.Queries.Clients.GetClientById;

namespace TeledocTestTask.Controllers
{
    [Route("api/clients")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly ISender _sender;

        public ClientsController(ISender sender)
        {
            _sender = sender;
        }

        /// <summary>
        /// Получение всех клиентов
        /// </summary>
        /// <param name="ct"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetClients(CancellationToken ct)
        {
            var data = await _sender.Send(new GetAllClientsQuery(), ct);
            return Ok(data);
        }

        /// <summary>
        /// Получение клиента по его идентицикационному номеру
        /// </summary>
        /// <param name="id"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetClientById([FromRoute]Guid id, CancellationToken ct)
        {
            var data = await _sender.Send(new GetClientByIdQuery(id), ct);
            return Ok(data);
        }

        /// <summary>
        /// Создание клиента
        /// </summary>
        /// <param name="request"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AddClient([FromBody]AddClientCommand request, CancellationToken ct)
        {
            var id = await _sender.Send(request, ct);
            return Ok(id);
        }

        /// <summary>
        /// Изменение данных клиента
        /// </summary>
        /// <param name="id"></param>
        /// <param name="editModel"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> EditClient([FromRoute] Guid id, [FromBody]EditClientModel editModel, CancellationToken ct)
        {
            await _sender.Send(new EditClientCommand(editModel, id), ct);
            return Ok();
        }

        /// <summary>
        /// Удаление клиента
        /// </summary>
        /// <param name="id"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteClient([FromRoute]Guid id, CancellationToken ct)
        {
            await _sender.Send(new DeleteClientCommand(id), ct);
            return Ok();
        }
    }
}
