using ProjetoPadrao.ApplicationService.MeuServico;
using ProjetoPadrao.Domain.IApplicationService;
using ProjetoPadrao.Domain.IRepository;
using ProjetoPadrao.Repository.Repository;
using System.Web.Http;
using Unity;
using Unity.WebApi;
using System.Data.Entity;
using ProjetoPadrao.Repository;

namespace ProjetoPadrao.WebApi
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();

            container.RegisterType(typeof(DbContext), typeof(ProjetoPadraoContext));

            //APPLICATION SERVICE
            container.RegisterType<IMeuServicoApplicationService, MeuServicoApplicationService>();

            //REPOSITORY
            container.RegisterType<IMeuServicoRepository, MeuServicoRepository>();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}