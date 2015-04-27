using Microsoft.Kinect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace K4wRx.Extensions
{
    public static class JointSmoothingExtension
    {
        public static IObservable<Joint> FilterByJointSmoothing(this IObservable<Joint> stream)
        {
            // TODO: create it.
            throw new Exception("this module is not defined");
        }

        public static IObservable<Joint> FilterByJointSmoothing(this IObservable<Body> stream, JointType joint)
        {
            // TODO: create it.
            throw new Exception("this module is not defined");
        }

        public static IObservable<Joint[]> FilterByJointSmoothing(this IObservable<Body> stream)
        {
            // TODO: create it.
            throw new Exception("this module is not defined");
        }
    }
}
