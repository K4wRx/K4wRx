using Microsoft.Kinect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace K4W2Rx.Extensions
{
    public static class LongExposureInfraredFrameExtension
    {
        public static IObservable<LongExposureInfraredFrameArrivedEventArgs> AsObservable(this LongExposureInfraredFrameReader reader)
        {
            return BaseReaderExtension.AsObservable<LongExposureInfraredFrameArrivedEventArgs>(reader);
        }
    }
}
