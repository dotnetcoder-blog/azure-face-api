using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dnc.Services.FaceDetection.Models
{
    public class Face
    {
        public string FaceId { get; set; }
        public FaceRectangle FaceRectangle { get; set; }
        public FaceLandmarks FaceLandmarks { get; set; }
    }

    public class FaceLandmarks
    {
        public NoseTip NoseTip { get; set; }
    }

    public class NoseTip
    {
        public double X { get; set; }
        public double Y { get; set; }

    }
}
