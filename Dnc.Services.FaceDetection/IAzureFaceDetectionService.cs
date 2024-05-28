using Dnc.Services.FaceDetection.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dnc.Services.FaceDetection
{
    public interface IAzureFaceDetectionService
    {
        Task<IEnumerable<BoundingFace>> DetectFacesInBinaryImage(byte[] imageData);
        Task<IEnumerable<BoundingFace>> DetectFacesWithImageUrl(string imageUrl);
    }
}
