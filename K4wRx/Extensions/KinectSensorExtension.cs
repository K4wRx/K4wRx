using Microsoft.Kinect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reactive.Linq;
using System.Reactive.Disposables;
using System.ComponentModel;
using Microsoft.Kinect.VisualGestureBuilder;

namespace K4wRx.Extensions
{
    public static class KinectSensorExtension
    {
        private static CompositeDisposable disposables = new CompositeDisposable();
        /// <summary>
        /// Create KinectSensor property changed stream from KinectSensor
        /// </summary>
        /// <param name="sensor">source of stream</param>
        /// <returns>Observable KinectSensor property changes stream</returns>
        public static IObservable<PropertyChangedEventArgs> AsObservable(this KinectSensor sensor)
        {
            return Observable.FromEventPattern<PropertyChangedEventHandler, PropertyChangedEventArgs>(
                h => sensor.PropertyChanged += h,
                h => sensor.PropertyChanged -= h
                ).Select(e => e.EventArgs);
        }
        /// <summary>
        /// Create KinectSensor availability stream from KinectSensor.
        /// </summary>
        /// <param name="sensor">source of stream</param>
        /// <returns>Observable Kinect availability stream</returns>
        public static IObservable<IsAvailableChangedEventArgs> AvailabilityAsObservable(this KinectSensor sensor)
        {
            return Observable.FromEventPattern<IsAvailableChangedEventArgs>(
                h => sensor.IsAvailableChanged += h,
                h => sensor.IsAvailableChanged -= h
                ).Select(e => e.EventArgs);
        }
        /// <summary>
        /// Create AudioSouce stream from KinectSensor
        /// </summary>
        /// <param name="sensor">source of stream</param>
        /// <returns>Observable AudioSource stream</returns>
        public static IObservable<AudioBeamFrameArrivedEventArgs> AudioBeamFrameAsObservable(this KinectSensor sensor)
        {
            var reader = sensor.AudioSource.OpenReader();
            disposables.Add(reader);
            return reader.AsObservable();
        }
        /// <summary>
        /// Create Body stream from KinectSensor
        /// </summary>
        /// <param name="sensor">souce of stream</param>
        /// <returns>Observable Body frame stream</returns>
        public static IObservable<BodyFrameArrivedEventArgs> BodyFrameAsObservable(this KinectSensor sensor)
        {
            var reader = sensor.BodyFrameSource.OpenReader();
            disposables.Add(reader);
            return reader.AsObservable();
        }
        /// <summary>
        /// Create BodyIndex stream from KinectSensor
        /// </summary>
        /// <param name="sensor">souce of stream</param>
        /// <returns>Observable BodyIndex frame stream</returns>
        public static IObservable<BodyIndexFrameArrivedEventArgs> BodyIndexFrameAsObservable(this KinectSensor sensor)
        {
            var reader = sensor.BodyIndexFrameSource.OpenReader();
            disposables.Add(reader);
            return reader.AsObservable();
        }
        /// <summary>
        /// Create ColorFrame stream from KinectSensor
        /// </summary>
        /// <param name="sensor">souce of stream</param>
        /// <returns>Observable Color frame stream</returns>
        public static IObservable<ColorFrameArrivedEventArgs> ColorFrameAsObservable(this KinectSensor sensor)
        {
            var reader = sensor.ColorFrameSource.OpenReader();
            disposables.Add(reader);
            return reader.AsObservable();
        }
        /// <summary>
        /// Create Depth stream from KinectSensor
        /// </summary>
        /// <param name="sensor">souce of stream</param>
        /// <returns>Observable Depth frame stream</returns>
        public static IObservable<DepthFrameArrivedEventArgs> DepthFrameAsObservable(this KinectSensor sensor)
        {
            var reader = sensor.DepthFrameSource.OpenReader();
            disposables.Add(reader);
            return reader.AsObservable();
        }
        /// <summary>
        /// Create Infrared stream from KinectSensor
        /// </summary>
        /// <param name="sensor">souce of stream</param>
        /// <returns>Observable Infrared frame stream</returns>
        public static IObservable<InfraredFrameArrivedEventArgs> InfraredFrameAsObservable(this KinectSensor sensor)
        {
            var reader = sensor.InfraredFrameSource.OpenReader();
            disposables.Add(reader);
            return reader.AsObservable();
        }
        /// <summary>
        /// Create LongExposureInfrared stream from KinectSensor
        /// </summary>
        /// <param name="sensor">souce of stream</param>
        /// <returns>Observable Long exposure infrared frame stream</returns>
        public static IObservable<LongExposureInfraredFrameArrivedEventArgs> LongExposureInfraredFrameAsObservable(this KinectSensor sensor)
        {
            var reader = sensor.LongExposureInfraredFrameSource.OpenReader();
            disposables.Add(reader);
            return reader.AsObservable();
        }
        /// <summary>
        /// Create MultiSource stream from KinectSensor
        /// </summary>
        /// <param name="sensor">souce of stream</param>
        /// <param name="frameSouceTypes">frame types to observe</param>
        /// <returns>Observable Multi source frame stream</returns>
        public static IObservable<MultiSourceFrameArrivedEventArgs> MultiSourceFrameAsObservable(this KinectSensor sensor, FrameSourceTypes frameSouceTypes)
        {
            var reader = sensor.OpenMultiSourceFrameReader(frameSouceTypes);
            disposables.Add(reader);
            return reader.AsObservable();
        }
        /// <summary>
        /// Create VisualGestureBuilder stream from KinectSensor
        /// </summary>
        /// <param name="sensor">source of stream</param>
        /// <param name="gestures">gestures to detect</param>
        /// <param name="frameSource">out frame source instance to set tracking id</param>
        /// <returns>Observable VisualGestureBuidler frame stream</returns>
        public static IObservable<VisualGestureBuilderFrameArrivedEventArgs> VisualGestureBuilderFrameAsObservable(this KinectSensor sensor, IEnumerable<Gesture> gestures)
        {
            var frameSource = new VisualGestureBuilderFrameSource(sensor, 0);
            frameSource.AddGestures(gestures);
            var reader = frameSource.OpenReader();
            disposables.Add(reader);
            return reader.AsObservable();
        }
        public static IObservable<IEnumerable<Body>> BodyAsObservable(this KinectSensor sensor)
        {
            var reader = sensor.BodyFrameSource.OpenReader();
            disposables.Add(reader);
            return reader.BodyAsObservable();
        }
        public static IObservable<IEnumerable<Body>> TrackedBodyAsObservable(this KinectSensor sensor)
        {
            var reader = sensor.BodyFrameSource.OpenReader();
            disposables.Add(reader);
            return reader.TrackedBodyAsObservable();
        }
        /// <summary>
        /// Create VisualGestureBuilder's DiscreteGestureResult stream for tracked bodies.
        /// </summary>
        /// <param name="sensor">source of stream</param>
        /// <param name="databasePath">path to database</param>
        /// <returns>Observable DiscreteGestureResult frame stream for tracked bodies.</returns>
        public static IObservable<IEnumerable<IDictionary<Gesture, DiscreteGestureResult>>> TrackedBodyDiscreteGestureResultsAsObservable(this KinectSensor sensor, string databasePath)
        {
            var frameSouces = Enumerable.Range(1, sensor.BodyFrameSource.BodyCount).Select(_ =>
            {
                var f = new VisualGestureBuilderFrameSource(sensor, 0);
                using (VisualGestureBuilderDatabase db = new VisualGestureBuilderDatabase(databasePath))
                {
                    f.AddGestures(db.AvailableGestures.Where(g => g.GestureType == GestureType.Discrete));
                }
                return f;
            });

            var frameStreams = frameSouces.Select(f => f.OpenReader()).Select(r =>
                {
                    r.IsPaused = false;
                    return BaseReaderExtension.AsObservable<VisualGestureBuilderFrameArrivedEventArgs>(r)
                        .Select(e => e.FrameReference.AcquireFrame())
                        .Where(frame => frame != null)
                        .Select(frame => frame);
                });

            // maximum number of synchronized vgb frame event args will flow into this stream
            var zippedStreams = ZipStreams(frameStreams);
            // tracking ids that are tracked now will flow into this stream
            var trackingIdStream = sensor.BodyFrameSource.OpenReader().TrackedBodyAsObservable().Select(bodies => bodies.Select(b => b.TrackingId));

            return zippedStreams.Zip(trackingIdStream, (frames, ids) =>
            {
                var i = ids.GetEnumerator();
                foreach (var f in frames.Where(f => f.TrackingId == 0 || !f.IsTrackingIdValid))
                {
                    if (i.MoveNext())
                    {
                        f.VisualGestureBuilderFrameSource.TrackingId = i.Current;
                    }
                }

                return frames.Select(frame =>
                {
                    if (frame.DiscreteGestureResults != null)
                    {
                        Dictionary<Gesture, DiscreteGestureResult> dic = frame
                            .DiscreteGestureResults.ToDictionary(kv => kv.Key, kv => kv.Value);
                        
                        frame.Dispose();
                        return dic;
                    }
                    else
                    {
                        return new Dictionary<Gesture, DiscreteGestureResult>();
                    }
                }).ToList();
            });
        }
        /// <summary>
        /// Dispose all readers which are listened by KinectSensorExtension.
        /// Once you call this method, you *CANNOT* open any reader with KinectSensorExtension
        /// </summary>
        /// <param name="sensor">source of readers</param>
        public static void DisposeLiteningReaders(this KinectSensor sensor)
        {
            disposables.Dispose();
        }
        /// <summary>
        /// Dispose and clear all readers which are listened by KinectSensorExtension.
        /// You *CAN* open other readers with KinectSensorExtension after you call it.
        /// </summary>
        /// <param name="sensor">source of readers</param>
        public static void ClearListeningReaders(this KinectSensor sensor)
        {
            disposables.Clear();
        }

