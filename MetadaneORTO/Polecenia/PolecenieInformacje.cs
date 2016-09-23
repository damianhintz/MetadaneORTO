using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MetadaneORTO.Polecenia
{
    /// <summary>
    /// Wyświetla podstawowe informacje o programie.
    /// </summary>
    class PolecenieInformacje : PolecenieBase
    {
        public PolecenieInformacje(MainForm form)
            : base(form)
        {
        }

        public override void Wykonaj()
        {
            MessageBox.Show(_form,
                string.Format("{0}\nWersja {1}\n@ 2012-2013 OPGK Olsztyn.\nWszelkie prawa zastrzeżone.", _form.Nazwa, _form.Wersja),
                _nazwa);
        }
    }

}
