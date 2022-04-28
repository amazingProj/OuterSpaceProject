using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI.Core;
using UI.MVVM.Model;

namespace UI.MVVM.ViewModel
{
    class MediaViewModel : ObservableObject
    {
        private MainViewModel mainViewModel;
        TextBoxQuery textBoxQuery = new TextBoxQuery();
        public MediaViewModel()
        {

        }

        public MediaViewModel(MainViewModel _mainViewModel)
        {
            mainViewModel = _mainViewModel;
        }

        public String Data
        {
            get { return textBoxQuery.Query; }
            set
            {
                if (value != textBoxQuery.Query)
                {
                    textBoxQuery.Query = value;
                    OnPropertyChanged();
                }
            }
        }
    }
}
