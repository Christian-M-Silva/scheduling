using Data.Context;
using Data.Repositories;
using Domain.Interfaces.IRepositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CrossCutting.ConfigurationDependencyInjection
{
    public class RepositoryDependencyInjection
    {
        public static void ConfigureRepositoryDependencyInjection(IServiceCollection repositoryCollection)
        {
            repositoryCollection.AddScoped<IPatientsRepository, PatientRepository>();
            //repositoryCollection.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            repositoryCollection.AddDbContext<MyContext>(
                options => options.UseMySql("Server=localhost;Port=3306;Database=scheduling;Uid=root;Pwd=12345")
                );
        }
    }
}
