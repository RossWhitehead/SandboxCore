using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace SandboxCore.Command.CreateProduct
{
    public class Validator : AbstractValidator<Command>
    {
        public Validator()
        {
            RuleFor(cmd => cmd.ProductName).NotNull().Length(3, 200);
            RuleFor(cmd => cmd.ProductDescription).NotNull().Length(3, 1000);
        }
    }
}
