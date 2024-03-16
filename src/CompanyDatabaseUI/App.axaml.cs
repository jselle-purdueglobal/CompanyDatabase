using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using CompanyDatabaseUI.ViewModels;
using CompanyDatabaseUI.Views;

namespace CompanyDatabaseUI;

public partial class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            desktop.MainWindow = new DashboardView
            {
                DataContext = new DashboardViewModel(),
            };
        }

        base.OnFrameworkInitializationCompleted();
    }
}