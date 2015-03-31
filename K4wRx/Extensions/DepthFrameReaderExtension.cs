using Microsoft.Kinect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace K4wRx.Extensions
{
    public static class DepthFrameReaderExtension
    {
        public static IObservable<DepthFrameArrivedEventArgs> AsObservable(this DepthFrameReader reader)
        {
            return BaseReaderExtension.AsObservable<DepthFrameArrivedEventArgs>(reader);
        }
    }
}
