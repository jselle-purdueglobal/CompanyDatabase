using ReactiveUI;

namespace CompanyDatabaseUI.ViewModels;

public class SalesDashboardViewModel : ViewModelBase, IRoutableViewModel
{
    public string UrlPathSegment { get; }
    public IScreen HostScreen { get; }
    
    public SalesDashboardViewModel(IScreen hostScreen)
    {
        UrlPathSegment = "Sales";
        HostScreen = hostScreen;
    }
}