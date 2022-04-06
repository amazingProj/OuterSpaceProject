using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    class Program
    {
        static void Main(string[] args)
        {
            DAL dAL = new DAL();
            Dictionary<string,string> dic = dAL.GetPictureOfTheDay();
            int x = 0;
        }
    }
}
