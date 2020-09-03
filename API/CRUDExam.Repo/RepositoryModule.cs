using Autofac;
using System.Reflection;
using Module = Autofac.Module;

namespace CRUDExam.Repo
{
    public class RepositoryModule : Module
    {
        //
        /// <summary>
        /// Este modulo lo que hace es todar todas las clases que implementan interfaces
        /// e registrarlas con las interfaces que tienen, eso permite que de manera automatica 
        /// se tome todo lo que tiene la libreria y se auto-inyecte
        /// en este caso BasicService y IBasicService se auto registran.
        /// </summary>
        /// <param name="builder"></param>
        protected override void Load(ContainerBuilder builder)
        {
            var _current = Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(_current)
                   .AsImplementedInterfaces()
                   .InstancePerLifetimeScope();

            base.Load(builder);
        }
    }
}
