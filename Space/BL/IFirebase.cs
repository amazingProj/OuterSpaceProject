using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public interface IFirebase
    {
        Task<string> ImageUpload(string imageConvered, string path);

        Task<List<string>> RetriveAllImagesFromFireBase();
    }
}
