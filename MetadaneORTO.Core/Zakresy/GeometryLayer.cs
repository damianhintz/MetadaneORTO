using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

using OSGeo.OGR;

using MetadaneORTO.Core.Schemat;
using MetadaneORTO.Core.Atrybuty;

namespace MetadaneORTO.Core.Zakresy
{
    /// <summary>
    /// Warstwa zakresów.
    /// </summary>
    public class GeometryLayer
    {
        public TypZakresu Typ { get; private set; }

        private string _fileName;

        public string FileName { get { return _fileName; } }

        private string _layerName;

        /// <summary>
        /// Nazwa warstwy.
        /// </summary>
        public string LayerName { get { return _layerName; } }

        private LayerSchema _schema = null;

        private Dictionary<string, GeometryFeature> _features = new Dictionary<string, GeometryFeature>();

        /// <summary>
        /// Obiekty reprezentujące zakresy.
        /// </summary>
        public GeometryFeature[] Features
        {
            get { return _features.Values.ToArray(); }
        }

        /// <summary>
        /// Zwraca liczbę zakresów na warstwie.
        /// </summary>
        public int Count { get { return _features.Count; } }

        /// <summary>
        /// Zakresy bez identyfikatora lub z powtórzonym identyfikatorem.
        /// </summary>
        List<GeometryFeature> _invalidFeatures = new List<GeometryFeature>();

        public GeometryLayer(LayerSchema schema, string fileName)
        {
            _schema = schema;
            _fileName = fileName;
            _layerName = Path.GetFileNameWithoutExtension(fileName);
        }

        public bool AddFeature(GeometryFeature gf)
        {
            if (gf.Name == null)
            {
                _invalidFeatures.Add(gf);
                return false;
            }
            else
            {
                if (_features.ContainsKey(gf.Value))
                {
                    _invalidFeatures.Add(gf);
                    return false;
                }
                else
                {
                    _features.Add(gf.Value, gf);
                }
            }

            return true;
        }

        public void ImportujPhoto()
        {
            PhotoGeometryLoader loader = new PhotoGeometryLoader(this);
            loader.Importuj();
            Typ = TypZakresu.Poligonowy;
        }

        public void ImportujOgr()
        {
            OgrGeometryLoader loader = new OgrGeometryLoader(this);
            loader.Importuj();
            Typ = TypZakresu.Poligonowy;
        }

        public AttributeLayer ImportujPunkty(LayerSchema schemat)
        {
            ExcelGeometryLoader loader = new ExcelGeometryLoader(this);
            AttributeLayer atrybuty = loader.ImportujAtrybuty(schemat);
            Typ = TypZakresu.Punktowy;
            return atrybuty;
        }

        public void ImportujAtrybutyWarstwy(AttributeLayer layer)
        {
            foreach (KeyValuePair<string, GeometryFeature> kv in _features)
            {
                GeometryFeature gf = kv.Value;
                string geomValue = kv.Key;
                
                if (layer.ContainsKey(geomValue))
                {
                    FeatureAttributes attributes = layer[geomValue];
                    
                    gf.Attributes = attributes;
                }
                else
                    throw new Exception("Brak atrybutów dla zasięgu: " + geomValue);
            }
        }

        public void ImportujAtrybutyWarstwyKolumnowo(AttributeLayer layer)
        {
            foreach (GeometryFeature gf in Features)
            {
                string geomValue = gf.Value;
                FeatureAttributes attributes = layer.CommonAttributes;

                foreach (LayerField field in _schema.Fields)
                {
                    string value = attributes[field.Name];

                    string variableName = "[" + _schema.GeomKey + "]";
                    value = value.Replace(variableName, geomValue);

                    gf.Attributes[field.Name] = value;
                }
            }
        }

        public override string ToString()
        {
            return string.Format("Źródło danych: {0}\nNazwa warstwy: {1}\nPoprawne zakresy: {2}\nBłędne zakresy: {3}",
                _fileName, _layerName, _features.Count, _invalidFeatures.Count);
        }
    }
}
