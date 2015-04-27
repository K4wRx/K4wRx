using Microsoft.Kinect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reactive;
using System.Reactive.Linq;

namespace K4wRx.Extensions
{
    public static class BaseFilterExtension
    {
        public static IObservable<T2> Filter<T1, T2>(this IObservable<T1> stream, Func<IObservable<T1>, IObservable<T2>> jitter)
        {
            return jitter(stream);
        }
    }
}
