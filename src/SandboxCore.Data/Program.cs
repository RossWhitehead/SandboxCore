using SandboxCore.Data.Extensions;

namespace SandboxCore.Data
{
    public class Program
    {
        public static void Main(string[] args)
        {
            new SandboxCoreDbContext().SeedData();
        }
    }
}
