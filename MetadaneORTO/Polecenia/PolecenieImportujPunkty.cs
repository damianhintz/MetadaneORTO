using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

using MetadaneORTO.Core.Schemat;
using MetadaneORTO.Core.Zakresy;
using MetadaneORTO.Core.Atrybuty;

namespace MetadaneORTO.Polecenia
{
    class PolecenieImportujPunkty : PolecenieBase
    {
        public OpenFileDialog _dialog;

        public PolecenieImportujPunkty(MainForm form)
            : base(form)
        {
            _dialog = new OpenFileDialog();
            _dialog.Title = _nazwa;
            //_dialog.Filter = "Microsoft Excel (*.xls)|*.xls|Photo file (footprint) (*.txt)|*.txt";
            _dialog.Filter = "Microsoft Excel (*.xls)|*.xls";
        }

        public override void Wykonaj()
        {
            LayerSchema _schemat = _form.Schemat;

            if (_schemat == null)
            {
                ShowInfo("Przed importem punktów wybierz schemat bazy metadanych.");
                return;
            }

            if (_dialog.ShowDialog(_form) != DialogResult.OK) return;

            try
            {
                _schemat.Validate();
                GeometryLayer zakresy = new GeometryLayer(_schemat, _dialog.FileName);
                AttributeLayer atrybuty = null;

                string ext = Path.GetExtension(_dialog.FileName);

                switch (ext.ToLower())
                {
                    case ".xls":
                        atrybuty = zakresy.ImportujPunkty(_schemat);
                        break;
                    default:
                        break;
                }

                _form.ImportujZintegrowaneZakresy(zakresy, atrybuty);

                ShowInfo(zakresy.ToString() + "\n" + atrybuty.ToString());
            }
            catch (Exception ex)
            {
                _form.ImportujZintegrowaneZakresy(null, null);
                ShowError(ex.Message);
            }

            _form.AktualizujTytul();
        }
    }
}
