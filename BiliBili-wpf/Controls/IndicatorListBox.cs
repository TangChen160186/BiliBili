using System.Collections;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace BiliBili_wpf.Controls;

[TemplatePart(Name = "PART_Indicator",Type = typeof(Border))]
[TemplatePart(Name = "PART_HostPanel",Type = typeof(WrapPanel))]
[TemplatePart(Name = "PART_Transform",Type = typeof(TranslateTransform))]
public class IndicatorListBox : ListBox
{
    private  Border _indicator;
    private WrapPanel _hostPanel;

    private bool _itemSourceChanged;
    static IndicatorListBox()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(IndicatorListBox), new FrameworkPropertyMetadata(typeof(IndicatorListBox)));
    }

    public override void OnApplyTemplate()
    {
        base.OnApplyTemplate();
        _hostPanel = (Template.FindName("PART_HostPanel", this) as WrapPanel)!;
        _indicator = (Template.FindName("PART_Indicator", this) as Border)!;
        
        Loaded += (_, _) =>
        {
            UpdateIndicatorPosition(false);
        };
    }
    
    protected override void OnSelectionChanged(SelectionChangedEventArgs e)
    {
        base.OnSelectionChanged(e);

        if (IsLoaded)
        {
            UpdateIndicatorPosition(!_itemSourceChanged);
            if (_itemSourceChanged) _itemSourceChanged = false;
        }
    }

    protected override void OnItemsSourceChanged(IEnumerable oldValue, IEnumerable newValue)
    {
        _itemSourceChanged = true;
        base.OnItemsSourceChanged(oldValue, newValue);
    }

    private void UpdateIndicatorPosition(bool animate)
    {
        if (ItemsSource == null || SelectedItem == null)
        {
            _indicator.Visibility = Visibility.Collapsed;
            return;
        }

        _indicator.Visibility = Visibility.Visible;
        var transform = (Template.FindName("PART_Transform", this) as TranslateTransform)!;
        if (ItemContainerGenerator.ContainerFromItem(SelectedItem) is ListBoxItem currentItem)
        {
            if (_hostPanel.DesiredSize.Width > 0 && currentItem.DesiredSize.Width > 0)
            {
                var containerPoint = currentItem.TranslatePoint(new Point(0, 0), _hostPanel);
                var targetOffset = containerPoint.X + (currentItem.DesiredSize.Width - _indicator.ActualWidth - currentItem.Margin.Left) / 2;

                if (animate)
                {
                    var animation = new DoubleAnimation
                    {
                        To = targetOffset,
                        Duration = TimeSpan.FromSeconds(0.3),
                        EasingFunction = new QuinticEase
                        {
                            EasingMode = EasingMode.EaseInOut
                        }
                    };

                    transform.BeginAnimation(TranslateTransform.XProperty, animation);
                }
                else
                {
                    transform.BeginAnimation(TranslateTransform.XProperty, null);
                    transform.X = targetOffset;
                }
                
            }
        }
    }
}