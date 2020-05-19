using Autofac;
using MutitleDBDataBatchUpdate.Models.Entitis;
using MutitleDBDataBatchUpdate.Models.Repos;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace MutitleDBDataBatchUpdate
{
    [ExcludeFromCodeCoverage]
    static class Program
    {
        private static IContainer CompositionRoot()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<Application>();
            builder.RegisterType<TestDbConnection>().As<ITestDbConnection>();
            builder.RegisterType<BatchRepository>().As<IBatchRepository>();
            return builder.Build();
        }

        static void Main(string[] args)
        {
            CompositionRoot().Resolve<Application>().Run();
        }

        
    }
}
