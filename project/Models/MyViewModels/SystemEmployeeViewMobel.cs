using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace project.Models.MyViewModels
{
    public class SystemEmployeeViewMobel
    {
        public SystemUser systemUser { get; set; }
        public Employee employee { get; set; }
        public string Skills { get; set; }
        public string ImagePath { get; set; }
        public string CvPath { get; set; }
        public string DOB { get; set; }
        public string Description { get; set; }


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