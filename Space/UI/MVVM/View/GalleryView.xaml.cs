using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace UI.MVVM.View
{
    /// <summary>
    /// Interaction logic for GalleryView.xaml
    /// </summary>
    public partial class GalleryView : UserControl
    {
        public GalleryView()
        {
            InitializeComponent();
        }

        private void FileUpload_Event(object sender, DragEventArgs dragEventArgs)
        {
            //MainViewModel 
            string dropFile = DataFormats.FileDrop;
            IDataObject data = dragEventArgs.Data;
            bool isAvailable = data.GetDataPresent(dropFile);
            if (isAvailable)
            {
                string[] files = (string[])data.GetData(dropFile);

                string fileName = Path.GetFileName(files[0]);

                FileInfo fi = new FileInfo(fileName);

                if (fi.Extension == ".png")
                {
                    FileName.Content = fileName;
                    FileName.Foreground = new SolidColorBrush(Colors.White);

                }
                else 
                {
                    FileName.Content = "Not a dot png file. try again";
                    FileName.Foreground = new SolidColorBrush(Colors.Red);
                }

                BL.IBL bL = new BL.BL();

            }

        }

        private void StackPanel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog
            {
                Filter = "Files|*.png",
                InitialDirectory = @"C:\"
            };
            Nullable<bool> result = dialog.ShowDialog();
            if (result == true)
            {
                FileName.Content = dialog.FileName;
            }
            
        }
    }
}
