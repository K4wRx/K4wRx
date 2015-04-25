using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;

namespace K4wRx.Extensions
{
    public static class BaseReaderExtension
    {
        public static IObservable<T> AsObservable<T>(object target)
        {
            return Observable.FromEventPattern<T>(target, "FrameArrived").Select(e => e.EventArgs);
        }
    }
}
