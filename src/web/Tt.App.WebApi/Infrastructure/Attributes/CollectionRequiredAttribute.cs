using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace Tt.App.WebApi.Infrastructure.Attributes
{
    public class CollectionRequiredAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var collection = value as ICollection;
            if (collection != null)
            {
                return collection.Count != 0;
            }

            var enumerable = value as IEnumerable;
            return enumerable != null && enumerable.GetEnumerator().MoveNext();
        }
    }

}