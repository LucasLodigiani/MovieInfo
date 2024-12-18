﻿using MovieInfo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieInfo.Application.Common.Interfaces.Repositories;
public interface IUserRepository : IGenericRepository<User>
{
    Task<User?> GetByNameAsync(string Name);
    Task<User?> GetByEmailAsync(string Email);
    Task<User?> GetUserWithRoleAndSubscriptionByEmailAsync(string Email);
    Task<User?> GetUserWithRoleAndSubscriptionByNameAsync(string Name);
    Task<IEnumerable<User>> GetUsersWithRoleAndSubscription();
}