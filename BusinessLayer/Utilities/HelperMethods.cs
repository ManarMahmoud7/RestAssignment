using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Utilities
{
    public static class HelperMethods
    {
        public static List<string> GetValidationErrors(ModelStateDictionary dict)
        {
            var errors = new List<string>();

            foreach (var modelState in dict.Values)
            {
                foreach (ModelError error in modelState.Errors)
                {
                    errors.Add(error.ErrorMessage);
                }
            }
            return errors; 
        }
    }
}
