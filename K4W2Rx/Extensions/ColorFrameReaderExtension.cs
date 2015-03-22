using Microsoft.Kinect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;

namespace K4W2Rx.Extensions
{
    public static class ColorFrameReaderExtension
    {
        public static IObservable<ColorFrameArrivedEventArgs> AsObservable(this ColorFrameReader reader)
        {
            return BaseReaderExtension.AsObservable<ColorFrameArrivedEventArgs>(reader);
        }
    }
}
