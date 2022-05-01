using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public interface IBL : IFirebase
    {
        Dictionary<string, string> GetPictureOfTheDay();

        List<Dictionary<string, string>> GetOnlyDangerous(string initialDate, string endDate, double radius = 0);

        string GetNormalTodayPicture();

        List<Dictionary<string, string>> GetAllAsteroids(string initialDate, string endDate = null, double radius = 0);

        List<Dictionary<string, string>> GetNotDangerous(string initialDate, string endDate = null, double radius = 0);

        List<Dictionary<string, string>> GetAllImageSearch(string query);

        List<Dictionary<string, string>> RetrieveDataFromSQLServer();
    }


}

