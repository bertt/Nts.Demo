using GeoAPI.Geometries;
using NetTopologySuite.Geometries;
using NetTopologySuite.IO;

namespace Nts.Demo
{
    public class Nts
    {

        public static ILineString ReadWktLine()
        {
            var geometry = new WKTReader().Read("LINESTRING (0 0, 10 10, 20 20)");
            return (ILineString)geometry;
        }

        public static IPoint GetInterSectionOfTwoLines()
        {
            var fl = GetALine();
            var sl = GetASecondLine();
            var geom = fl.Intersection(sl);
            return (IPoint)geom;
        }

        public static IPolygon GetAPolygon()
        {
            var poly = new GeometryFactory().CreatePolygon(new Coordinate[]{ new Coordinate(0, 0),new Coordinate(0, 10),new Coordinate(10, 10), new Coordinate(0, 0) });
            var isValid = poly.IsValid;
            return poly;
        }

        public static ILineString GetALine()
        {
            var p1 = new Coordinate(0, 0);
            var p2 = new Coordinate(10, 10);
            var coordinatesp = new[] { p1, p2 };
            var line1 = new GeometryFactory().CreateLineString(coordinatesp);
            return line1;
        }

        public static ILineString GetASecondLine()
        {
            var q1 = new Coordinate(0, 10);
            var q2 = new Coordinate(10, 0);
            var coordinatesq = new[] { q1, q2 };
            var line2 = new GeometryFactory().CreateLineString(coordinatesq);
            return line2;
        }

        public static IPoint GetAPoint()
        {
            var c1 = new Coordinate(0, 0);
            var point = new GeometryFactory().CreatePoint(c1);
            return point;
        }

        public static IPolygon GetBuffer()
        {
            var line = GetALine();
            var buffer = (IPolygon)line.Buffer(1);
            return buffer;
        }

        public static string GetPolygonAsGeoJSON()
        {
            var poly = GetAPolygon();
            var jsonSerializer = new GeoJsonSerializer();
            var sw = new System.IO.StringWriter();
            jsonSerializer.Serialize(sw, poly);
            return sw.ToString();
        }

        public static string CreatePolygonFromLines()
        {
            // arrange
            const string firstline =
                "LINESTRING (122804.613000002 485610.0381, 122794.59 485612.74013569974)";
            var line1 = (ILineString)new WKTReader().Read(firstline);
            const string secondline =
                "LINESTRING (122794.039999999 485635.864100002, 122794.58999999998 485635.7686024924)";
            var line2 = (ILineString)new WKTReader().Read(secondline);
            var poly = new GeometryFactory().CreatePolygon(new Coordinate[] {
                new Coordinate(line1.Coordinates[0].X, line1.Coordinates[0].Y),
                new Coordinate(line1.Coordinates[1].X, line1.Coordinates[1].Y),
                new Coordinate(line2.Coordinates[0].X, line2.Coordinates[0].Y),
                new Coordinate(line2.Coordinates[0].X, line2.Coordinates[0].Y),
                new Coordinate(line1.Coordinates[0].X, line1.Coordinates[0].Y)
            });
            return poly.AsText();
        }
    }
}
