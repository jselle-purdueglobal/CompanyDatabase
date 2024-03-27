using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using CompanyDatabaseUI.ViewModels;

namespace CompanyDatabaseUI.Views;

public partial class HRDashboardView : ReactiveUserControl<HRDashboardViewModel>
{
    public HRDashboardView()
    {
        InitializeComponent();
    }
}