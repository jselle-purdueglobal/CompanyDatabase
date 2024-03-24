using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reactive;
using System.Threading.Tasks;
using CompanyDatabaseUI.Models;
using CompanyDatabaseUI.Services;
using ReactiveUI;

namespace CompanyDatabaseUI.ViewModels;

public class LoginViewModel : ViewModelBase
{
    private string _username;
    public string Username
    {
        get => _username;
        set => this.RaiseAndSetIfChanged(ref _username, value);
    }

    private string _password;
    public string Password
    {
        get => _password;
        set => this.RaiseAndSetIfChanged(ref _password, value);
    }

    private string _server;
    public string Server
    {
        get => _server;
        set => this.RaiseAndSetIfChanged(ref _server, value);
    }

    private string _database;
    public string Database
    {
        get => _database;
        set => this.RaiseAndSetIfChanged(ref _database, value);
    }
    
    public ObservableCollection<string> Servers { get; } = new ObservableCollection<string> { "localhost" };
    public ObservableCollection<string> Databases { get; } = new ObservableCollection<string> { "Northwind" };
    public ReactiveCommand<Unit, Unit> LoginCommand { get; }
    public LoginViewModel()
    {
        LoginCommand = ReactiveCommand.CreateFromTask(LoginAsync);
    }
    
    public async Task LoginAsync()
    {
        IsBusy = true;
        
        // Login/authentication logic
        // NavigateDashboard -- maybe send message?
        // await Task.Delay(2000);
        IsBusy = false;
    }
}