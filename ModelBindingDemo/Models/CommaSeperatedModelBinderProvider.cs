using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace ModelBindingDemo.Models
{
    public class CommaSeperatedModelBinderProvider : IModelBinderProvider
    {
        public IModelBinder GetBinder(ModelBinderProviderContext context)
        {
            //Model Type: Gets the model type represented by the current instance
            if (context.Metadata.ModelType == typeof(List<int>)) 
            {
                return new CommaSeperatedModelBinder();
            }

            return null;
        }
    }
}
