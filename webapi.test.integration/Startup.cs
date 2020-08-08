using System;
using Microsoft.Extensions.DependencyInjection;
using SolidToken.SpecFlow.DependencyInjection;
using webapi.test.integration.Steps;

namespace webapi.test.integration
{
    public static class Startup
    {

        [ScenarioDependencies]
        public static IServiceCollection CreateServices()
        {
            var services = new ServiceCollection();

            services.AddHttpClient(nameof(StepDefinition1),
                client => { client.BaseAddress = new Uri("https://localhost:44347/"); });

            services.AddTransient<MyContext>();

            // TODO: add your test dependencies here
            // NOTE: since v0.4.0 it's no longer necessary to manually add your [Binding] classes

            return services;
        }

    }
}