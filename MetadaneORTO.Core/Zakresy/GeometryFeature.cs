
using OSGeo.OGR;
using MetadaneORTO.Core.Atrybuty;

namespace MetadaneORTO.Core.Zakresy
{
    /// <summary>
    /// Geometria reprezentująca zakres.
    /// </summary>
    public class GeometryFeature
    {
        public Geometry Geometry { get; set; }

        public string Name { get; set; }

        public string Value { get; set; }

        public FeatureAttributes Attributes = new FeatureAttributes();

        public static Geometry GeometryToEnvelope(Geometry geom)
        {
            Envelope env = new Envelope();
            geom.GetEnvelope(env);

            string wkt = string.Format("POLYGON (({0} {1},{2} {3},{4} {5},{6} {7},{0} {1}))",
                env.MinX, env.MinY, env.MaxX, env.MinY, env.MaxX, env.MaxY, env.MinX, env.MaxY);

            return Geometry.CreateFromWkt(wkt);
        }
    }
}
