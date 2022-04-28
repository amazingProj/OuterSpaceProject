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

        List<Dictionary<string, string>> GetOnlyDangerous(string initialDate, string endDate);

        string GetNormalTodayPicture();
    }
}
