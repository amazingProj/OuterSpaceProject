using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

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

                FileName.Content = fileName;

                BL.IBL bL = new BL.BL();

            }

        }
    }
}
