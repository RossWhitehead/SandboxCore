using FluentValidation;

namespace SandboxCore.Commands.Project.Create
{
    public class CommandValidator : AbstractValidator<Command>
    {
        public CommandValidator()
        {
            RuleFor(cmd => cmd.ProjectName).NotNull().Length(3, 200);
        }
    }
}