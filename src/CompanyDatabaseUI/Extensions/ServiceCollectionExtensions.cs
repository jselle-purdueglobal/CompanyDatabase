using CompanyDatabaseUI.Services;
using CompanyDatabaseUI.ViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace CompanyDatabaseUI.Extensions;

public static class ServiceCollectionExtensions {
    public static void AddCommonServices(this IServiceCollection collection) {
        collection.AddSingleton<AppShellViewModel>();
        collection.AddTransient<DashboardViewModel>();
        collection.AddTransient<LoginViewModel>();
        collection.AddTransient<ICustomerApiService, CustomerApiService>();
        collection.AddHttpClient();
    }
}