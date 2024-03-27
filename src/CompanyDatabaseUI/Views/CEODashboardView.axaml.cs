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

public partial class CEODashboardView : ReactiveUserControl<CEODashboardViewModel>
{
    public CEODashboardView()
    {
        InitializeComponent();
        this.WhenActivated(disposables =>
        {
            ViewModel!.LoadData().ToObservable().Subscribe().DisposeWith(disposables);
        });
    }
}