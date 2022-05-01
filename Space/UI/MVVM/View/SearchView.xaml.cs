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
        string dateNow; /// <summary>
        /// ///////
        /// </summary>

        List<string> ListAsteroidNames = new List<string>();
        double radius = 0;


        BL.IBL bl = new BL.BL();

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
            EndDatePicker.DisplayDateStart = MonthlyCalendarStart.SelectedDate;
            SearchButton.Visibility = Visibility.Visible;
        }

        private void Button_Click(object sender, RoutedEventArgs e)  // search
        {
            string initialDate = MonthlyCalendarStart.SelectedDate.Value.Year.ToString() + "-" +
                MonthlyCalendarStart.SelectedDate.Value.Month.ToString() + "-" +
                MonthlyCalendarStart.SelectedDate.Value.Day.ToString();


            string future = EndDatePicker.SelectedDate.Value.Year.ToString() + "-" +
                EndDatePicker.SelectedDate.Value.Month.ToString() + "-" +
                EndDatePicker.SelectedDate.Value.Day.ToString(); 


            List<Dictionary<string, string>> Listdictionary=null;

          

            if (DangerCB.IsChecked == true && RadiusTB.Text != "")
            {
                radius = Double.Parse(RadiusTB.Text);

                Listdictionary = bl.GetOnlyDangerous(initialDate, future, radius);  

            }
            if (DangerCB.IsChecked == true && RadiusTB.Text == null)
            {
                Listdictionary = bl.GetOnlyDangerous(initialDate, future);
            }
            else
            {
                if (RadiusTB.Text != "")
                {
                    radius = Double.Parse(RadiusTB.Text);

                    Listdictionary = bl.GetAllAsteroids(initialDate, future, radius);
                }
                else {Listdictionary = bl.GetAllAsteroids(initialDate, future); }
            }


            foreach (var dic in Listdictionary)
            {
                ListAsteroidNames.Add(dic["Name"]);
            }

            Dispatcher.Invoke(() =>
            {
                List_asteroids.DataContext = ListAsteroidNames;

            });

            ResultsLB.Visibility = Visibility.Visible;
            StackResults.Visibility = Visibility.Visible;

        }

        private void List_asteroids_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string initialDate = MonthlyCalendarStart.SelectedDate.Value.Year.ToString() + "-" +
               MonthlyCalendarStart.SelectedDate.Value.Month.ToString() + "-" +
               MonthlyCalendarStart.SelectedDate.Value.Day.ToString();


            string future = EndDatePicker.SelectedDate.Value.Year.ToString() + "-" +
                EndDatePicker.SelectedDate.Value.Month.ToString() + "-" +
                EndDatePicker.SelectedDate.Value.Day.ToString();

            try
            {
                if (List_asteroids.SelectedItem != null)
                {

                    List<Dictionary<string, string>> Listdictionary;


                    if (DangerCB.IsChecked == true && RadiusTB.Text != "")
                    {
                        radius = Double.Parse(RadiusTB.Text);

                        Listdictionary = bl.GetOnlyDangerous(initialDate, future, radius);

                    }
                    if (DangerCB.IsChecked == true && RadiusTB.Text == null)
                    {
                        Listdictionary = bl.GetOnlyDangerous(initialDate, future);
                    }
                    else
                    {
                        if (RadiusTB.Text != "")
                        {
                            radius = Double.Parse(RadiusTB.Text);

                            Listdictionary = bl.GetAllAsteroids(initialDate, future, radius);
                        }
                        else { Listdictionary = bl.GetAllAsteroids(initialDate, future); }
                    }

                    foreach (var dic in Listdictionary)
                    {

                        if (dic["Name"] == (List_asteroids.SelectedItem).ToString())
                        {
                            try
                            {
                                DateTB.Text = dic["close_approach_date_full"]; // Date complete
                                NameTB.Text = dic["Name"];
                                DistanceTB.Text = dic["MissDistanceKilometers"] + " Km";
                                DiamMinTB.Text = "Min : " + dic["estimated_diameter_min_Means_Koter_meters"] + " m";
                                DiamMaxTB.Text = "Max : " + dic["estimated_diameter_max_Means_Koter_meters"] + " m";
                                VitessTB.Text = dic["kilometers_per_hour"] + " Km/h";

                                if (dic["IsPotentiallyHazardousAsteroids"] == "IsPotentiallyHazardousAsteroids")
                                {
                                    Dangerous.Visibility = Visibility.Visible;
                                }
                            }

                            catch { }

                        }



                        //        //name = ((Listdictionary.SelectedItem as BO.Station).name);

                        //    }
                        //}

                    }
                }
            }

            catch { }
        }
    }
}
