using CafeManagementSystem.Common.AttributesErrorMessageCommon;
using System.ComponentModel.DataAnnotations;

namespace CafeManagementSystem.ViewModel
{
    public class AddItemViewModel
    {
        [Required(ErrorMessage = ErrorMessageCommon.RequiredErrorMessage)]
        [StringLength(50,ErrorMessage = ErrorMessageCommon.StringLengthErrorMessage, MinimumLength =4)]
        [Display(Name = "Item Name")]
        public string ItemName { get; set; }
 
        [Display(Name = "Item Category")]
        public string Category { get; set; }

        [Required(ErrorMessage = ErrorMessageCommon.RequiredErrorMessage)]
        [RegularExpression(@"^\d+(\.\d{1,2})?$" , ErrorMessage = ErrorMessageCommon.PriceFormatErrorMessage)]
        [Range(0, 9999999999999999.99)]
        [Display(Name = "Item Unit Price")]
        public decimal UnitPrice { get; set; } 

    }
}