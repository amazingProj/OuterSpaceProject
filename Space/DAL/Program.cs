using Newtonsoft.Json;
using System;
using System.Collections.Generic;

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
