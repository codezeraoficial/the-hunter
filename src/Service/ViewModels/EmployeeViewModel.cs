using Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Service.ViewModels
{
    public class EmployeeViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [StringLength(20, ErrorMessage = "The field {0} must have between {2} and {1} characteres", MinimumLength = 3)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [StringLength(50, ErrorMessage = "The field {0} must have between {2} and {1} characteres", MinimumLength = 8)]
        public string LastName { get; set; }     

        [Required(ErrorMessage = "The field {0} is required")]
        [StringLength(14, ErrorMessage = "The field {0} must have between {2} and {1} characteres", MinimumLength = 11)]
        public string Document { get; set; }
        public string ImageUpload { get; set; }
        public string Image { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        public int Age { get; set; }

        [ScaffoldColumn(false)]
        public DateTime BirthDate { get; set; }

        public KindPlan KindPlan { get; set; }
        public AddressViewModel Address { get; set; }
        public bool Active { get; set; }

        public IEnumerable<TechViewModel> Techs { get; set; }
        public IEnumerable<SkillViewModel> Skills { get; set; }
        public IEnumerable<OccupationViewModel> Occupations { get; set; }
    }
}
