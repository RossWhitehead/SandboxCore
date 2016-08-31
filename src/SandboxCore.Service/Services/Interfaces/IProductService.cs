using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SandboxCore.Service.Models;
using Models;

namespace SandboxCore.Service.Services.Interfaces
{
    public interface IProductService
    {
        IReadOnlyCollection<ProductSummary> GetAllProductSummaries();
    }
}
