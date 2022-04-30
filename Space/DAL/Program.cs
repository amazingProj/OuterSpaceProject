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
            dAL.RetrieveDataFromSQLServer();
            int x = 0;
        }
    }
}
