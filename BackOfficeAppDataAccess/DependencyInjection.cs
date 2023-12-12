using BackOfficeAppDataAccess.DbAccess;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BackOfficeAppDataAccess
{
    public static class DependencyInjection
    {
        public static void AddDataAccess(this IServiceCollection services)
        {
            //services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddSingleton<ISqlDataAccess, SqlDataAccess>();
        }
    }
}
