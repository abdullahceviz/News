using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CrossCuttingConserns.Validation
{
    public static class ValidationTool
    {
        
        public static void Validate(IValidator validator,Object entity)
        {
            //Validate Methodu .net 6.0 ile beraber direkt olarak object yollamamıza engel oluyor.
            var context = new ValidationContext<Object>(entity);
            var result = validator.Validate(context);
            if(!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }
        }
    }
}
