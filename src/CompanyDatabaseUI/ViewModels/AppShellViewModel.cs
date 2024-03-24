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

    public AppShellViewModel(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
        LoginViewModel = _serviceProvider.GetService<LoginViewModel>()!;
        _contentViewModel = LoginViewModel;
        IsBusy = false;
    }

    private ViewModelBase LoginViewModel { get; }
    public void NavigateDashboard()
    {
        ContentViewModel = _serviceProvider.GetService<DashboardViewModel>()!;
    }
}