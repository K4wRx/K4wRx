using Microsoft.Kinect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reactive.Linq;

namespace K4wRx.Extensions
{
    public static class JointSmoothingExtension
    {
        public static IObservable<Joint> FilterByJointSmoothing(this IObservable<Joint> stream)
        {
            return stream.Buffer(5, 1).Select(joints => SmoothJoint(joints));
        }

        public static IObservable<Joint> FilterByJointSmoothing(this IObservable<Body> stream, JointType jointType)
        {
            return FilterByJointSmoothing(stream.Select(b => b.Joints[jointType]));
        }

        public static IObservable<Dictionary<JointType, Joint>> FilterByJointSmoothing(this IObservable<Body> stream)
        {
            return stream.Buffer(5,1).Select(bodies => SmoothJoint(bodies));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bodies">Latest 5 body data to detect smoothing. each bodies should align by time *ascending order*</param>
        /// <returns></returns>
        private static Dictionary<JointType, Joint> SmoothJoint(IList<Body> bodies)
        {
            throw new Exception("this module is not defined");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="joints">Latest 5 joint data to detect smoothing. each joints should align by time *ascending order*</param>
        /// <returns></returns>
        private static Joint SmoothJoint(IList<Joint> joints)
        {
            throw new Exception("this module is not defined");
        }
    }
}
