using Avalonia.Controls;
using Avalonia.ReactiveUI;
using CompanyDatabaseUI.ViewModels;
using ReactiveUI;

namespace CompanyDatabaseUI.Views;

public partial class AppShellView : ReactiveWindow<AppShellViewModel>
{
    public AppShellView()
    {
        InitializeComponent();
        this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
    }
}