using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IFireBase
    {
        Task<string> InsertImageToFireBaseAsync(string byteFile);

        Task<List<string>> RetriveAllImagesFromFireBase();
    }
}
