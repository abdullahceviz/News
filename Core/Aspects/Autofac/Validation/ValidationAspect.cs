using Castle.DynamicProxy;
using Core.CrossCuttingConserns.Validation;
using Core.Utilities.Interceptors;
using Core.Utilities.Messages;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Aspects.Autofac.Validation
{
    public class ValidationAspect:MethodInterception
    {
        private Type _validatorType;
        //validation aspect çağğırıldığı anda method interseptiondaki method sırası çalışacak sadece on before girdiğmiz için
        //diğer metod aşamaları çalışmıyormuş gibi davranacak.
        public ValidationAspect(Type validatorType)
        {
            //Gönderilen validator type IValidator türünde değilse
            if(!typeof(IValidator).IsAssignableFrom(validatorType))
            {
                throw new System.Exception(AspectMessages.WrongValidationType);
            }
            _validatorType = validatorType;
        }
        protected override void OnBefore(IInvocation invocation)
        {
            //Ivalidator türünde bir instance olıştur methodlarnı kullanabilelim diye
            //aslında newlemiş oluyoruz burda
            var validator = (IValidator)Activator.CreateInstance(_validatorType);
            //validatorType base tipi AbstractValidatordür
            //0. generic argümanıda entity nesnesidir.
            //Örnek: ProductValidator:AbstractValidator<Product>
            var entityType = _validatorType.BaseType.GetGenericArguments()[0];
            //çalışan metodun argümanlarına ulaştı
            var entities = invocation.Arguments.Where(t => t.GetType() == entityType);
            //metodun her argümanı için  validasyon metodunu çağır.
            foreach (var entity in entities)
            {
                ValidationTool.Validate(validator, entity);
            }
        }
    }
}
