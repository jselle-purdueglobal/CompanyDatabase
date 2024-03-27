using System;
using CompanyDatabaseUI.ViewModels;
using CompanyDatabaseUI.Views;
using ReactiveUI;

namespace CompanyDatabaseUI;

public class AppViewLocator : IViewLocator
{
    public IViewFor ResolveView<T>(T viewModel, string contract = null) => viewModel switch
    {
        CEODashboardViewModel context => new CEODashboardView { DataContext = context },
        HRDashboardViewModel context => new HRDashboardView { DataContext = context },
        SalesDashboardViewModel context => new SalesDashboardView { DataContext = context },
        LoginViewModel context => new LoginView { DataContext = context },
        AppShellViewModel context => new AppShellView { DataContext = context},
        _ => throw new ArgumentOutOfRangeException(nameof(viewModel))
    };
}