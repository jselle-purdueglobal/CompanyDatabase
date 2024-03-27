using ReactiveUI;

namespace CompanyDatabaseUI.ViewModels;

public class HRDashboardViewModel : ViewModelBase, IRoutableViewModel
{
    public string UrlPathSegment { get; }
    public IScreen HostScreen { get; }

    public HRDashboardViewModel(IScreen hostScreen)
    {
        UrlPathSegment = "HR";
        HostScreen = hostScreen;
    }
}