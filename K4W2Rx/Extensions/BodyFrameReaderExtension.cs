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

        public static IObservable<IEnumerable<Body>> BodyAsObservable(this BodyFrameReader reader)
        {
            return BaseReaderExtension.AsObservable<BodyFrameArrivedEventArgs>(reader).Select(e =>
            {
                List<Body> bodies = new List<Body>();
                using (BodyFrame bodyFrame = e.FrameReference.AcquireFrame())
                {
                    bodyFrame.GetAndRefreshBodyData(bodies);
                    return bodies;
                }
            });
        }

        public static IObservable<IEnumerable<Body>> TrackedBodyAsObservable(this BodyFrameReader reader)
        {
            return reader.BodyAsObservable().Select(e => e.Where(b => b.IsTracked).Select(b => b));
        }
    }
}
