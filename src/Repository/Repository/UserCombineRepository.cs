using Domain.Models;
using Repository.Context;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Repository
{
    public class UserCombineRepository : Repository<UserCombine>, IUserCombineRepository
    {
        public UserCombineRepository(GoHunterDbContext context) : base(context) { }

        public Task<IEnumerable<UserCombine>> GetByEmployeeId(Guid employeeId)
        {
            throw new NotImplementedException();
        }
    }
}
