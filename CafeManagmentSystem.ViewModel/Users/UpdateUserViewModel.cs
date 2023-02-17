using CafeManagementSystem.Common.AttributesErrorMessageCommon;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CafeManagementSystem.ViewModel.Users
{
    public class UpdateUserViewModel
    {

        [HiddenInput]
        public int userId { get; set; }

        [Display(Name = "User Name")]
        [Required(ErrorMessage = ErrorMessageCommon.RequiredErrorMessage)]
        [StringLength(50, ErrorMessage = ErrorMessageCommon.StringLengthErrorMessage, MinimumLength = 4)]
        public string UserName { get; set; }

        [Display(Name = "Phone Number")]
        [Required(ErrorMessage = ErrorMessageCommon.RequiredErrorMessage)] 
        [MaxLength(12, ErrorMessage = ErrorMessageCommon.MaxLengthErrorMessage)]
        public string phoneNumber { get; set; }

        [Display(Name = "Password")]
        [StringLength(20, ErrorMessage = ErrorMessageCommon.StringLengthErrorMessage, MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string? password { get; set; }
    }
}
