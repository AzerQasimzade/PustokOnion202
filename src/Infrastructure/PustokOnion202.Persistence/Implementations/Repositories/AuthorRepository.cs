﻿using PustokOnion202.Application.Interfaces.Repository;
using PustokOnion202.Application.Interfaces.Repository.Common;
using PustokOnion202.Domain.Entities;
using PustokOnion202.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PustokOnion202.Persistence.Implementations.Repositories
{
    public class AuthorRepository : Repository<Author>, IAuthorRepository
    {
        public AuthorRepository(AppDbContext context) : base(context)
        {
        }
    }
}
