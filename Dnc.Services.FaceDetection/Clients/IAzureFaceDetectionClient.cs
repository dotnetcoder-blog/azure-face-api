using Dnc.Services.FaceDetection.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dnc.Services.FaceDetection.Clients
{
    public interface IAzureFaceDetectionClient
    {
        Task<IEnumerable<Face>> DetectFacesInBinaryImage(byte[] imageBytes);
        Task<IEnumerable<Face>> DetectFacesWithImageUrl(string imageUrl);
    }
}
