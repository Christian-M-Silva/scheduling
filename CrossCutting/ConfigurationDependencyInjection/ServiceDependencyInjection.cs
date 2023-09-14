using Domain.Interfaces.IServices;
using Microsoft.Extensions.DependencyInjection;
using Services;

namespace CrossCutting.ConfigurationDependencyInjection
{
    public class ServiceDependencyInjection
    {
        public static void ConfigureServiceDependencyInjection(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IPatientService, PatientService>();
        }
    }
}
