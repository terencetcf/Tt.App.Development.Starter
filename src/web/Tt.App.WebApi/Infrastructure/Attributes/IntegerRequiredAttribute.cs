using System.ComponentModel.DataAnnotations;

namespace Tt.App.WebApi.Infrastructure.Attributes
{
    public class IntegerRequiredAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var result = value as int?;
            return result.HasValue && result > 0;
        }
    }

}