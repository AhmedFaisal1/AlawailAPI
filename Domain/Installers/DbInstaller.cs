using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using AlawailApi.Domain.Helpers;
using AlawailApi.Domain.Repositories;

namespace AlawailApi.Domain.Installers
{
    public class DbInstaller: IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseMySql(configuration.GetConnectionString("DefaultConnection"),
                        new MariaDbServerVersion(new Version(8, 0, 21)),
                        mySqlOptions => mySqlOptions
                            .CharSetBehavior(CharSetBehavior.NeverAppend))
                    .EnableSensitiveDataLogging()
                    .EnableDetailedErrors());
            
             services.AddScoped<IDepartmentRepository, DepartmentRepositories>();
            services.AddScoped<IEmployeeAccountRepository, EmployeeAccountRepositories>();
            services.AddScoped<IEmployeeRepository, EmployeeRepositories>();
            services.AddScoped<IRoleRepository, RoleRepositories>();
            services.AddScoped<IStudentAccountRepository, StudentAccountRepositories>();
            services.AddScoped<IStudentRepository, StudentRepositories>();
            services.AddScoped<IStudenTollRepository, StudenTollRepositories>();
            services.AddScoped<ITransactionRepository, TransactionRepositories>();
            services.AddScoped<IUserRepository, UserRepositories>();

        }
    }
}