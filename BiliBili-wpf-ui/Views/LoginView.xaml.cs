using System.Windows;
using System.Windows.Controls;
using BiliBili_ViewModel.ViewModels;

namespace BiliBili_wpf_ui.Views;

/// <summary>
/// LoginView.xaml 的交互逻辑
/// </summary>
public partial class LoginView : UserControl
{
    private LoginViewModel? _viewModel;
    
    public LoginView()
    {
        InitializeComponent();
        
        // 监听DataContext变化
        DataContextChanged += LoginView_DataContextChanged;
        
        // 监听密码框变化
        PasswordBox.PasswordChanged += PasswordBox_PasswordChanged;
    }
    
    private void LoginView_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
    {
        // 解除旧的ViewModel事件
        if (_viewModel != null)
        {
            _viewModel.PropertyChanged -= ViewModel_PropertyChanged;
        }
        
        // 设置新的ViewModel
        _viewModel = DataContext as LoginViewModel;
        
        if (_viewModel != null)
        {
            // 监听ViewModel属性变化
            _viewModel.PropertyChanged += ViewModel_PropertyChanged;
            
            // 初始设置密码
            PasswordBox.Password = _viewModel.Password;
        }
    }
    
    private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
    {
        // 将密码框的值同步到ViewModel
        if (_viewModel != null)
        {
            _viewModel.Password = PasswordBox.Password;
        }
    }
    
    private void ViewModel_PropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
    {
        // 当ViewModel的Password属性变化时，更新密码框
        if (e.PropertyName == nameof(LoginViewModel.Password))
        {
            if (_viewModel != null && PasswordBox.Password != _viewModel.Password)
            {
                PasswordBox.Password = _viewModel.Password;
            }
        }
    }
} 