        private static IObservable<IEnumerable<T>> ZipStreams<T>(IEnumerable<IObservable<T>> streams)
        {
            var s = streams.ToList();
            switch (s.Count)
            {
                case 2:
                    return s[0].Zip(s[1], (s1, s2) =>
                    {
                        return new List<T> { s1, s2 };
                    });
                case 3:
                    return s[0].Zip(s[1], s[2], (s1, s2, s3) =>
                    {
                        return new List<T> { s1, s2, s3};
                    });
                case 4:
                    return s[0].Zip(s[1], s[2], s[3], (s1, s2, s3, s4) =>
                    {
                        return new List<T> { s1, s2, s3, s4 };
                    });
                case 5:
                    return s[0].Zip(s[1], s[2], s[3], s[4], (s1, s2, s3, s4, s5) =>
                    {
                        return new List<T> { s1, s2, s3, s4, s5 };
                    });
                case 6:
                    return s[0].Zip(s[1], s[2], s[3], s[4], s[5], (s1, s2, s3, s4, s5, s6) =>
                    {
                        return new List<T> { s1, s2, s3, s4, s5, s6 };
                    });
                case 7:
                    return s[0].Zip(s[1], s[2], s[3], s[4], s[5], s[6], (s1, s2, s3, s4, s5, s6, s7) =>
                    {
                        return new List<T> { s1, s2, s3, s4, s5, s6, s7 };
                    });
                case 8:
                    return s[0].Zip(s[1], s[2], s[3], s[4], s[5], s[6], s[7], (s1, s2, s3, s4, s5, s6, s7, s8) =>
                    {
                        return new List<T> { s1, s2, s3, s4, s5, s6, s7, s8 };
                    });
                case 9:
                    return s[0].Zip(s[1], s[2], s[3], s[4], s[5], s[6], s[7], s[8], (s1, s2, s3, s4, s5, s6, s7, s8, s9) =>
                    {
                        return new List<T> { s1, s2, s3, s4, s5, s6, s7, s8, s9 };
                    });
                case 10:
                    return s[0].Zip(s[1], s[2], s[3], s[4], s[5], s[6], s[7], s[8], s[9], (s1, s2, s3, s4, s5, s6, s7, s8, s9, s10) =>
                    {
                        return new List<T> { s1, s2, s3, s4, s5, s6, s7, s8, s9, s10 };
                    });
                case 11:
                    return s[0].Zip(s[1], s[2], s[3], s[4], s[5], s[6], s[7], s[8], s[9], s[10], (s1, s2, s3, s4, s5, s6, s7, s8, s9, s10, s11) =>
                    {
                        return new List<T> { s1, s2, s3, s4, s5, s6, s7, s8, s9, s10, s11 };
                    });
                case 12:
                    return s[0].Zip(s[1], s[2], s[3], s[4], s[5], s[6], s[7], s[8], s[9], s[10], s[11], (s1, s2, s3, s4, s5, s6, s7, s8, s9, s10, s11, s12) =>
                    {
                        return new List<T> { s1, s2, s3, s4, s5, s6, s7, s8, s9, s10, s11, s12 };
                    });
                case 13:
                    return s[0].Zip(s[1], s[2], s[3], s[4], s[5], s[6], s[7], s[8], s[9], s[10], s[11], s[12], (s1, s2, s3, s4, s5, s6, s7, s8, s9, s10, s11, s12, s13) =>
                    {
                        return new List<T> { s1, s2, s3, s4, s5, s6, s7, s8, s9, s10, s11, s12, s13 };
                    });
                case 14:
                    return s[0].Zip(s[1], s[2], s[3], s[4], s[5], s[6], s[7], s[8], s[9], s[10], s[11], s[12], s[13], (s1, s2, s3, s4, s5, s6, s7, s8, s9, s10, s11, s12, s13, s14) =>
                    {
                        return new List<T> { s1, s2, s3, s4, s5, s6, s7, s8, s9, s10, s11, s12, s13, s14 };
                    });
                case 15:
                    return s[0].Zip(s[1], s[2], s[3], s[4], s[5], s[6], s[7], s[8], s[9], s[10], s[11], s[12], s[13], s[14], (s1, s2, s3, s4, s5, s6, s7, s8, s9, s10, s11, s12, s13, s14, s15) =>
                    {
                        return new List<T> { s1, s2, s3, s4, s5, s6, s7, s8, s9, s10, s11, s12, s13, s14, s15 };
                    });
                case 16:
                    return s[0].Zip(s[1], s[2], s[3], s[4], s[5], s[6], s[7], s[8], s[9], s[10], s[11], s[12], s[13], s[14], s[15], (s1, s2, s3, s4, s5, s6, s7, s8, s9, s10, s11, s12, s13, s14, s15, s16) =>
                    {
                        return new List<T> { s1, s2, s3, s4, s5, s6, s7, s8, s9, s10, s11, s12, s13, s14, s15, s16 };
                    });
                default:
                    throw new ArgumentException("Length of argument should be between 2 to 16");
            }
        }
    }
}
