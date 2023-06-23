using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Interceptors
{
    //Bu sınıftan türetilecek attributelar
    //Class ve methodlarda birden fazla olabilecek şekilde ve inherit edildiği alt classlarda kullanılabilir
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public class MethodInterceptionBaseAttribute:Attribute,IInterceptor
    {
        public int Priority { get; set; }//Hangi Aspectlerin çalışma sırasını belirleyebilmek için alan.

        public virtual void Intercept(IInvocation invocation)//İlgili aspectlerin içersinde ezebilmemiz için virtual tanımlandı.
        {
            
        }
    }
}
