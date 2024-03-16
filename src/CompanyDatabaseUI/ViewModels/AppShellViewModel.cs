using System;
using Microsoft.Extensions.DependencyInjection;
using ReactiveUI;

namespace CompanyDatabaseUI.ViewModels;

public class AppShellViewModel : ViewModelBase
{
    private readonly IServiceProvider _serviceProvider;
    private ViewModelBase _contentViewModel = null!;
    public ViewModelBase ContentViewModel
    {
        get => _contentViewModel;
        private set => this.RaiseAndSetIfChanged(ref _contentViewModel, value);
    }

    public AppShellViewModel(IServiceProvider serviceProvider, LoginViewModel loginViewModel)
    {
        _serviceProvider = serviceProvider;
        ContentViewModel = loginViewModel;
    }
    
    public void Login()
    {
        ContentViewModel = _serviceProvider.GetService<DashboardViewModel>();
    }
}