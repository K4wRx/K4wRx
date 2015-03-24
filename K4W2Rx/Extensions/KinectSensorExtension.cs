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

namespace K4W2Rx.Extensions
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
        public static IObservable<VisualGestureBuilderFrameArrivedEventArgs> VisualGestureBuilderFrameAsObservable(this KinectSensor sensor, IEnumerable<Gesture> gestures, out VisualGestureBuilderFrameSource frameSource)
        {
            frameSource = new VisualGestureBuilderFrameSource(sensor, 0);
            frameSource.AddGestures(gestures);
            var reader = frameSource.OpenReader();
            return reader.AsObservable();
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
    }
}
