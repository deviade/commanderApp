using System.Collections.Generic;
using System.Linq;
using Commander.Models;

namespace Commander.Data
{
    public class SqlCommanderRepo : ICommanderRepo
    {
        private readonly CommanderContext _dbContext;
        public SqlCommanderRepo(CommanderContext dbContext)
        {
            _dbContext = dbContext;

        }
        public IEnumerable<Command> GetAllCommands()
        {
            var commands = _dbContext.Commands.ToList();
            return commands;
        }

        public Command GetCommandById(int id)
        {
            var command = _dbContext.Commands.FirstOrDefault(x => x.Id == id);
            return command;
        }
    }
}