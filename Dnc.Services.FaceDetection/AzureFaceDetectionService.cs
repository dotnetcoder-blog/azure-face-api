using Dnc.Services.FaceDetection.Clients;
using Dnc.Services.FaceDetection.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dnc.Services.FaceDetection
{
    public class AzureFaceDetectionService : IAzureFaceDetectionService
    {
        private readonly IAzureFaceDetectionClient azureFaceDetectionClient; 
        public AzureFaceDetectionService(IAzureFaceDetectionClient azureFaceDetectionClient)
        {
            this.azureFaceDetectionClient = azureFaceDetectionClient; 
        }
        public async Task<IEnumerable<BoundingFace>> DetectFacesInBinaryImage(byte[] imageData)
        {
            var faces = await azureFaceDetectionClient.DetectFacesInBinaryImage(imageData);

            return faces.Select(face => MapToBoundingFace(face));
        }
        public async Task<IEnumerable<BoundingFace>> DetectFacesWithImageUrl(string imageUrl)
        {
            var faces = await azureFaceDetectionClient.DetectFacesWithImageUrl(imageUrl);

            return faces.Select(face => MapToBoundingFace(face));
        }

        readonly Func<Face, BoundingFace> MapToBoundingFace = face => new BoundingFace
        {
            Id = face.FaceId,
            Top = face.FaceRectangle.Top,
            Left = face.FaceRectangle.Left,
            Width = face.FaceRectangle.Width,
            Height = face.FaceRectangle.Height,
            NoseTipX = face.FaceLandmarks.NoseTip.X,
            NoseTipY = face.FaceLandmarks.NoseTip.Y
        };
    }
}
