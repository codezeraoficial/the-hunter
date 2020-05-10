using System;

namespace Domain.Models
{
    public class UserCombine: Entity
    {
        public Guid? JobOfferId { get; private set; }
        public Guid? EmployeeId { get; private set; }
        public DateTime? Gotcha { get; private set; }
        public DateTime? Dropped { get; private set; }

        public void DoGotcha()
        {
            Gotcha = DateTime.UtcNow;
        }
        public void DoDropped()
        {
            Dropped = DateTime.UtcNow;
        }
    }
}
