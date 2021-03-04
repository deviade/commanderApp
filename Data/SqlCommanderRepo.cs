using System;
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

        public void CreateCommand(Command cmd)
        {
            if (cmd == null)
            {
                throw new ArgumentNullException(nameof(cmd));
            }
            _dbContext.Commands.Add(cmd);
            _dbContext.SaveChanges();
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

        public bool SaveChanges()
        {
            return (_dbContext.SaveChanges() >= 0);
        }

        public void UpdateCommand(Command cmd)
        {
            //nothing
        }
    }
}