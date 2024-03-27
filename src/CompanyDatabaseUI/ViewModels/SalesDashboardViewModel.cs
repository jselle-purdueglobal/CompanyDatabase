using System.Collections.ObjectModel;
using System.Threading.Tasks;
using CompanyDatabaseUI.Models;
using CompanyDatabaseUI.Services;
using ReactiveUI;

namespace CompanyDatabaseUI.ViewModels;

public class SalesDashboardViewModel : ViewModelBase, IRoutableViewModel
{
    public string UrlPathSegment { get; }
    public IScreen HostScreen { get; }
    private ObservableCollection<Customer> _customerList = null!;
    private ObservableCollection<Order> _orderList = null!;
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
    private int _customerCount;
    private int _orderCount;
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
    public string CustomerTotal => $"Customers: {CustomerCount}";
    public string OrderTotal => $"Orders: {OrderCount}";
    private readonly ICustomerService _customerService;
    private readonly IOrderService _orderService;
    public SalesDashboardViewModel(IScreen hostScreen, ICustomerService customerService, IOrderService orderService)
    {
        _customerService = customerService;
        _orderService = orderService;
        UrlPathSegment = "Sales";
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
    }
}