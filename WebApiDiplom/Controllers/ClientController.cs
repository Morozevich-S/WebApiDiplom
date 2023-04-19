using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApiDiplom.Dto;
using WebApiDiplom.Interfaces;
using WebApiDiplom.Models;
using WebApiDiplom.Repository;

namespace WebApiDiplom.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : Controller
    {
        private readonly IClientRepository _clientRepository;
        private readonly IMapper _mapper;

        public ClientController(IClientRepository clientRepository, IMapper mapper)
        {
            _clientRepository = clientRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Client>))]
        public IActionResult GetClients()
        {
            var clients = _mapper.Map<List<ClientDto>>(_clientRepository.GetClients());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(clients);
        }

        [HttpGet("{clientId}")]
        [ProducesResponseType(200, Type = typeof(Client))]
        [ProducesResponseType(400)]
        public IActionResult GetClient(int clientId)
        {
            if (!_clientRepository.ClientExists(clientId))
            {
                return NotFound();
            }

            var client = _mapper.Map<ClientDto>(_clientRepository.GetClient(clientId));

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(client);
        }

        [HttpGet("{clientId}/rentalContract")]
        [ProducesResponseType(200, Type = typeof(ICollection<RentalContract>))]
        [ProducesResponseType(400)]
        public IActionResult GetRentalContractByClient(int clientId)
        {
            if (!_clientRepository.ClientExists(clientId))
            {
                return NotFound();
            }

            var rentalContracts = _mapper.Map<List<RentalContractDto>>(_clientRepository
                .GetRentalContractByClient(clientId));

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(rentalContracts);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateClient([FromBody] ClientDto clientCreate)
        {
            if (clientCreate == null)
            {
                return BadRequest(ModelState);
            }

            var client = _clientRepository.GetClients()
                .Where(c => c.Surname.Trim().ToUpper() == clientCreate.Surname.Trim().ToUpper())
                .FirstOrDefault();

            if (client != null)
            {
                ModelState.AddModelError("", "Client already exists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var clientMap = _mapper.Map<Client>(clientCreate);

            if (!_clientRepository.CreateClient(clientMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");
        }

        [HttpPut("{clientId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdateClient(int clientId, [FromBody] ClientDto updateClient)
        {
            if (updateClient == null)
            {
                return BadRequest(ModelState);
            }

            if (clientId != updateClient.Id)
            {
                return BadRequest(ModelState);
            }

            if (!_clientRepository.ClientExists(clientId))
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var clientMap = _mapper.Map<Client>(updateClient);

            if (!_clientRepository.UpdateClient(clientMap))
            {
                ModelState.AddModelError("", "Something went wrong updating client");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

        [HttpDelete("{clientId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteClient(int clientId)
        {
            if (!_clientRepository.ClientExists(clientId))
            {
                return NotFound();
            }
            var clientToDelete = _clientRepository.GetClient(clientId);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!_clientRepository.DeleteClient(clientToDelete))
            {
                ModelState.AddModelError("", "Something went wrong deleting client");
            }

            return NoContent();
        }
    }
}
