using Microsoft.Kinect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;

namespace K4W2Rx.Extensions
{
    public static class BodyFrameReaderExtension
    {
        public static IObservable<BodyFrameArrivedEventArgs> AsObservable(this BodyFrameReader reader)
        {
            return BaseReaderExtension.AsObservable<BodyFrameArrivedEventArgs>(reader);
        }
    }
}
