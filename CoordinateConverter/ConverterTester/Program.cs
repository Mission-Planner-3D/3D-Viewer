using System;

namespace CoordinateConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            CoordinateConverter myConverter = new CoordinateConverter();
            GeoCoordinate myApartment = new GeoCoordinate(46.7302976970894, -117.168948054314);
            GeoCoordinate sloan = new GeoCoordinate(46.72937850, -117.16925380);
            MeterCoordinate sloanCoordinate = new MeterCoordinate();
            MeterCoordinate myApartmentCoordinate = new MeterCoordinate(0,0);

            sloanCoordinate = myConverter.FindMeterCoordinateFromOrigin(myApartment, sloan);

            Console.WriteLine("!!!!!!!!!!Lat/Lon to Cartesian Coordinate Converter!!!!!!!!!!");
            Console.WriteLine("Result = (" + sloanCoordinate.X + "," + sloanCoordinate.Y + ")");

            sloan = myConverter.MeterCoordtoGeoCoord(myApartment, myApartmentCoordinate, sloanCoordinate);

            Console.WriteLine("!!!!!!!!!!OTHER WAY!!!!!!!!!!");
            Console.WriteLine("Result = (" + sloan.Latitude + "," + sloan.Longitude + ")");

            sloanCoordinate = myConverter.FindMeterCoordinateFromOrigin(myApartment, sloan);

            Console.WriteLine("!!!!!!!!!!BACK AGAIN!!!!!!!!!!");
            Console.WriteLine("Result = (" + sloanCoordinate.X + "," + sloanCoordinate.Y + ")");
        }
    }
}
