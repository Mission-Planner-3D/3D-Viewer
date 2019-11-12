using System;

namespace CoordinateConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            CoordinateConverter myConverter = new CoordinateConverter();
            GeoCoordinate myApartment = new GeoCoordinate(46.732518, -117.173337);
            GeoCoordinate sloan = new GeoCoordinate(46.730576, -117.168540);
            MeterCoordinate result = new MeterCoordinate();

            result = myConverter.FindMeterCoordinateFromOrigin(myApartment, sloan);
            Console.WriteLine("Result = (" + result.X + "," + result.Y + ")");
        }
    }
}
