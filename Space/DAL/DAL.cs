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
    public class DAL : IDAL
    {
        NasaPictureOfTheDay nasaPictureOfTheDay;
        public DAL()
        {
            var url = "https://api.nasa.gov/planetary/apod?api_key=WxcAFMM3GBRPz1UDQaQ3y02hHik5kWSJByLGk493";

            var httpRequest = (HttpWebRequest)WebRequest.Create(url);
            var httpResponse = (HttpWebResponse)httpRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
                // Console.WriteLine(result);
                nasaPictureOfTheDay = JsonConvert.DeserializeObject<NasaPictureOfTheDay>(result);
                //Console.WriteLine(nasaPictureOfTheDay.HDPicUrl);
            }
        }

        public Dictionary<string, string> GetPictureOfTheDay()
        {
            Dictionary<string, string> result = new Dictionary<string, string>();

            result.Add("Date", nasaPictureOfTheDay.Date);
            result.Add("Explanation", nasaPictureOfTheDay.Explanation);
            result.Add("HDPicUrl", nasaPictureOfTheDay.HDPicUrl);
            result.Add("PicTitle", nasaPictureOfTheDay.PicTitle);
           
            return result;   
        }
    }
}
