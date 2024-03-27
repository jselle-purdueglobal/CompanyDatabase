using CompanyDatabaseUI.ViewModels;
using ReactiveUI;

namespace CompanyDatabaseUI.Factories;

public interface ILoginViewModelFactory
{
    LoginViewModel Create(IScreen hostScreen);
}