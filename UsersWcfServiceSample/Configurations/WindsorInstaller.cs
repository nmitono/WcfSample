using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using UsersWcfServiceSample.Services;

namespace UsersWcfServiceSample.Configurations
{
    public class WindsorInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component.For<IUserService, UserService>(),
                Component.For<IUserServiceProvider, UserServiceProvider>());
        }
    }
}