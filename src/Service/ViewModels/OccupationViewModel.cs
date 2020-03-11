using System;
using System.ComponentModel.DataAnnotations;

namespace Service.ViewModels
{
    public class OccupationViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [StringLength(50, ErrorMessage = "The field {0} must have between {2} and {1} characteres", MinimumLength = 3)]
        public string Name { get; set; }

        [ScaffoldColumn(false)]
        public DateTime StartDate { get; set; }
        [ScaffoldColumn(false)]
        public DateTime EndDate { get; set; }

        public string CompanyName { get; set; }
        [StringLength(1000, ErrorMessage = "The field {0} must have between {2} and {1} characteres", MinimumLength = 10)]
        public string Description { get; set; }


        public Guid EmployeeId { get; set; }      

        public Guid JobOfferId { get; set; }
        
    }
}
