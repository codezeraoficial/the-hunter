using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Service.ViewModels
{
    public class CompanyViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [StringLength(100, ErrorMessage = "The field {0} must have between {2} and {1} characteres", MinimumLength = 2)]
        public string Name { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [StringLength(14, ErrorMessage = "The field {0} must have between {2} and {1} characteres", MinimumLength = 11)]
        public string Document { get; set; }

        public string ImageUpload { get; set; }
        public string Image { get; set; }

        public bool Active { get; set; }

        public AddressViewModel Address { get; set; }

        public int KindPlan { get; set; }
        public int KindOfCompany { get; set; }

        public IEnumerable<JobOfferViewModel> JobOffers { get; set; }
    }
}
