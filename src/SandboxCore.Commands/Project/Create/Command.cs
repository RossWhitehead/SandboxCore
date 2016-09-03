namespace SandboxCore.Commands.Project.Create
{
    public class Command : ICommand
    {
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
    }
}
