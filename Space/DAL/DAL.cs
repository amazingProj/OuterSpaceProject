using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using RestSharp;

namespace DAL
{ 
    public class DAL : IDAL
    {
        IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret= "5vGYqAHx3MEsyBAM7evfKcwaGBAOEsEszA32kdEw", 
            BasePath= "https://csharpfirebase-4e381-default-rtdb.firebaseio.com/"
        };

        IFirebaseClient client;
        
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

            client = new FireSharp.FirebaseClient(config);

            if (client != null)
            {
                Console.WriteLine("Connection Established");
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

        public async Task<string> InsertImageToFireBaseAsync(string convertedImage)
        {
            FirebaseResponse response = await client.GetTaskAsync("Counter/Node");
            Counter_class get = response.ResultAs<Counter_class>();

            FireBaseData fireBaseData = new FireBaseData
            {
                Id = (Convert.ToInt32(get.cnt) + 1).ToString(),

            };
            int size = convertedImage.Length;
            int sizeDividedFive = size / 5;
            int sizeDividedFiveE = sizeDividedFive * 5; 

            var data = new Image_Modal
            {
                ImagePart1 = convertedImage.Substring(0, sizeDividedFive),
                ImagePart2 = convertedImage.Substring(sizeDividedFive + 1, sizeDividedFive * 2),
                ImagePart3 = convertedImage.Substring(sizeDividedFive * 2, sizeDividedFive * 3),
                ImagePart4 = convertedImage.Substring(sizeDividedFive * 3),
            };

            SetResponse responseImage = await client.SetTaskAsync("Images/" + fireBaseData.Id, data);
            Image_Modal result = responseImage.ResultAs<Image_Modal>();

            var obj = new Counter_class
            {
                cnt = fireBaseData.Id
            };

            SetResponse counterResponse = await client.SetTaskAsync("Counter/Node", obj);

            return "success";
        }

        public async Task<List<string>> RetriveAllImagesFromFireBase()
        {
            List<string> result = new List<string>();

            FirebaseResponse response = await client.GetTaskAsync("Counter/Node");
            Counter_class get = response.ResultAs<Counter_class>();

            string temp;

            for (int i = 0; i < Convert.ToInt32(get.cnt); ++i)
            {
                FirebaseResponse responseImage = await client.GetTaskAsync("Images/{i}");
                Image_Modal image = responseImage.ResultAs<Image_Modal>();
                temp = image.ImagePart1 + image.ImagePart2 + image.ImagePart3 + image.ImagePart4;
                result.Add(temp);
            }

            return result;
        }

        async Task<string> IFireBase.InsertImageToFireBaseAsync(string convertedImage)
        {
            var task = await InsertImageToFireBaseAsync(convertedImage);
            return "success";
        }

        //async 
    }
}
