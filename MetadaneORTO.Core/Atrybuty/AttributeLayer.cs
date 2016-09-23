using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Data.OleDb;
using MetadaneORTO.Core.Schemat;

namespace MetadaneORTO.Core.Atrybuty
{
    /// <summary>
    /// Atrybuty metadanych.
    /// </summary>
    public class AttributeLayer
    {
        string _fileName;

        string _layerName;

        /// <summary>
        /// Nazwa warstwy.
        /// </summary>
        public string LayerName { get { return _layerName; } }

        Dictionary<string, FeatureAttributes> _items = new Dictionary<string, FeatureAttributes>();

        public FeatureAttributes this[string name]
        {
            get { return _items.ContainsKey(name) ? _items[name] : null; }
        }

        public FeatureAttributes[] Attributes
        {
            get { return _items.Values.ToArray(); }
        }

        /// <summary>
        /// Zwraca liczbę atrybutów.
        /// </summary>
        public int Count { get { return _items.Count; } }

        public FeatureAttributes CommonAttributes
        {
            get { return _items[_schema.GeomKey]; }
        }

        LayerSchema _schema = null;

        public AttributeLayer(LayerSchema schema, string fileName)
        {
            _schema = schema;
            _fileName = fileName;
            _layerName = Path.GetFileNameWithoutExtension(fileName);
        }

        public bool ContainsKey(string key)
        {
            return _items.ContainsKey(key);
        }

        /// <summary>
        /// Importowanie atrybutów z pliku tekstowego.
        /// </summary>
        public void ImportujTekstowy()
        {
            StreamReader reader = new StreamReader(_fileName, Encoding.GetEncoding(1250));
            string wiersz = null;
            Dictionary<string, int> headerNames = new Dictionary<string, int>();

            string header = reader.ReadLine();
            string[] cols = header.Split('\t');

            for (int i = 0; i < cols.Length; i++)
            {
                if (headerNames.ContainsKey(cols[i]))
                    throw new ApplicationException("Nazwa pola powtórzona: " + cols[i]);
                headerNames.Add(cols[i], i);
            }

            while ((wiersz = reader.ReadLine()) != null)
            {
                if (string.IsNullOrEmpty(wiersz)) continue;

                cols = wiersz.Split('\t');

                FeatureAttributes attributes = new FeatureAttributes();

                foreach (LayerField field in _schema.Fields)
                {
                    try
                    {
                        attributes[field.Name] = cols[headerNames[field.Name]];
                    }
                    catch (Exception ex)
                    {
                        throw new ApplicationException("Nie można odczytać pola: " + field.Name + "\n" + ex.Message);
                    }
                }

                string key = cols[headerNames[_schema.AttribKey]];

                if (string.IsNullOrEmpty(key)) continue;

                if (attributes.Validate(_schema))
                {
                    _items.Add(key, attributes);
                }
            }

            reader.Close();

        }

        /// <summary>
        /// Importowanie atrybutów z pliku xls.
        /// </summary>
        /// <remarks>Plik xls powinien zawierać arkusz o takiej samej nazwie jak plik xls.</remarks>
        public void ImportujExcel()
        {
            string name = Path.GetFileNameWithoutExtension(_fileName);
            string arkusz = name + "$";

            string conString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" +
                _fileName +
                ";Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=1\"";

            string kolumny = "";

            foreach (LayerField field in _schema.Fields)
            {
                if (!string.IsNullOrEmpty(kolumny)) kolumny += ",";

                kolumny += field.Name;
            }

            string queryString = "SELECT * FROM [" + arkusz + "]";

            OleDbDataReader reader = null;
            bool hasRows = false;

            using (OleDbConnection connection = new OleDbConnection(conString))
            {
                connection.Open();

                OleDbCommand command = new OleDbCommand(queryString, connection);

                reader = command.ExecuteReader();
                hasRows = reader.HasRows;

                //przeglądanie wierszy pliku xls
                for (int i = 0; reader.Read(); i++)
                {
                    FeatureAttributes attributes = new FeatureAttributes();

                    foreach (LayerField field in _schema.Fields)
                    {
                        try
                        {
                            attributes[field.Name] = reader[field.Name].ToString();
                        }
                        catch (Exception ex)
                        {
                            throw new ApplicationException("Nie można odczytać pola: " + field.Name + "\n" + ex.Message);
                        }
                    }

                    string key = reader[_schema.AttribKey].ToString();

                    if (string.IsNullOrEmpty(key)) continue;

                    if (attributes.Validate(_schema))
                    {
                        _items.Add(key, attributes);
                    }
                }
            }
        }

        /// <summary>
        /// Importowanie atrybutów z pliku xls.
        /// Atrybuty stałe zapisane kolumnowo.
        /// Pierwsza kolumna zawiera nazwy pól, druga kolumna zawiera wartości.
        /// </summary>
        /// <remarks>Plik xls powinien zawierać arkusz o takiej samej nazwie jak plik xls.</remarks>
        public void ImportujExcelKolumnowo()
        {
            string arkusz = Path.GetFileNameWithoutExtension(_fileName) + "$";

            string conString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" +
                _fileName +
                ";Extended Properties=\"Excel 8.0;HDR=No;IMEX=1\"";

            string queryString = "SELECT * FROM [" + arkusz + "]";

            OleDbDataReader reader = null;
            bool hasRows = false;

            using (OleDbConnection connection = new OleDbConnection(conString))
            {
                connection.Open();

                OleDbCommand command = new OleDbCommand(queryString, connection);

                reader = command.ExecuteReader();
                hasRows = reader.HasRows;

                FeatureAttributes attributes = new FeatureAttributes();

                //przeglądanie wierszy pliku xls
                for (int i = 0; reader.Read(); i++)
                {
                    object[] values = new object[2];

                    reader.GetValues(values);

                    string field = values[0].ToString();
                    string value = values[1].ToString();

                    if (string.IsNullOrEmpty(field)) continue;

                    attributes[field] = value;
                }

                if (attributes.Validate(_schema))
                    _items.Add(_schema.GeomKey, attributes);
            }
        }

        public override string ToString()
        {
            return string.Format("Źródło danych: {0}\nWszystkie atrybuty: {1}", _layerName, _items.Count);
        }
    }
}
