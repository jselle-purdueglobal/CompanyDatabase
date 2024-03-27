using System.Collections.ObjectModel;
using System.Threading.Tasks;
using CompanyDatabaseUI.Models;
using CompanyDatabaseUI.Services;
using ReactiveUI;

namespace CompanyDatabaseUI.ViewModels;

public class CEODashboardViewModel : ViewModelBase, IRoutableViewModel
{
    public string UrlPathSegment { get; }
    public IScreen HostScreen { get; }
    
    private ObservableCollection<Customer> _customerList = null!;
    private ObservableCollection<Order> _orderList = null!;
    private ObservableCollection<Employee> _employeeList = null!;
    public ObservableCollection<Customer> CustomerList
    {
        get => _customerList;
        set => this.RaiseAndSetIfChanged(ref _customerList, value);
    }
    public ObservableCollection<Order> OrderList
    {
        get => _orderList;
        set => this.RaiseAndSetIfChanged(ref _orderList, value);
    }
    public ObservableCollection<Employee> EmployeeList
    {
        get => _employeeList;
        set => this.RaiseAndSetIfChanged(ref _employeeList, value);
    }
    
    private int _customerCount;
    private int _orderCount;
    private int _employeeCount;
    public int CustomerCount
    {
        get => _customerCount;
        set
        {
            this.RaiseAndSetIfChanged(ref _customerCount, value);
            this.RaisePropertyChanged(nameof(CustomerTotal));
        }
    }
    public int OrderCount
    {
        get => _orderCount;
        set
        {
            this.RaiseAndSetIfChanged(ref _orderCount, value);
            this.RaisePropertyChanged(nameof(OrderTotal));
        }
    }
    public int EmployeeCount
    {
        get => _employeeCount;
        set
        {
            this.RaiseAndSetIfChanged(ref _employeeCount, value);
            this.RaisePropertyChanged(nameof(EmployeeTotal));
        }
    }
    public string CustomerTotal => $"Customers: {CustomerCount}";
    public string OrderTotal => $"Orders: {OrderCount}";
    public string EmployeeTotal => $"Employees: {EmployeeCount}";
    
    private readonly ICustomerService _customerService;
    private readonly IOrderService _orderService;
    private readonly IEmployeeService _employeeService;
    public CEODashboardViewModel(IScreen hostScreen, ICustomerService customerService, IOrderService orderService, IEmployeeService employeeService)
    {
        _customerService = customerService;
        _orderService = orderService;
        _employeeService = employeeService;
        UrlPathSegment = "CEO";
        HostScreen = hostScreen;
    }
    public async Task LoadData()
    {
        var customerList = await _customerService.GetCustomerListAsync();
        CustomerList = new ObservableCollection<Customer>(customerList);
        CustomerCount = await _customerService.GetCustomerCountAsync();
        var orderList = await _orderService.GetOrderListAsync();
        OrderList = new ObservableCollection<Order>(orderList);
        OrderCount = await _orderService.GetOrderCountAsync();
        var employeeList = await _employeeService.GetEmployeeListAsync();
        EmployeeList = new ObservableCollection<Employee>(employeeList);
        EmployeeCount = await _employeeService.GetEmployeeCountAsync();
    }
}