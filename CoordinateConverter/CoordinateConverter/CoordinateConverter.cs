﻿using System;

namespace CoordinateConverter
{
    public class CoordinateConverter
    {
        /// <summary>
        /// pass in origin and unknown point, return its location in 3D space
        /// </summary>
        /// <param name="origin"></param>
        /// <param name="point"></param>
        /// <returns>MeterCoordinate</returns>
        public MeterCoordinate FindMeterCoordinateFromOrigin(GeoCoordinate origin, GeoCoordinate point)
        {
            MeterCoordinate result = new MeterCoordinate();
            double distance = DistanceBetweenGeoPoints(origin, point), bearing = FindBearing(origin, point);
            
            if (bearing == 0)
            {
                result.X = distance;
                return result;
            }
            else if (bearing == 90)
            {
                result.Y = distance;
                return result;
            }
            else if (bearing == 180)
            {
                result.X = distance * -1;
                return result;
            }
            else if(bearing == 270)
            {
                result.Y = distance * -1;
                return result;
            }
            else
            {
                double angleA = 0;
                if (bearing < 90)
                {
                    angleA = bearing;
                }
                else if (bearing > 90 && bearing < 180)
                {
                    angleA = bearing - 90;
                }
                else if (bearing > 180 && bearing < 270)
                {
                    angleA = bearing - 180;
                }
                else if (bearing > 270)
                {
                    angleA = bearing - 270;
                }

                double angleC = 90 - bearing, angleB = 90;
                double sideB = distance;

                double sideA = ((sideB * Math.Sin(angleA)) / Math.Sin(angleB));

                double sideC = ((sideB * Math.Sin(angleC)) / Math.Sin(angleB));

                if (bearing < 90)
                {
                    result.X = sideC;
                    result.Y = sideA;
                    return result;
                }
                else if (bearing > 90 && bearing < 180)
                {
                    result.X = sideC * -1;
                    result.Y = sideA;
                }
                else if (bearing > 180 && bearing < 270)
                {
                    result.X = sideC * -1;
                    result.Y = sideA * -1;
                }
                else if (bearing > 270)
                {
                    result.X = sideC;
                    result.Y = sideA * -1;
                }
            }


            return result;
        }
         
        /// <summary>
        /// finds the distance between the lat long coords
        /// </summary>
        /// <param name="end"></param>
        /// <param name="start"></param>
        /// <returns>distance in meters between the two points, double</returns>
        private double DistanceBetweenGeoPoints(GeoCoordinate point1, GeoCoordinate point2)
        {
            // check for equal points
            if ((point1.Latitude == point2.Latitude) && (point1.Longitude == point2.Longitude))
            {
                return 0;
            }
            else
            {
                double result = 0;

                double lat1Rads = ToRad(point1.Latitude);
                double lat2Rads = ToRad(point2.Latitude);
                double latDeltaRads = ToRad(point2.Latitude - point1.Latitude);
                double lonDeltaRads = ToRad(point2.Longitude - point1.Longitude);

                double a = Math.Sin(latDeltaRads / 2) * Math.Sin(latDeltaRads / 2) +
                           Math.Cos(lat1Rads) * Math.Cos(lat2Rads) *
                           Math.Sin(lonDeltaRads / 2) * Math.Sin(lonDeltaRads / 2);
                double c = 2 * atan2(Math.Sqrt(a), Math.Sqrt(1-a));
                result = c * 6371e3;

                return result;
            }
        }

        /// <summary>
        /// returns the angle of the bearing.
        /// </summary>
        /// <param name="point1"></param>
        /// <param name="point2"></param>
        /// <returns>double angle of bearing</returns>
        private double FindBearing (GeoCoordinate point1, GeoCoordinate point2)
        {
            var dLon = ToRad(point2.Longitude - point1.Longitude);
            var dPhi = Math.Log(
                Math.Tan(ToRad(point2.Latitude) / 2 + Math.PI / 4) / Math.Tan(ToRad(point1.Latitude) / 2 + Math.PI / 4));
            if (Math.Abs(dLon) > Math.PI)
                dLon = dLon > 0 ? -(2 * Math.PI - dLon) : (2 * Math.PI + dLon);
            return ToBearing(Math.Atan2(dLon, dPhi));
        }

        private double atan2(double y, double x)
        {
            if (x < 0)
            {
                return (Math.Atan(y / x) + 3 * Math.PI / 2); // subst 270 for 3*pi/2 if degrees
            }
            else
            {
                return (Math.Atan(y / x) + Math.PI / 2); // subst 90 for pi/2 if degrees
            }
        }

        private static double ToRad(double degrees)
        {
            return degrees * (Math.PI / 180);
        }

        private static double ToDegrees(double radians)
        {
            return radians * 180 / Math.PI;
        }

        private static double ToBearing(double radians)
        {
            // convert radians to degrees (as bearing: 0...360)
            return (ToDegrees(radians) + 360) % 360;
        }

        private static double deg2rad(double deg)
        {
            return (deg * Math.PI / 180.0);
        }

        private static double rad2deg(double rad)
        {
            return (rad / Math.PI * 180.0);
        }

        public static double MeterCoordtoGeoCoord(GeoCoordinate originGeo, MeterCoordinate originMeter, MeterCoordinate end)
        {
            /*
            δ = distance r / Earth radius(both in the same units)

            lat_P2 = asin(sin lat_O ⋅ cos δ + cos lat_O ⋅ sin δ ⋅ cos θ)
            lon_P2 = lon_O + atan((sin θ ⋅ sin δ ⋅ cos lat_O) / (cos δ − sin lat_O ⋅ sin lat_P2))
            */

            return 0;
        }
    }

    public class GeoCoordinate
    {
        private double latitude;
        private double longitude;

        public GeoCoordinate(double v1, double v2)
        {
            this.latitude = v1;
            this.longitude = v2;
        }

        public double Latitude
        {
            get
            {
                return this.latitude;
            }
            set
            {
                this.latitude = value;
            }
        }

        public double Longitude
        {
            get
            {
                return this.longitude;
            }

            set
            {
                this.longitude = value;
            }
        }
    }

    public class MeterCoordinate
    {
        private double x;
        private double y;

        public MeterCoordinate()
        {
            this.x = 0;
            this.y = 0;
        }

        public double X
        {
            get
            {
                return this.x;
            }

            set
            {
                this.x = value;
            }
        }

        public double Y
        {
            get
            {
                return this.y;
            }
            set
            {
                this.y = value;
            }
        }
    }
}