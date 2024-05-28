using Dnc.Services.FaceDetection.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace Dnc.Services.FaceDetection.Clients
{
    public class AzureFaceDetectionClient : IAzureFaceDetectionClient
    {
        private readonly HttpClient httpClient;
        public AzureFaceDetectionClient(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        public async Task<IEnumerable<Face>> DetectFacesInBinaryImage(byte[] imageBytes)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, "face/v1.0/detect?returnFaceId=true&returnFaceLandmarks=true&detectionModel=detection_01");

            using var content = new ByteArrayContent(imageBytes);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
            request.Content = content;

            var response = await httpClient.SendAsync(request);
            var responseBody = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<IEnumerable<Face>>(responseBody);
            }
            else
            {
                throw new Exception(responseBody);
            }
        }
        public async Task<IEnumerable<Face>> DetectFacesWithImageUrl(string imageUrl)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"face/v1.0/detect?url={imageUrl}");

            var response = await httpClient.SendAsync(request);

            var responseBody = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<IEnumerable<Face>>(responseBody, new JsonSerializerSettings { Culture = CultureInfo.InvariantCulture });
            }
            else
            {
                throw new Exception(responseBody);
            }
        }
    }
}
