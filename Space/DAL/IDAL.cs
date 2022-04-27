using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IDAL : IMediaStream, IFireBase
    {
        Task<List<Dictionary<string, string>>> GetOnlyDangerous(string initialDate, string endDate);
    }
}
