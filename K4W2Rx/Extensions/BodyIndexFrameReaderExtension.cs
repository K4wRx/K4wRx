using Microsoft.Kinect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace K4W2Rx.Extensions
{
    public static class BodyIndexFrameReaderExtension
    {
        public static IObservable<BodyIndexFrameArrivedEventArgs> AsObservable(this BodyIndexFrameReader reader)
        {
            return BaseReaderExtension.AsObservable<BodyIndexFrameArrivedEventArgs>(reader);
        }
    }
}
