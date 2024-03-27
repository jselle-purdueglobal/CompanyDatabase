using CompanyDatabaseUI.Factories;
using CompanyDatabaseUI.Services;
using CompanyDatabaseUI.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using ReactiveUI;

namespace CompanyDatabaseUI.Extensions;

public static class ServiceCollectionExtensions {
    public static void AddCommonServices(this IServiceCollection collection) {
        collection.AddHttpClient();
        collection.AddTransient<ICustomerService, CustomerService>();
        collection.AddSingleton<IScreen, AppShellViewModel>();
        collection.AddTransient<ILoginViewModelFactory, LoginViewModelFactory>();
        collection.AddTransient<IAuthService, AuthService>();
        collection.AddTransient<LoginViewModel>();
        collection.AddTransient<CEODashboardViewModel>();
        collection.AddTransient<HRDashboardViewModel>();
        collection.AddTransient<SalesDashboardViewModel>();
    }
}