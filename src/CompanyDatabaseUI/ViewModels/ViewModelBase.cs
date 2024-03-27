using System;
using ReactiveUI;

namespace CompanyDatabaseUI.ViewModels;

public class ViewModelBase : ReactiveObject
{
    private bool _isBusy;
    public bool IsBusy
    {
        get => _isBusy;
        set => this.RaiseAndSetIfChanged(ref _isBusy, value);
    }
}