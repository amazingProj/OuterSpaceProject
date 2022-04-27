using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;


namespace BL
{
    public class BL : IBL
    {
        private double MIN_CONFIDENCE = 65;
        private double EPSILON = 0.1;

        Dictionary<string, string> keywordsSpace = new Dictionary<string, string>();

        DAL.IDAL dAL;
        //IEnumerable<Planets> GetPlanets();
        /*public IEnumerable<Planets> GetPlanets()
        {
            return (from item in dAL.GetPlanets() ////////////////////    SELECT CLONING ?
                    select item;
        }*/

        RestClient client;
        public BL()
        {
            dAL = new DAL.DAL();
            keywordsSpace.Add("planet", "keyword");
            keywordsSpace.Add("asteriod", "keyword");
            keywordsSpace.Add("space", "keyword");
            keywordsSpace.Add("spacecraft", "keyword");
            keywordsSpace.Add("star", "keyword");
        }

        public Dictionary<string,string> GetPictureOfTheDay()
        {
            return dAL.GetPictureOfTheDay();
        }


        public async Task<string> ImageUpload(string imageConverted, string path)
        {
            string apiKey = "acc_dca1d0642913a5a";
            string apiSecret = "e4fdaafc2fd0d0bb2854b5c320567784";
            string image = path;

            string basicAuthValue = System.Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(String.Format("{0}:{1}", apiKey, apiSecret)));

            var client = new RestClient("https://api.imagga.com/v2/tags");
            client.Timeout = -1;

            var request = new RestRequest(Method.POST);
            request.AddHeader("Authorization", String.Format("Basic {0}", basicAuthValue));
            request.AddFile("image", image);

            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);
            Console.ReadLine();

            ImaggaClasset imaggaClasset = new ImaggaClasset();
            imaggaClasset = JsonConvert.DeserializeObject<ImaggaClasset>(response.Content);
            Hypotheses hypotheses = new Hypotheses();
            hypotheses = JsonConvert.DeserializeObject<Hypotheses>(imaggaClasset.HypthesesList.ToString());

            Cofidence confidence = new Cofidence();
            foreach (var hypo in hypotheses.Tags)
            {
                confidence = JsonConvert.DeserializeObject<Cofidence>(hypo.ToString());
                Tag tag = new Tag();
                tag = JsonConvert.DeserializeObject<Tag>(confidence.tag.ToString());
                if (confidence.Confiedence < MIN_CONFIDENCE)
                {
                    return "is not a space related picture";
                }
                bool keyExists = keywordsSpace.ContainsKey(tag.ensure);
                if (keyExists)
                {
                    break;
                }
            }

            string messageResponseDal = await dAL.InsertImageToFireBaseAsync(imageConverted);

            return messageResponseDal;
        }

        public Task<List<string>> RetriveAllImagesFromFireBase()
        {
            return dAL.RetriveAllImagesFromFireBase();
        }


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
    }
}
