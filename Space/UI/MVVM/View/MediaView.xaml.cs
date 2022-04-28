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
using UI.MVVM.ViewModel;

namespace UI.MVVM.View
{
    /// <summary>
    /// Interaction logic for MediaView.xaml
    /// </summary>
    public partial class MediaView : UserControl
    {
        BL.IBL bL = new BL.BL();
        MediaViewModel mediaViewModel;

        public MediaView()
        {
            InitializeComponent();
            mediaViewModel = (MediaViewModel) DataContext;
        }

        private void TextBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            string text = SearchBar.Text;
            List<Dictionary<string, string>> imageDetails = bL.GetAllImageSearch(text);
            int x = 0;
        }
    }
}
