using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Castle.DynamicProxy;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using NHibernate.Proxy.DynamicProxy;
using IInterceptor = NHibernate.Proxy.DynamicProxy.IInterceptor;

namespace Market.Data.NhibernateConfiguration
{
    public class NhUnitOfWorkInterceptor : IInterceptor
    {
        private readonly ISessionFactory _sessionFactory;


        public NhUnitOfWorkInterceptor(ISessionFactory sessionFactory)
        {
            _sessionFactory = sessionFactory;
        }


        public void Intercept(IInvocation invocation)
        {

            if (NhUnitOfWork.Current != null || !RequiresDbConnection(invocation.MethodInvocationTarget))
            {
                invocation.Proceed();

                return;
            }

            try
            {
                NhUnitOfWork.Current = new NhUnitOfWork(_sessionFactory);
                NhUnitOfWork.Current.BeginTransaction();



                try
                {
                    invocation.Proceed();
                   
                        NhUnitOfWork.Current.Commit();
                   
                }
                catch (Exception exception)
                {
                    try
                    {
                        NhUnitOfWork.Current.Rollback();
                    }
                    catch (Exception secExc)
                    {

                    }

                    throw;
                }
            }
            finally
            {
                NhUnitOfWork.Current = null;
            }
        }

        private static bool RequiresDbConnection(MethodInfo methodInfo)
        {


            if (UnitOfWorkHelper.IsRepositoryMethod(methodInfo))
            {
                return true;
            }

            return false;
        }

        public object Intercept(InvocationInfo info)
        {
            throw new NotImplementedException();
        }
    }
}
