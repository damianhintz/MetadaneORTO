using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

using OSGeo.OGR;

namespace MetadaneORTO.Core.Zakresy
{
    /// <summary>
    /// Warstwa zakresów/poligonów bez atrybutów.
    /// </summary>
    class PhotoGeometryLoader : ZakresyLoader
    {
        public PhotoGeometryLoader(GeometryLayer geometryLayer)
            : base(geometryLayer)
        {
        }

        public override void Importuj()
        {
            using (StreamReader reader = new StreamReader(_geometryLayer.FileName, Encoding.GetEncoding(1250)))
            {
                string wiersz = null;
                string photo = null, image_id = null;
                char[] separator = new char[] { ' ', '\t' };

                while ((wiersz = reader.ReadLine()) != null)
                {
                    if (wiersz.StartsWith("begin photo_parameters"))
                    {
                        string[] cols = wiersz.Split(separator);
                        photo = cols[2];
                    }
                    else if (wiersz.StartsWith(" image_id:"))
                    {
                        string[] cols = wiersz.Trim().Split(separator);
                        image_id = cols[1];
                    }
                    else if (wiersz.StartsWith(" footprint:"))
                    {
                        string[] cols = wiersz.Trim().Split(separator);

                        string wkt = string.Format("POLYGON (({0} {1},{2} {3},{4} {5},{6} {7},{0} {1}))",
                            cols[1], cols[2], cols[3], cols[4], cols[5], cols[6], cols[7], cols[8]);
                        Geometry geometry = Geometry.CreateFromWkt(wkt);

                        geometry = GeometryFeature.GeometryToEnvelope(geometry);

                        string[] imageName = photo.Split('_');
                        string image = imageName[imageName.Length - 1];

                        GeometryFeature geomFeature = new GeometryFeature { Geometry = geometry, Name = "name", Value = image };

                        _geometryLayer.AddFeature(geomFeature);
                    }
                }
            }
        }
    }
}
