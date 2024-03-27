using System;
using CompanyDatabaseUI.Services;
using CompanyDatabaseUI.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using ReactiveUI;

namespace CompanyDatabaseUI.Factories;

public class LoginViewModelFactory(IServiceProvider serviceProvider) : ILoginViewModelFactory
{
    public LoginViewModel Create(IScreen hostScreen)
    {
        var authService = serviceProvider.GetRequiredService<IAuthService>();
        return new LoginViewModel(hostScreen, authService, serviceProvider);
    }
}