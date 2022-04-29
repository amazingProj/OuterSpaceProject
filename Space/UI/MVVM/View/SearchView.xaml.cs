using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace UI.MVVM.View
{
    /// <summary>
    /// Interaction logic for SearchView.xaml
    /// </summary>
    public partial class SearchView : UserControl
    {
        string dateNow;

        private const string datePickerHint = "Select initial date";
        const string datePickerHintEnd = "Select end date";

        public SearchView()
        {
            InitializeComponent();
            MonthlyCalendarStart.DisplayDate = DateTime.UtcNow;
        }

        private void DatePicker_Loaded(object sender, RoutedEventArgs e)
        {
            DatePicker datePicker = sender as DatePicker;
            if (datePicker != null)
            {
                System.Windows.Controls.Primitives.DatePickerTextBox datePickerTextBox = FindVisualChild<System.Windows.Controls.Primitives.DatePickerTextBox>(datePicker);
                if (datePickerTextBox != null)
                {

                    ContentControl watermark = datePickerTextBox.Template.FindName("PART_Watermark", datePickerTextBox) as ContentControl;
                    if (watermark != null)
                    {
                        watermark.Content = datePickerHint;
                    }
                }
            }
        }

        private void DatePicker_LoadedEnd(object sender, RoutedEventArgs e)
        {
            DatePicker datePicker = sender as DatePicker;
            if (datePicker != null)
            {
                System.Windows.Controls.Primitives.DatePickerTextBox datePickerTextBox = FindVisualChild<System.Windows.Controls.Primitives.DatePickerTextBox>(datePicker);
                if (datePickerTextBox != null)
                {

                    ContentControl watermark = datePickerTextBox.Template.FindName("PART_Watermark", datePickerTextBox) as ContentControl;
                    if (watermark != null)
                    {
                        watermark.Content = datePickerHintEnd;
                    }
                }
            }
        }

        private T FindVisualChild<T>(DependencyObject depencencyObject) where T : DependencyObject
        {
            if (depencencyObject != null)
            {
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depencencyObject); ++i)
                {
                    DependencyObject child = VisualTreeHelper.GetChild(depencencyObject, i);
                    T result = (child as T) ?? FindVisualChild<T>(child);
                    if (result != null)
                        return result;
                }
            }

            return null;
        }

        private void dpick_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            OptionalPickers.Visibility = Visibility.Visible;
            EndDatePicker.SelectedDate = MonthlyCalendarStart.SelectedDate;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string initialDate = MonthlyCalendarStart.SelectedDate.Value.Year.ToString() + "-" +
                MonthlyCalendarStart.SelectedDate.Value.Month.ToString() + "-" +
                MonthlyCalendarStart.SelectedDate.Value.Day.ToString();


        }
    }
}
