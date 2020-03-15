using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IUserCombineRepository:IRepository<UserCombine>
    {
        Task<IEnumerable<UserCombine>> GetByEmployeeId(Guid employeeId);
    }
}
