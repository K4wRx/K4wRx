using Microsoft.Kinect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace K4wRx.Extensions
{
    public static class MultiSourceFrameExtension
    {
        public static IObservable<MultiSourceFrameArrivedEventArgs> AsObservable(this MultiSourceFrameReader reader)
        {
            return BaseReaderExtension.AsObservable<MultiSourceFrameArrivedEventArgs>(reader);
        }
    }
}
