using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using CompanyDatabaseUI.ViewModels;

namespace CompanyDatabaseUI.Views;

public partial class SalesDashboardView : ReactiveUserControl<SalesDashboardViewModel>
{
    public SalesDashboardView()
    {
        InitializeComponent();
    }
}