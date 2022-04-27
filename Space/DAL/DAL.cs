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
        public static List<Planets> ListPlanets;


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






        public class Planets  
        {
            public string Name { get; set; }
            public string ImagesPath { get; set; }

            public double mass { get; set; }
            public double diameter { get; set; }
            public double density { get; set; }
            public double gravity { get; set; }
            public double rotation_period { get; set; }
            public double distance_from_sun { get; set; }
            public double mean_temperature { get; set; }

            public string Description { get; set; }

        }


        static void initiallist()
        {
            List<Planets> ListPlanets = new List<Planets>();
            ListPlanets.Add(new Planets()
            {
                ImagesPath = "/Icons/jupiter.png",
                Name = "JUPITER",


                mass = 1898, // to string pr le km
                diameter = 142984,
                density = 1326,
                gravity = 23.1,
                rotation_period = 9.9,
                distance_from_sun = 778.6,
                mean_temperature = -110,

                Description = "Mars is the fourth planet from the Sun and the second-smallest planet in the Solar System, being larger than only Mercury. In English, Mars carries the name of the Roman god of war and is often called the .[17][18] The latter refers to the effect of the iron oxide prevalent on Mars's surface, which gives it a striking reddish appearance in the sky.[19] Mars is a terrestrial planet with a thin atmosphere, with surface features such as impact craters, valleys, dunes, and polar ice caps."
            });


            ListPlanets.Add(new Planets() { ImagesPath = "/Icons/earth.png", Name = "EARTH", Description = " While Earth is only the fifth largest planet in the solar system, it is the only world in our solar system with liquid water on the surface. Just slightly larger than nearby Venus, Earth is the biggest of the four planets closest to the Sun, all of which are made of rock and metal" });
            ListPlanets.Add(new Planets() { ImagesPath = "/Icons/mercury.png", Name = "MERCURY", Description = "The smallest planet in our solar system and nearest to the Sun, Mercury is only slightly larger than Earth's Moon.From the surface of Mercury, the Sun would appear more than three times as large as it does when viewed from Earth, and the sunlight would be as much as seven times brighter.Despite its proximity to the Sun, Mercury is not the hottest planet in our solar system – that title belongs to nearby Venus,                thanks to its dense atmosphere.Because of Mercury's elliptical – egg-shaped – orbit, and sluggish rotation, the Sun appears to rise briefly, set, and rise again from some parts of the planet's surface.The same thing happens in reverse at sunset." });
            ListPlanets.Add(new Planets() { ImagesPath = "/Icons/mars.png", Name = "MARS", Description = "Small PLANET AND.......??" });
            ListPlanets.Add(new Planets() { ImagesPath = "/Icons/venus.png", Name = "VENUS", Description = "Small PLANET AND.......??" });
            ListPlanets.Add(new Planets() { ImagesPath = "/Icons/saturn.png", Name = "SATURN", Description = "Small PLANET AND.......??" });
            ListPlanets.Add(new Planets() { ImagesPath = "/Icons/uranus.png", Name = "URANUS", Description = "Small PLANET AND.......??" });
            ListPlanets.Add(new Planets() { ImagesPath = "/Icons/neptune.png", Name = "NEPTUNE", Description = "Small PLANET AND.......??" });

        }

        public IEnumerable<Planets> GetPlanets()
        {
            return from item in ListPlanets
                   select item;
        }
    }
}
