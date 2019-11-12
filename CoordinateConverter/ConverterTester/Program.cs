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
            MeterCoordinate sloanCoordinate = new MeterCoordinate();
            MeterCoordinate myApartmentCoordinate = new MeterCoordinate();

            sloanCoordinate = myConverter.FindMeterCoordinateFromOrigin(myApartment, sloan);

            Console.WriteLine("!!!!!!!!!!Lat/Lon to Cartesian Coordinate Converter!!!!!!!!!!");
            Console.WriteLine("Origin: 46.732518, -117.173337, (0,0)");
            Console.WriteLine("Mystery Point: 46.730576, -117.168540, (?,?)");
            Console.WriteLine("Result = (" + sloanCoordinate.X + "," + sloanCoordinate.Y + ")");
        }
    }
}
