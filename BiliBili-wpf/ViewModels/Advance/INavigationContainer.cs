namespace BiliBili_wpf.ViewModels.Advance;

interface INavigationContainer
{
    void Open(object page);
    void ReturnBack();
    object? Current { get; }
    bool CanReturnBack { get; }
}