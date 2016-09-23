using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.IO;

using OSGeo.OGR;

using MetadaneORTO.Core.Schemat;
using MetadaneORTO.Core.Atrybuty;

namespace MetadaneORTO.Core.Zakresy
{
    /// <summary>
    /// Zintegrowana warstwa punktowa zakresów i atrybutów.
    /// </summary>
    class ExcelGeometryLoader : ZakresyLoader
    {
        public ExcelGeometryLoader(GeometryLayer geometryLayer)
            : base(geometryLayer)
        {
        }

        public override void Importuj()
        {
            throw new NotImplementedException();
        }

        public AttributeLayer ImportujAtrybuty(LayerSchema _schema)
        {
            string _fileName = _geometryLayer.FileName;

            AttributeLayer atrybuty = new AttributeLayer(_schema, _fileName);
            atrybuty.ImportujExcel();

            foreach (var atr in atrybuty.Attributes)
            {
                if (atr.ContainsName("X") && atr.ContainsName("Y"))
                {
                    string x = atr["X"], y = atr["Y"];
                    string wkt = string.Format("POINT ({0} {1})", y, x);
                    Geometry geometry = Geometry.CreateFromWkt(wkt);
                    string image = atr[_schema.AttribKey];
                    GeometryFeature geomFeature = new GeometryFeature { Geometry = geometry, Name = "name", Value = image };
                    _geometryLayer.AddFeature(geomFeature);
                }
            }

            return atrybuty;
        }
    }
}
