using System;
using System.Collections.Generic;
using System.Linq;

using MetadaneORTO.Core.Schemat;

namespace MetadaneORTO.Core.Atrybuty
{
    public class FeatureAttributes
    {
        Dictionary<string, string> _values = new Dictionary<string, string>();

        public string[] Values { get { return _values.Values.ToArray(); } }

        public string[] Names { get { return _values.Keys.ToArray(); } }

        public string this[string name]
        {
            get { return _values[name]; }

            set
            {
                if (_values.ContainsKey(name))
                    _values[name] = value;
                else
                    _values.Add(name, value);
            }
        }

        public bool ContainsName(string name)
        {
            return _values.ContainsKey(name);
        }

        public bool Validate(LayerSchema schema)
        {
            Evaluate();

            string dot = ".", comma = ",";
            double doubleValue = 0.1;
            string doubleString = doubleValue.ToString();

            if (!doubleString.Contains(dot))
            {
                dot = ",";
                comma = ".";
            }

            string msg = "\nAtrybuty";

            for (int i = 0; i < schema.Fields.Count; i++)
            {
                LayerField field = schema.Fields[i];

                if (!_values.ContainsKey(field.Name))
                    throw new Exception("Brak wymaganego pola: " + field.Name);

                string value = _values[field.Name];
                msg += "\n" + field.Name + " = " + value;

                switch (field.Type)
                {
                    case FieldTypeName.Date:

                        DateTime date;

                        if (!DateTime.TryParse(value, out date))
                            throw new Exception("Format daty niepoprawny: " + value + " dla pola " + field.Name + msg);

                        break;
                    case FieldTypeName.Float:
                        value = _values[field.Name] = value.Replace(comma, dot);

                        double f;

                        if (!double.TryParse(value, out f))
                            throw new Exception("Format typu Float niepoprawny: " + value + " dla pola " + field.Name + msg);

                        break;
                    case FieldTypeName.String:

                        if (field.Width < value.Length)
                            throw new Exception("Długość tekstu " + value.Length +
                                " za długa dla pola: " + field.Name + "[" + field.Width + "]");

                        break;
                    case FieldTypeName.Real:
                        value = _values[field.Name] = value.Replace(comma, dot);

                        double d;

                        if (!double.TryParse(value, out d))
                            throw new Exception("Format typu Real niepoprawny: " + value + " dla pola " + field.Name + msg);

                        break;
                    case FieldTypeName.Integer:

                        int n;

                        if (!int.TryParse(value, out n))
                            throw new Exception("Format typu Integer niepoprawny: " + value + " dla pola " + field.Name + msg);

                        break;
                }
            }

            return true;
        }

        /// <summary>
        /// Rozwijanie wszystkich zmiennych. Zmiennymi mogą być nazwy pól np. [nazwa_zmiennej].
        /// Zmienna powinna być zawarta między nawiasami kwadratowymi.
        /// </summary>
        public void Evaluate()
        {
            Dictionary<string, string> values = new Dictionary<string, string>();

            foreach (KeyValuePair<string, string> kvKeys in _values)
            {
                string key = kvKeys.Key;
                string newValue = kvKeys.Value;

                foreach (KeyValuePair<string, string> kvValues in _values)
                {
                    string variableName = "[" + kvValues.Key + "]";
                    string variableValue = kvValues.Value;

                    newValue = newValue.Replace(variableName, variableValue);
                }

                values.Add(key, newValue);
            }

            _values = values;
        }
    }
}
