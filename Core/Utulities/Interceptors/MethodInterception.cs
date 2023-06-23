using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Interceptors
{
    //Amaç bir methodun nasıl ele alınacağını belirtmek.
    public class MethodInterception:MethodInterceptionBaseAttribute
    {
        //metodun önünde 
        protected virtual void OnBefore(IInvocation invocation) { }
        //methodtan sonra 
        protected virtual void OnAfter(IInvocation invocation) { }
        //method hata verdiğinde
        protected virtual void OnException(IInvocation invocation,System.Exception e) { }
        //method başarılı olduğunda
        protected virtual void OnSuccess(IInvocation invocation) { }

        //Araya girme metodunun nasıl davranacağını belirliyoruz.
        //Çünkü farklı aspectler için farklı şekilde araya girebilir.
        public override void Intercept(IInvocation invocation)
        {
            var isSucces = true;
            OnBefore(invocation);
            try
            {
                invocation.Proceed();
            }
            catch(Exception e)
            {
                isSucces = false;
                OnException(invocation,e);
                throw;
            }
            finally
            {
                if(isSucces)
                {
                    OnSuccess(invocation);
                }
            }
            OnAfter(invocation);
        }
    }
}
