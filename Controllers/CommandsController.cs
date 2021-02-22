using System.Collections.Generic;
using Commander.Data;
using Commander.Models;
using Microsoft.AspNetCore.Mvc;

namespace Commander.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommandsController : ControllerBase
    {
        private readonly ICommanderRepo _commanderRepo;
        public CommandsController(ICommanderRepo commanderRepo)
        {
            _commanderRepo = commanderRepo;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Command>> GetAllCommands()
        {
            var commandItems = _commanderRepo.GetAllCommands();

            return Ok(commandItems);
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<Command> GetCommandById(int id)
        {
            var command = _commanderRepo.GetCommandById(id);

            return Ok(command);
        }
    }
}
