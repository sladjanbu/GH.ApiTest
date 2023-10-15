using GH.Application.Contracts.Infrastructure;
using GH.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace GH.Infrastructure
{
    public static class DependencyInjection
    {
        public static void AddInfrastructureServices(this IServiceCollection services)
        {

            services.AddHttpClient<IGitHubService, GitHubService>();
        }
    }
}
