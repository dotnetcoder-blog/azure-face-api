using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dnc.Services.FaceDetection
{
    public class BoundingFace
    {
        public string Id { get; set; }
        public int Top { get; set; }
        public int Left { get; set; } 
        public int Width { get; set; }
        public int Height { get; set; } 
        public double NoseTipX { get; set; } 
        public double NoseTipY { get; set; } 
    }
}
