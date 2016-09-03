namespace SandboxCore.Commands
{
    public class CommandResult
    {
        public CommandResult(bool success)
        {
            Success = success;
        }

        public bool Success { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
    }
}