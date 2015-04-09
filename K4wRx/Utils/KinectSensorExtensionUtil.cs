using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;


namespace K4wRx.Utils
{
    internal static class KinectSensorExtensionUtil
    {
        /// <summary>
        /// Zip up streams into one stream
        /// </summary>
        /// <typeparam name="T">Type of stream output</typeparam>
        /// <param name="streams">streams to zip</param>
        /// <returns>zipped stream</returns>
        public static IObservable<IEnumerable<T>> ZipStreams<T>(IEnumerable<IObservable<T>> streams)
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
                        return new List<T> { s1, s2, s3 };
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
