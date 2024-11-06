using Microsoft.Extensions.DependencyInjection;
using Netsoft.AtlantisCMS.Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Netsoft.AtlantisCMS.DalEfCore
{
    public static class ConfigurationExtensions
    {
        public static void AddDalEfCore(this IServiceCollection services)
        {
            services.AddScoped<DbContext>();
            //services.AddTransient<IOnlinePagesDal, OnlinePageDal>();
            services.AddTransient<IOnlinePageDal, OnlinePageDal>();
            services.AddTransient<IOnlinePageComponentDal, OnlinePageComponentDal>();
            services.AddTransient<IOnlineStringDal, OnlineStringDal>();
            services.AddTransient<ITestingTableDal, TestingTableDal>();
        }
    }
}
