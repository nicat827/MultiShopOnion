﻿using MultishopOnion.Application.Abstractions.Repositories;
using MultishopOnion.Domain.Entities;
using MultishopOnion.Persistence.DAL;
using MultishopOnion.Persistence.Implementations.Repositories.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultishopOnion.Persistence.Implementations.Repositories
{
    internal class SizeRepository : GenericRepository<Size>, ISizeRepository
    {
        public SizeRepository(AppDbContext context) : base(context)
        {
        }
    }
}
