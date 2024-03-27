using System;
using CompanyDatabaseUI.Factories;
using CompanyDatabaseUI.Views;
using Microsoft.Extensions.DependencyInjection;
using ReactiveUI;
using Splat;

namespace CompanyDatabaseUI.ViewModels;

public class AppShellViewModel : ViewModelBase, IScreen
{
    public RoutingState Router { get; }
    public AppShellViewModel(IServiceProvider serviceProvider)
    {
        Router = new RoutingState();
        var factory = serviceProvider.GetRequiredService<ILoginViewModelFactory>();
        Router.Navigate.Execute(factory.Create(this));
    }
}