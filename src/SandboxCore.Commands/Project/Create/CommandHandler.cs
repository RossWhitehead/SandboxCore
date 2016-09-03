using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using SandboxCore.Data;

namespace SandboxCore.Commands.Project.Create
{
    public class CommandHandler : ICommandHandler<Command>
    {
        private SandboxCoreDbContext db;

        public CommandHandler(SandboxCoreDbContext db)
        {
            this.db = db;
        }

        public async Task<CommandResult> Execute(Command command)
        {
            CommandValidator validator = new CommandValidator();
            validator.ValidateAndThrow(command);

            var project = new Data.Models.Project()
            {
                ProjectId = command.ProjectId,
                ProjectName = command.ProjectName
            };

            db.Add(project);
            await db.SaveChangesAsync();

            return new CommandResult(true);
        }
    }
}