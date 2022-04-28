using Leadtools;
using Leadtools.Codecs;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;


namespace UI.MVVM.View
{
    /// <summary>
    /// Interaction logic for UploadImage.xaml
    /// </summary>
    public partial class UploadImage : UserControl
    {
        BL.IBL bL = new BL.BL();
        BitmapImage bitmapImage;
        string filePath;

        public UploadImage()
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
                    bitmapImage = new BitmapImage();
                    bitmapImage.BeginInit();
                    bitmapImage.UriSource = new Uri(files[0]);
                    bitmapImage.EndInit();
                    image.Source = bitmapImage;
                    filePath = files[0];
                    UploadButton.Visibility = Visibility.Visible;
                }
                else
                {
                    FileName.Content = "Not a dot png file. try again";
                    FileName.Foreground = new SolidColorBrush(Colors.Red);
                }



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
                filePath = dialog.FileName;
                FileName.Foreground = new SolidColorBrush(Colors.White);
                FileName.Content = dialog.FileName;
                bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.UriSource = new Uri(dialog.FileName);
                bitmapImage.EndInit();
                image.Source = bitmapImage;
                UploadButton.Visibility = Visibility.Visible;
            }
                     
        }

        private async void UploadButton_Click(object sender, RoutedEventArgs e)
        {
            PngBitmapEncoder pngBitmapEncoder = new PngBitmapEncoder();
            pngBitmapEncoder.Frames.Add(BitmapFrame.Create(bitmapImage));
            using (var stream = new MemoryStream())
            {
                pngBitmapEncoder.Save(stream);
                string stringPath = Convert.ToBase64String(stream.ToArray());
                string messageResponse = await bL.ImageUpload(stringPath, filePath);
                switch (messageResponse)
                {
                    case "is not a space related picture":
                        FileName.Content = Path.GetFileName(filePath) + " " + "is not a space related picture";
                        FileName.Foreground = new SolidColorBrush(Colors.Red);
                        UploadButton.Visibility = Visibility.Hidden;
                        break;
                    case "success":
                        FileName.Content = Path.GetFileName(filePath) + " " + "has successfully saved";
                        FileName.Foreground = new SolidColorBrush(Colors.White);
                        break;
                    case "failed to upload to firebase. Please try again":
                        FileName.Content = Path.GetFileName(filePath) + " " + "failed to upload to firebase. Please try again";
                        FileName.Foreground = new SolidColorBrush(Colors.Red);
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
