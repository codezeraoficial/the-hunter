using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Service.ViewModels
{
    public class JobOfferViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [StringLength(20, ErrorMessage = "The field {0} must have between {2} and {1} characteres", MinimumLength = 8)]
        public string Name { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [StringLength(15, ErrorMessage = "The field {0} must have between {2} and {1} characteres", MinimumLength = 8)]
        public string ContractCode { get; set; }

        [StringLength(1000, ErrorMessage = "The field {0} must have between {2} and {1} characteres", MinimumLength = 10)]
        public string Description { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]        
        public int Long { get; set; }

        public int KindOccupation { get; set; }

        public string Occupation { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]    
        public Guid CompanyId { get; set; }

        [ScaffoldColumn(false)]
        public string CompanyName { get; set; }

        public IEnumerable<TechViewModel> Techs { get; set; }
        public IEnumerable<SkillViewModel> Skills { get; set; }
    }
}
