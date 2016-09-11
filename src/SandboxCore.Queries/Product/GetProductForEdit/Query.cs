using MediatR;

namespace SandboxCore.Queries.Product.GetProductForEdit
{
    public class Query : IRequest<Result>
    {
        public int ProductId { get; set; }
    }
}
