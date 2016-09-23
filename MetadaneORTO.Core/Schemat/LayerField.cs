using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Xml.Serialization;

using OSGeo.OGR;

namespace MetadaneORTO.Core.Schemat
{
    public class LayerField
    {
        [Category("Atrybuty"), DisplayName("Nazwa"), Description("Nazwa pola"), ReadOnly(false), XmlAttribute("name")]
        public string Name { get; set; }

        FieldTypeName _type = FieldTypeName.String;

        /// <summary>
        /// Integer (10), Real (19,11), String, Date
        /// </summary>
        [Category("Atrybuty"), DisplayName("Typ"), Description("Typ pola"), ReadOnly(false), XmlAttribute("type")]
        public FieldTypeName Type
        {
            get { return _type; }

            set {
                _type = value;

                switch (value)
                {
                    case FieldTypeName.Date:
                        Width = 8;
                        Precision = 0;
                        break;
                    case FieldTypeName.Float:
                        Width = 13;
                        Precision = 11;
                        break;
                    case FieldTypeName.Integer:
                        Width = 4;
                        Precision = 0;
                        break;
                    case FieldTypeName.Real:
                        Width = 19;
                        Precision = 11;
                        break;
                    case FieldTypeName.String:
                        Width = 254;
                        Precision = 0;
                        break;
                }
            }
        }

        /// <summary>
        /// Formatting width for this field in characters.
        /// </summary>
        [Category("Atrybuty"), DisplayName("Szerokość"), Description("Szerokość pola"), ReadOnly(false), XmlAttribute("width")]
        public int Width { get; set; }

        /// <summary>
        /// Formatting precision for this field in characters.
        /// This should normally be zero for fields of types other than OFTReal.
        /// </summary>
        [Category("Atrybuty"), DisplayName("Precyzja"), Description("Precyzja pola (dla typów innych niż Real powinno być zero)"), ReadOnly(false), XmlAttribute("precision")]
        public int Precision { get; set; }

        public LayerField()
        {
            Name = "Bez_nazwy";
            Type = FieldTypeName.String;
        }
    }
}
