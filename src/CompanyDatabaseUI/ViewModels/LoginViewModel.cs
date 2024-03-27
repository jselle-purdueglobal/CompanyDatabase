using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Reactive;
using System.Threading.Tasks;
using CompanyDatabaseUI.Models;
using CompanyDatabaseUI.Services;
using Microsoft.Extensions.DependencyInjection;
using ReactiveUI;

namespace CompanyDatabaseUI.ViewModels;

public class LoginViewModel : ViewModelBase, IRoutableViewModel
{
    private readonly IServiceProvider _serviceProvider;
    private readonly IAuthService _authService;
    private string _username;
    private string _password;
    private string _server;
    private string _database;
    private string _statusMessage;
    public string UrlPathSegment { get; }
    public IScreen HostScreen { get; }
    public ObservableCollection<string> Servers { get; } = new ObservableCollection<string> { "localhost" };
    public ObservableCollection<string> Databases { get; } = new ObservableCollection<string> { "Northwind" };
    public ReactiveCommand<Unit, Unit> LoginCommand { get; }
    public string Username
    {
        get => _username;
        set => this.RaiseAndSetIfChanged(ref _username, value);
    }
    public string Password
    {
        get => _password;
        set => this.RaiseAndSetIfChanged(ref _password, value);
    }
    public string Server
    {
        get => _server;
        set => this.RaiseAndSetIfChanged(ref _server, value);
    }
    public string Database
    {
        get => _database;
        set => this.RaiseAndSetIfChanged(ref _database, value);
    }

    public string StatusMessage
    {
        get => _statusMessage;
        set => this.RaiseAndSetIfChanged(ref _statusMessage, value);
    }
    public LoginViewModel(IScreen hostScreen, IAuthService authService, IServiceProvider serviceProvider)
    {
        UrlPathSegment = "Login";
        HostScreen = hostScreen;
        _authService = authService;
        _serviceProvider = serviceProvider;
        var canLogin = this.WhenAnyValue(

            x => x.Username,
            x => x.Password,
            x => x.Server,
            x => x.Database,
            (username, password, server, database) => !string.IsNullOrWhiteSpace(username) &&
                                                      !string.IsNullOrWhiteSpace(password) &&
                                                      !string.IsNullOrWhiteSpace(server) &&
                                                      !string.IsNullOrWhiteSpace(database));
        LoginCommand = ReactiveCommand.CreateFromTask(LoginAsync, canLogin);
    }

    private async Task LoginAsync()
    {
        IsBusy = true;
        var (isAuthenticated, user) = await _authService.AuthenticateAsync(Username, Password);
        if (isAuthenticated)
        {
            switch (user.Role)
            {
                case "CEORole":
                    HostScreen.Router.Navigate.Execute(_serviceProvider.GetService<CEODashboardViewModel>()!);
                    break;
                case "HRRole":
                    HostScreen.Router.Navigate.Execute(_serviceProvider.GetService<HRDashboardViewModel>()!);
                    break;
                case "SalesRole":
                    HostScreen.Router.Navigate.Execute(_serviceProvider.GetService<SalesDashboardViewModel>()!);
                    break;
            }
        }
        else
        {
            StatusMessage = "Error: Invalid login credentials";
        }
        IsBusy = false;
    }
}