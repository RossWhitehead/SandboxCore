﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace SandboxCore.Query.GetProductForEdit
{
    public class Query : IRequest<Result>
    {
        public int ProductId { get; set; }
    }
}