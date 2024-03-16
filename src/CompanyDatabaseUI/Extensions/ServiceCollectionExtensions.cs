using CompanyDatabaseUI.Services;
using CompanyDatabaseUI.ViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace CompanyDatabaseUI.Extensions;

public static class ServiceCollectionExtensions {
    public static void AddCommonServices(this IServiceCollection collection) {
        collection.AddSingleton<DashboardViewModel>();
        collection.AddTransient<ICustomerApiService, CustomerApiService>();
        collection.AddHttpClient();
    }
}