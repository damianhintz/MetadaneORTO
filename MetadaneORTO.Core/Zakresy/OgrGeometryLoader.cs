using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using OSGeo.OGR;

namespace MetadaneORTO.Core.Zakresy
{
    /// <summary>
    /// Warstwa zakresów/poligonów bez atrybutów.
    /// </summary>
    class OgrGeometryLoader : ZakresyLoader
    {
        public OgrGeometryLoader(GeometryLayer geometryLayer)
            : base(geometryLayer)
        {
        }

        public override void Importuj()
        {
            string fileName = _geometryLayer.FileName;

            DataSource ds = Ogr.Open(fileName, 0);

            if (ds == null)
                throw new Exception(string.Format("Nie można otworzyć źródła danych {0}", fileName));

            Driver dsDriver = ds.GetDriver();

            if (dsDriver == null)
                throw new Exception(string.Format("Nie można użyć sterownika dla źródła danych {0}", fileName));

            if (ds.GetLayerCount() < 1)
                throw new Exception(string.Format("Brak danych dla źródła {0} ({1})", fileName, dsDriver.name));

            for (int iLayer = 0; iLayer < ds.GetLayerCount(); iLayer++)
            {
                Layer layer = ds.GetLayerByIndex(iLayer);

                if (layer != null)
                {
                    WczytajOgrLayer(layer);
                    break;
                }
            }
        }

        private void WczytajOgrLayer(Layer layer)
        {
            List<GeometryFeature> poligony = new List<GeometryFeature>();
            List<GeometryFeature> teksty = new List<GeometryFeature>();

            FeatureDefn layerDef = layer.GetLayerDefn();
            Feature feat = null;

            while ((feat = layer.GetNextFeature()) != null)
            {
                Geometry featGeom = feat.GetGeometryRef();
                FeatureDefn featDef = feat.GetDefnRef();

                string name = null;
                string value = null;

                //pierwsze pole tekstowe
                for (int i = 0; i < feat.GetFieldCount(); i++)
                {
                    FieldDefn fdef = featDef.GetFieldDefn(i);

                    if (feat.IsFieldSet(i))
                    {
                        if (fdef.GetFieldType() == FieldType.OFTString)
                        {
                            name = fdef.GetNameRef();
                            value = feat.GetFieldAsString(i);
                            break;
                        }
                    }
                }

                switch (featGeom.GetGeometryType())
                {
                    case wkbGeometryType.wkbPolygon:
                    case wkbGeometryType.wkbPolygon25D:
                        {
                            GeometryFeature geomFeature = new GeometryFeature { Geometry = featGeom.Clone(), Name = name, Value = value };
                            poligony.Add(geomFeature);
                        }
                        break;
                    case wkbGeometryType.wkbPoint:
                    case wkbGeometryType.wkbPoint25D:
                        {
                            GeometryFeature geomFeature = new GeometryFeature { Geometry = featGeom.Clone(), Name = name, Value = value };
                            teksty.Add(geomFeature);
                        }
                        break;
                }

                feat.Dispose();
            }

            //przypisanie tekstów do poligonów
            foreach (GeometryFeature gf in poligony)
            {
                //przypisz pierwszy tekst zawarty w poligonie
                foreach (GeometryFeature tf in teksty)
                {
                    if (gf.Geometry.Contains(tf.Geometry))
                    {
                        gf.Name = tf.Name;
                        gf.Value = tf.Value;
                        break;
                    }
                }

                _geometryLayer.AddFeature(gf);
            }
        }
    }
}
