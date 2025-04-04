using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;

namespace BiliBili_wpf.ViewModels.Advance;

partial class NavigationViewModel : ObservableObject, INavigationContainer
{
    private readonly INavigationContainer _navigationService = App.Services.GetRequiredService<INavigationContainer>();

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(ReturnBackCommand))]
    private object? _current;

    public void Open(object page)
    {
        _navigationService.Open(page);
        Current = _navigationService.Current;
    }
    [RelayCommand(CanExecute = nameof(GetCanReturnBack))]
    public void ReturnBack()
    {
        if (Current is INavigationContainer { CanReturnBack: true } navigationContainer)
        {
            navigationContainer.ReturnBack();
            return;
        }
        _navigationService.ReturnBack();
        Current = _navigationService.Current;
    }

    public bool GetCanReturnBack() => CanReturnBack;
    public bool CanReturnBack =>
        _navigationService.CanReturnBack;

    
}