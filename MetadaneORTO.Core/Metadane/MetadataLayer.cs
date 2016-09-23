using System;

using OSGeo.OGR;
using OSGeo.OSR;

using MetadaneORTO.Core.Schemat;
using MetadaneORTO.Core.Zakresy;

namespace MetadaneORTO.Core.Metadane
{
    /// <summary>
    /// Reprezentuję warstwę metadanych.
    /// </summary>
    public class MetadataLayer
    {
        private string _name = null;

        private wkbGeometryType _type;

        private LayerCatalog _catalog = null;

        private DataSource _dataSource = null;

        private Layer _layer = null;

        private SpatialReference _srs = new SpatialReference("");

        public static string Encoding = "1250";

        public MetadataLayer(string name, wkbGeometryType typ, LayerCatalog catalog)
        {
            _catalog = catalog;
            _dataSource = _catalog.Source;

            _name = name;
            _type = typ;

            //_srs.ImportFromEPSG(_catalog.Schema.EPSG);
            string wkt = _catalog.Schema.ProjCS;
            _srs.ImportFromWkt(ref wkt);

            string encodingOption = "ENCODING=" + Encoding;
            _layer = _dataSource.CreateLayer(name, _srs, _type, new string[] { encodingOption });
            //_layer = _dataSource.CreateLayer(name, _srs, _type, new string[] { });

            if (_layer == null)
                throw new Exception("Nie można utworzyć warstwy metadanych.");

            foreach (LayerField field in _catalog.Schema.Fields)
            {
                switch (field.Type)
                {
                    case FieldTypeName.Date:
                        AddFieldDate(field.Name);
                        break;
                    case FieldTypeName.Float:
                        AddFieldReal(field.Name, field.Width, field.Precision);
                        break;
                    case FieldTypeName.String:
                        AddFieldString(field.Name, field.Width);
                        break;
                    case FieldTypeName.Real:
                        AddFieldReal(field.Name, field.Width, field.Precision);
                        break;
                    case FieldTypeName.Integer:
                        AddFieldInteger(field.Name, field.Width);
                        break;
                }
            }
        }

        public void Dispose()
        {
            _layer.Dispose();
        }

        public void AddFieldInteger(string name, int width)
        {
            FieldDefn fdefn = new FieldDefn(name, FieldType.OFTInteger);

            fdefn.SetWidth(width);

            if (_layer.CreateField(fdefn, 1) != 0)
                throw new Exception("Nie można utworzyć pola " + name);
        }

        public void AddFieldReal(string name, int width, int precision)
        {
            FieldDefn fdefn = new FieldDefn(name, FieldType.OFTReal);

            fdefn.SetWidth(width);
            fdefn.SetPrecision(precision);

            if (_layer.CreateField(fdefn, 1) != 0)
                throw new Exception("Nie można utworzyć pola " + name);
        }

        public void AddFieldString(string name, int fieldWidth)
        {
            FieldDefn fdefn = new FieldDefn(name, FieldType.OFTString);

            fdefn.SetWidth(fieldWidth);

            if (_layer.CreateField(fdefn, 1) != 0)
                throw new Exception("Nie można utworzyć pola " + name);
        }

        public void AddFieldDate(string name)
        {
            FieldDefn fdefn = new FieldDefn(name, FieldType.OFTDate);

            if (_layer.CreateField(fdefn, 1) != 0)
                throw new Exception("Nie można utworzyć pola " + name);
        }

        public bool CreateFeature(GeometryFeature geomFeature, params string[] fields)
        {
            Geometry geometria = geomFeature.Geometry;
            Feature feature = new Feature(_layer.GetLayerDefn());

            for (int i = 0; i < _catalog.Schema.Fields.Count; i++)
            {
                LayerField field = _catalog.Schema.Fields[i];
                string value = fields[i];

                switch (field.Type)
                {
                    case FieldTypeName.Date:
                        DateTime date = DateTime.Parse(value);
                        int rok = date.Year, miesiac = date.Month, dzien = date.Day;
                        feature.SetField(i, rok, miesiac, dzien, 0, 0, 0, 0);
                        break;
                    case FieldTypeName.Float:
                        feature.SetField(i, double.Parse(value));
                        break;
                    case FieldTypeName.String:
                        feature.SetField(i, value);
                        break;
                    case FieldTypeName.Real:
                        feature.SetField(i, double.Parse(value));
                        break;
                    case FieldTypeName.Integer:
                        feature.SetField(i, int.Parse(value));
                        break;
                }
            }

            if (geometria != null)
            {
                if (feature.SetGeometry(geometria) != 0)
                    return false;
            }

            return _layer.CreateFeature(feature) == 0;
        }

        /*public void DumpLayer()
        {
            FeatureDefn def = this._layer.GetLayerDefn();
            Console.WriteLine("Nazwa warstwy: " + def.GetName());
            Console.WriteLine("Liczba obiektów: " + this._layer.GetFeatureCount(1));

            Envelope ext = new Envelope();
            _layer.GetExtent(ext, 1);
            Console.WriteLine("Zasięg: " + ext.MinX + "," + ext.MaxX + "," + ext.MinY + "," + ext.MaxY);

            SpatialReference sr = this._layer.GetSpatialRef();
            string srs_wkt = "(unknown)";
            if (sr != null)
                sr.ExportToPrettyWkt(out srs_wkt, 1);
            Console.WriteLine("Układ przestrzenny warstwy: " + srs_wkt);

            Console.WriteLine("Definicje atrybutów:");
            for (int iAttr = 0; iAttr < def.GetFieldCount(); iAttr++)
            {
                FieldDefn fdef = def.GetFieldDefn(iAttr);
                Console.WriteLine(fdef.GetNameRef() + ": " + fdef.GetFieldTypeName(fdef.GetFieldType()) + " (" + fdef.GetWidth() + "." + fdef.GetPrecision() + ")");
            }
        }*/
    }
}
