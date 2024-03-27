using System;
using System.Reactive.Disposables;
using System.Reactive.Threading.Tasks;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using CompanyDatabaseUI.ViewModels;
using ReactiveUI;

namespace CompanyDatabaseUI.Views;

public partial class HRDashboardView : ReactiveUserControl<HRDashboardViewModel>
{
    public HRDashboardView()
    {
        InitializeComponent();
        this.WhenActivated(disposables =>
        {
            ViewModel!.LoadData().ToObservable().Subscribe().DisposeWith(disposables);
        });
    }
}