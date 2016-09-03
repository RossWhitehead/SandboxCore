using FluentValidation;
using MediatR;
using SandboxCore.Data;

namespace SandboxCore.Commands.Product.Create
{
    public class Handler : RequestHandler<Command>
    {
        private SandboxCoreDbContext db;

        public Handler(SandboxCoreDbContext db)
        {
            this.db = db;
        }

        protected override void HandleCore(Command command)
        {
            Validator validator = new Validator();
            validator.ValidateAndThrow(command);

            var product = new Data.Models.Product()
            {
                ProductName = command.ProductName,
                ProductDescription = command.ProductDescription,
                ProductCategoryId = command.ProductCategoryId
            };

            db.Add(product);
            db.SaveChanges();
        }
    }
}
