﻿using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace ModelBindingDemo.Models
{
    public class CommaSeperatedModelBinder : IModelBinder
    {
        // ModelBindingContext : A context that contains operating information for model binding and validation.
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            //Get the Query String Parameter
            var query = bindingContext.HttpContext.Request.Query;
            //fetch the values based on the key
            var Ids = query["Ids"].ToString();
            //Check if the value is null or empty
            if (string.IsNullOrEmpty(Ids))
            {
                return Task.CompletedTask;
            }

            //Splitting the comma seperated values to list of integers
            var values = Ids.Split(',').Select(int.Parse).ToList();

            //Sucess: Create a ModelBindingResult representing a succesful model binding operation.
            bindingContext.Result = ModelBindingResult.Success(values);

            //Mark the Task Has Been completed successfully
            return Task.CompletedTask;
        }
    }
}
