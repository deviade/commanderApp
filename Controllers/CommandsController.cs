using System.Collections.Generic;
using AutoMapper;
using Commander.Data;
using Commander.Dtos;
using Commander.Models;
using Microsoft.AspNetCore.Mvc;

namespace Commander.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommandsController : ControllerBase
    {
        private readonly ICommanderRepo _commanderRepo;
        private readonly IMapper _mapper;
        public CommandsController(ICommanderRepo commanderRepo, IMapper mapper)
        {
            _mapper = mapper;
            _commanderRepo = commanderRepo;
        }

        [HttpGet]
        public ActionResult<IEnumerable<CommandReadDto>> GetAllCommands()
        {
            var commandItems = _commanderRepo.GetAllCommands();

            return Ok(_mapper.Map<IEnumerable<CommandReadDto>>(commandItems));
        }

        [HttpGet]
        [Route("{id}", Name = "GetCommandById")]
        public ActionResult<CommandReadDto> GetCommandById(int id)
        {
            var command = _commanderRepo.GetCommandById(id);
            if (command != null)
            {
                return Ok(_mapper.Map<CommandReadDto>(command));
            }
            return NotFound();

        }
        [HttpPost]
        public ActionResult<CommandReadDto> CreateCommand(CommandCreateDto commandCreateDto)
        {
            var commandModel = _mapper.Map<Command>(commandCreateDto);
            _commanderRepo.CreateCommand(commandModel);

            var commandReadDto = _mapper.Map<CommandReadDto>(commandModel);

            return CreatedAtRoute(nameof(GetCommandById), new { Id = commandReadDto.Id }, commandReadDto);

        }

        [HttpPut("{id}")]

        public ActionResult UpdateCommand(int id, CommandUpdateDto commandUpdateDto)
        {
            var commandFromDb = _commanderRepo.GetCommandById(id);
            if (commandFromDb == null)
            {
                return NotFound();
            }

            _mapper.Map(commandUpdateDto, commandFromDb);
            _commanderRepo.UpdateCommand(commandFromDb);
            _commanderRepo.SaveChanges();

            return NoContent();
        }
    }
}
