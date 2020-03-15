using System;

namespace Service.ViewModels
{
    public class UserCombineViewModel
    {
        public Guid? JobOfferId { get; set; }
        public Guid? EmployeeId { get; set; }
        public DateTime? Gotcha { get; set; }
        public DateTime? Dropped { get; set; }
    }
}
