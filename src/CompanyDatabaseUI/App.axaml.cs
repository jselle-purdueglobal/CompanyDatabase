using System;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using CompanyDatabaseUI.Extensions;
using CompanyDatabaseUI.ViewModels;
using CompanyDatabaseUI.Views;
using Microsoft.Extensions.DependencyInjection;
using ReactiveUI;

namespace CompanyDatabaseUI;

public partial class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        var collection = new ServiceCollection();
        collection.AddCommonServices();

        var services = collection.BuildServiceProvider();

        var vm = services.GetRequiredService<IScreen>();
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            desktop.MainWindow = new AppShellView
            {
                DataContext = vm
            };
        }

        base.OnFrameworkInitializationCompleted();
    }
}