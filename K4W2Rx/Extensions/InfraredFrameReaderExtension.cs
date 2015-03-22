using Microsoft.Kinect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace K4W2Rx.Extensions
{
    public static class InfraredFrameReaderExtension
    {
        public static IObservable<InfraredFrameArrivedEventArgs> AsObservable(this InfraredFrameReader reader)
        {
            return BaseReaderExtension.AsObservable<InfraredFrameArrivedEventArgs>(reader);
        }
    }
}
