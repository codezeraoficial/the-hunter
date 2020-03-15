using System;

namespace Domain.Models
{
    public class UserCombine: Entity
    {
        public Guid? JobOfferId { get; set; }
        public Guid? EmployeeId { get; set; }
        public DateTime? Gotcha { get; set; }
        public DateTime? Dropped { get; set; }
    }
}
