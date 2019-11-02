using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NeedleBuddy.API
{
    public static class HaversineHelper
    {
        private const double EarthRadiusAtRegina = 6366.098;
        private const double RadiansFactor = Math.PI / 180.0;
        public static double HaversineDistance(double sourceLatitude, double sourceLongitude, double destLatitude, double destLongitude)
        {
            var deltaLatitude = RadiansFactor * (destLatitude - sourceLatitude);
            var deltaLongitude = RadiansFactor * (destLongitude - sourceLongitude);
            sourceLatitude = RadiansFactor * (sourceLatitude);
            destLatitude = RadiansFactor * (destLatitude);
            var inverseHaversine = Math.Sin(deltaLatitude / 2) * Math.Sin(deltaLatitude / 2) + Math.Sin(deltaLongitude / 2) * Math.Sin(deltaLongitude / 2) * Math.Cos(sourceLatitude) * Math.Cos(destLatitude);
            return EarthRadiusAtRegina * 2 * Math.Asin(Math.Sqrt(inverseHaversine));
        }
    }
}
