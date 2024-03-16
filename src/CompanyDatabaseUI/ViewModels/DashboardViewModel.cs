using System.Collections.ObjectModel;
using System.Threading.Tasks;
using CompanyDatabaseUI.Models;
using CompanyDatabaseUI.Services;
using ReactiveUI;
using System.Reactive.Concurrency;

namespace CompanyDatabaseUI.ViewModels;

public class DashboardViewModel : ViewModelBase
{
    // Customer list properties
    private ObservableCollection<Customer> _customerList = null!;
    public ObservableCollection<Customer> CustomerList
    {
        get => _customerList;
        set => this.RaiseAndSetIfChanged(ref _customerList, value);
    }
    
    // Customer count properties
    private int _count;
    public int Count
    {
        get => _count;
        set
        {
            this.RaiseAndSetIfChanged(ref _count, value);
            this.RaisePropertyChanged(nameof(CustomerCount));
        }
    }
    public string CustomerCount => $"Customers: {Count}";
    
    private readonly ICustomerApiService _customerService;

    public DashboardViewModel(ICustomerApiService customerService)
    {
        _customerService = customerService;
        RxApp.MainThreadScheduler.Schedule(LoadCustomerList);
    }

    private async void LoadCustomerList()
    {
        var customerList = await _customerService.GetCustomerListAsync();
        CustomerList = new ObservableCollection<Customer>(customerList);
        Count = await _customerService.GetCustomerCountAsync();
    }
}