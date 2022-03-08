using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using AlawailApi.Domain.Services;
// using AlawailApi.Domain.Services;

namespace AlawailApi.Domain.Installers
{
    public class MvcInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

            services.AddSwaggerGen();

            services.AddScoped<IDepartmentServices, DepartmentServices>();
            services.AddScoped<IEmployeeAccountServices, EmployeeAccountServices>();
            services.AddScoped<IEmployeeServices, EmployeeServices>();
            services.AddScoped<IRoleServices, RoleServices>();
            services.AddScoped<IStudentAccountServices, StudentAccountServices>();
            services.AddScoped<IStudentServices, StudentServices>();
            services.AddScoped<IStudentTollServices, StudentTollServices>();
            services.AddScoped<ITransactionServices, TransactionServices>();
            services.AddScoped<IUserServices, UserServices>();

        }
    }
}