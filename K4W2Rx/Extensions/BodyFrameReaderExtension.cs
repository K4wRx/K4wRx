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
            return BaseReaderExtension.AsObservable<BodyFrameArrivedEventArgs>(reader)
                .Select(frame => frame.FrameReference.AcquireFrame())
                .Where(frame => frame != null)
                .Select(frame =>
                {
                    Body[] bodies = new Body[frame.BodyCount];
                    frame.GetAndRefreshBodyData(bodies);
                    frame.Dispose();
                    return bodies;
                });
        }

        public static IObservable<IEnumerable<Body>> TrackedBodyAsObservable(this BodyFrameReader reader)
        {
            return reader.BodyAsObservable().Select(bodies => bodies.Where(body => body.IsTracked).Select(b => b));
        }
    }
}
