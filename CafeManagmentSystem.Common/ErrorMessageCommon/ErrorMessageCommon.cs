using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeManagementSystem.Common.AttributesErrorMessageCommon
{
    public static class ErrorMessageCommon
    {
        public const string RequiredErrorMessage = "{0} is requiresd!";
        public const string MaxLengthErrorMessage = "You can enter maximum {1} chars!";
        public const string EmialFormatErrorMessage = "This is't a valid format email";
        public const string StringLengthErrorMessage = "{0} can be between {1} and {2} chars!";
        public const string ConfirmPasswordErrorMessagee = "{0} doesn't match!";
        public const string PriceFormatErrorMessage = "Please enter vaild format for price!";
        public const string ModelStateErrorMessage = "Please enter valid values";
        public const string UserNotFound = "User not found!Plese try again";
    }
}
