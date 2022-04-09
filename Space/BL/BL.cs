using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.IO;

namespace BL
{
    public class BL : IBL
    {
        DAL.IDAL dAL;

        public BL()
        {
            dAL = new DAL.DAL();
        }

        public Dictionary<string,string> GetPictureOfTheDay()
        {
            return dAL.GetPictureOfTheDay();
        }

        public string ImageUpload()
        {
           
            return "success";
        }
    }
}
