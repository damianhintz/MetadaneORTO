using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;
using System.ComponentModel;
using System.ComponentModel.Design;

namespace MetadaneORTO.Core.Schemat
{
    public class LayerSchema
    {
        [Category("Atrybuty"), DisplayName("Nazwa"), Description("Nazwa schematu"), ReadOnly(false)]
        public string Name { get; set; }

        //[Category("Atrybuty"), DisplayName("Kod układu EPSG"), Description("Kod EPSG układu współrzędnych"), ReadOnly(false)]
        //public int EPSG { get; set; }
        
        [Category("Atrybuty"), DisplayName("Układ współrzędnych"), Description("Układu współrzędnych"), ReadOnly(false)]
        public string ProjCS { get; set; }

        [Category("Atrybuty"), DisplayName("Klucz schematu"), Description("Klucz schematu będący nazwą unikatowego pola bazy (wymagany)"), ReadOnly(false)]
        public string AttribKey { get; set; }
        
        [Category("Atrybuty"), DisplayName("Atrybut zasięgu"), Description("Atrybut zasięgu"), ReadOnly(false)]
        public string GeomKey { get; set; }

        List<LayerField> _fields = new List<LayerField>();

        [Category("Atrybuty"), DisplayName("Schemat bazy"), Description("Schemat bazy"), ReadOnly(false)]
        public List<LayerField> Fields { get { return _fields; } set { _fields = value; } }

        public LayerSchema()
        {
            Name = "bez nazwy";
            //EPSG = 2180;
            ProjCS = "PROJCS[\"PUWG_1992\",GEOGCS[\"GCS_ETRS_1989\",DATUM[\"D_ETRS_1989\",SPHEROID[\"GRS_1980\",6378137.0,298.257222101]],PRIMEM[\"Greenwich\",0.0],UNIT[\"Degree\",0.0174532925199433]],PROJECTION[\"Gauss_Kruger\"],PARAMETER[\"False_Easting\",500000.0],PARAMETER[\"False_Northing\",-5300000.0],PARAMETER[\"Central_Meridian\",19.0],PARAMETER[\"Scale_Factor\",0.9993],PARAMETER[\"Latitude_Of_Origin\",0.0],UNIT[\"Meter\",1.0]]";
        }

        public bool Validate()
        {
            if (_fields.Count == 0) 
                throw new ApplicationException("Schemat nie zawiera żadnych pól");

            if (string.IsNullOrEmpty(AttribKey))
                throw new ApplicationException("Klucz schematu nie został zdefiniowany" + AttribKey);

            if (!ContainsField(AttribKey))
                throw new ApplicationException("Klucz schematu nieprawidłowy: " + AttribKey);

            if (string.IsNullOrEmpty(GeomKey))
                throw new ApplicationException("Atrybut zasięgu nie został zdefiniowany");

            Dictionary<string, string> fields = new Dictionary<string, string>();

            foreach (LayerField field in _fields)
            {
                if (fields.ContainsKey(field.Name)) throw new ApplicationException("Nazwa pola schematu została powtórzona: " + field.Name);
                fields.Add(field.Name, field.Name);
            }

            return true;
        }

        public bool ContainsField(string name)
        {
            foreach (LayerField field in _fields)
            {
                if (field.Name == name) return true;
            }

            return false;
        }

        public static void ToXML(string xmlFile, LayerSchema model)
        {
            XmlSerializer xmlSer = new XmlSerializer(typeof(LayerSchema));
            StreamWriter writer = new StreamWriter(xmlFile);
            xmlSer.Serialize(writer, model);
            writer.Close();
        }

        public void ToXML(string xmlFile)
        {
            LayerSchema.ToXML(xmlFile, this);
        }

        public static LayerSchema FromXML(string xmlFile)
        {
            LayerSchema szkic = null;
            StreamReader reader = null;

            try
            {
                XmlSerializer xmlSer = new XmlSerializer(typeof(LayerSchema));
                reader = new StreamReader(xmlFile);
                szkic = (LayerSchema)xmlSer.Deserialize(reader);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (reader != null)
                    reader.Close();
            }

            return szkic;
        }

    }
}
