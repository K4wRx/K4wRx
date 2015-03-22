using Microsoft.Kinect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace K4W2Rx.Extensions
{
    public static class AudioBeamFrameReaderExtension
    {
        public static IObservable<AudioBeamFrameArrivedEventArgs> AsObservable(this AudioBeamFrameReader reader)
        {
            return BaseReaderExtension.AsObservable<AudioBeamFrameArrivedEventArgs>(reader);
        }
    }
}
