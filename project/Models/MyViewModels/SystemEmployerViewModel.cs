using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace project.Models.MyViewModels
{
    public class SystemEmployerViewModel
    {
        public SystemUser systemUser { get; set; }
        public Employer employer { get; set; }

        public string Position { get; set; }
        public string Website { get; set; }
        public string CompanyName { get; set; }
        public string CompanyAddress { get; set; }
        public string City { get; set; }
        public string Country { get; set; }


        [Required(ErrorMessage = "FirstName is required.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "LastName is required.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "MobileNb is required.")]
        public string MobileNb { get; set; }

        [Required(ErrorMessage = "Address is required.")]
        public string Address { get; set; }

    }
}