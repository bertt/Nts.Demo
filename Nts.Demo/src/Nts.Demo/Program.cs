using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nts.Demo
{
    public class Program
    {
        public void Main(string[] args)
        {
            Console.WriteLine("NTS demo code");
            Console.WriteLine ("ReadWKT: " + Nts.ReadWktLine().AsText());
            Console.WriteLine("Get a point: " + Nts.GetAPoint().AsText());
            Console.WriteLine("Get a polygon: " + Nts.GetAPolygon().AsText());
            Console.WriteLine("Intersection of two lines: " + Nts.GetInterSectionOfTwoLines().AsText());
            Console.WriteLine("Buffer of line: " + Nts.GetBuffer().AsText());
            Console.WriteLine("GeoJSON of polygon: " + Nts.GetPolygonAsGeoJSON());
            Console.WriteLine("Get polygon from 2 lines: " + Nts.CreatePolygonFromLines());

            Console.ReadLine();
        }
    }
}
