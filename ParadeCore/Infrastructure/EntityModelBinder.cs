using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace ParadeCore.Infrastructure
{
    public class EntityModelBinder : IModelBinder
    {
        public async Task BindModelAsync(ModelBindingContext bindingContext)
        {
            var original = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);
            if (original != ValueProviderResult.None)
            {
                var originalValue = original.FirstValue;
                int id;
                if (int.TryParse(originalValue, out id))
                {
                    ParadeContext dbContext = (ParadeContext) bindingContext.HttpContext.RequestServices.GetService(typeof(ParadeContext));
                    var entity = await dbContext.FindAsync(bindingContext.ModelType, id);

                    bindingContext.Result = ModelBindingResult.Success(entity);
                }
            }
        }
    }
}
