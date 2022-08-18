using Autofac;
using MovieDB.Core.Repositories;
using MovieDB.Core.Services;
using MovieDB.Core.UnitOfWorks;
using MovieDB.Repository;
using MovieDB.Repository.Repositories;
using MovieDB.Repository.UnitOfWorks;
using MovieDB.Service.Mapping;
using MovieDB.Service.Services;
using System.Reflection;
using Module = Autofac.Module;
namespace MovieDB.API.Modules
{
    public class RepoServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterGeneric(typeof(GenericRepository<>)).As(typeof(IGenericRepository<>)).InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(Service<>)).As(typeof(IService<>)).InstancePerLifetimeScope();

            builder.RegisterType<MovieRepository>().As<IMovieRepository>();
            builder.RegisterType<MovieService>().As<IMovieService>();

            builder.RegisterType<CategoryRepository>().As<ICategoryRepository>();
            builder.RegisterType<CategoryService>().As<ICategoryService>();

            builder.RegisterType<ProducerRepository>().As<IProducerRepository>();
            builder.RegisterType<ProducerService>().As<IProducerService>();

            builder.RegisterType<AwardRepository>().As<IAwardRepository>();
            builder.RegisterType<AwardService>().As<IAwardService>();

            builder.RegisterType<PerformerRepository>().As<IPerformerRepository>();
            builder.RegisterType<PerformerService>().As<IPerformerService>();

            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();


            var apiAssembly = Assembly.GetExecutingAssembly();
            var repoAssembly = Assembly.GetAssembly(typeof(AppDbContext));
            var serviceAssembly = Assembly.GetAssembly(typeof(MapProfile));
            /* Dependency Loop
            builder.RegisterAssemblyTypes(apiAssembly, repoAssembly, serviceAssembly)
                .Where(x => x.Name.EndsWith("Repository")).AsImplementedInterfaces().InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(apiAssembly, repoAssembly, serviceAssembly)
                .Where(x => x.Name.EndsWith("Service")).AsImplementedInterfaces().InstancePerLifetimeScope();
            */
        }
    }
}