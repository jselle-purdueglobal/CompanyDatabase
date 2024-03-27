using System.Collections.ObjectModel;
using System.Threading.Tasks;
using CompanyDatabaseUI.Models;
using CompanyDatabaseUI.Services;
using ReactiveUI;

namespace CompanyDatabaseUI.ViewModels;

public class HRDashboardViewModel : ViewModelBase, IRoutableViewModel
{
    public string UrlPathSegment { get; }
    public IScreen HostScreen { get; }
    private readonly IEmployeeService _employeeService;
    private ObservableCollection<Employee> _employeeList = null!;
    public ObservableCollection<Employee> EmployeeList
    {
        get => _employeeList;
        set => this.RaiseAndSetIfChanged(ref _employeeList, value);
    }
    private int _employeeCount;
    private int EmployeeCount
    {
        get => _employeeCount;
        set
        {
            this.RaiseAndSetIfChanged(ref _employeeCount, value);
            this.RaisePropertyChanged(nameof(EmployeeTotal));
        }
    }
    public string EmployeeTotal => $"Employees: {EmployeeCount}";
    public HRDashboardViewModel(IScreen hostScreen, IEmployeeService employeeService)
    {
        _employeeService = employeeService;
        UrlPathSegment = "HR";
        HostScreen = hostScreen;
    }
    public async Task LoadData()
    {
        var employeeList = await _employeeService.GetEmployeeListAsync();
        EmployeeList = new ObservableCollection<Employee>(employeeList);
        EmployeeCount = await _employeeService.GetEmployeeCountAsync();
    }
}