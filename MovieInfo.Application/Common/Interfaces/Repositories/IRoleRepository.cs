﻿using MovieInfo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieInfo.Application.Common.Interfaces.Repositories;
public interface IRoleRepository : IGenericRepository<Role>
{
    Task<Role?> GetRoleByName(string name);
}
