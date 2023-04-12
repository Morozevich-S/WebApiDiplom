﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApiDiplom.Dto;
using WebApiDiplom.Interfaces;
using WebApiDiplom.Models;

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

        [HttpGet("rentalContract/{clientId}")]
        [ProducesResponseType(200, Type = typeof(ICollection<RentalContract>))]
        [ProducesResponseType(400)]
        public IActionResult GetRentalContractByClient(int clientlId)
        {
            if (!_clientRepository.ClientExists(clientlId))
            {
                return NotFound();
            }

            var rentalContracts = _mapper.Map<List<RentalContractDto>>(_clientRepository
                .GetRentalContractByClient(clientlId));

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(rentalContracts);
        }
    }
}
