using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;


namespace BL
{
    public class BL : IBL
    {
        private double MIN_CONFIDENCE = 50;
      
        Dictionary<string, string> keywordsSpace = new Dictionary<string, string>();

        DAL.IDAL dAL;

        public BL()
        {
            dAL = new DAL.DAL();
            keywordsSpace.Add("planet", "keyword");
            keywordsSpace.Add("asteriod", "keyword");
            keywordsSpace.Add("space", "keyword");
            keywordsSpace.Add("spacecraft", "keyword");
            keywordsSpace.Add("star", "keyword");
            keywordsSpace.Add("stars", "keyword");
            keywordsSpace.Add("telescope", "keyword");
            keywordsSpace.Add("cosmic", "keyword");
            keywordsSpace.Add("astrology", "keyword");
            keywordsSpace.Add("universe", "keyword");
            keywordsSpace.Add("astronomy", "keyword");
        }

        public List<Dictionary<string, string>> GetAllAsteroids(string initialDate, string endDate = null)
        {
            if (initialDate == null)
            {
                return null;
            }
            return dAL.GetAllAsteroids(initialDate, endDate);
        }

        public List<Dictionary<string, string>> GetAllImageSearch(string query)
        {
            if (query == null)
            {
                return null;
            }

            return dAL.GetAllImageSearch(query);
        }

        public string GetNormalTodayPicture()
        {
            return dAL.GetNormalTodayPicture();
        }

        public List<Dictionary<string, string>> GetNotDangerous(string initialDate, string endDate = null)
        {
            if (initialDate == null)
            {
                return null;
            }
            return dAL.GetNotDangerous(initialDate, endDate);
        }

        public List<Dictionary<string, string>> GetOnlyDangerous(string initialDate, string endDate = null)
        {
            if (initialDate == null)
            {
                return null;
            }
            List<Dictionary<string, string>> dangerous =  dAL.GetOnlyDangerous(initialDate, endDate);
            return dangerous;
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
    }
}
