using BiliBili_wpf.ViewModels.Advance;

namespace BiliBili_wpf.Services;

class NavigationService: INavigationContainer
{
    private readonly Stack<object> _pagesHistory = new();

    public object? Current { get; private set; }

    public bool CanReturnBack => _pagesHistory.Count > 0 ||
                                 Current is INavigationContainer { CanReturnBack: true };


    public void Open(object page)
    {
        if (Current != page && Current != null)
        {
            _pagesHistory.Push(Current);
        }

        Current = page;
    }

    public void ReturnBack()
    {
        if (Current is INavigationContainer { CanReturnBack: true } navigationContainer)
        {
            navigationContainer.ReturnBack();
            return;
        }
        if (_pagesHistory.Count > 0)
        {
            Current = _pagesHistory.Pop();
        }
    }
}