using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace ERPSystem.Web.Validation
{
    public static class ValidationResultExtensions
    {
        public static void AddToModelState(this ValidationResult result, ModelStateDictionary modelState, string prefix)
        {
            foreach (var error in result.Errors)
            {
                var key = string.IsNullOrEmpty(prefix) ? error.PropertyName : $"{prefix}.{error.PropertyName}";
                modelState.AddModelError(key, error.ErrorMessage);
            }
        }
    }
}
