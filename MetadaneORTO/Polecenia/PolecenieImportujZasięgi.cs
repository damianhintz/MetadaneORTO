using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

using MetadaneORTO.Core.Schemat;
using MetadaneORTO.Core.Zakresy;

namespace MetadaneORTO.Polecenia
{
    /// <summary>
    /// Import zakresów.
    /// </summary>
    class PolecenieImportujZasięgi : PolecenieBase
    {
        public OpenFileDialog _dialog;

        public PolecenieImportujZasięgi(MainForm form)
            : base(form)
        {
            _dialog = new OpenFileDialog();
            _dialog.Title = _nazwa;
            _dialog.Filter = "Microstation v7 (*.dgn)|*.dgn|ESRI Shapefile (*.shp)|*.shp|Photo file (footprint) (*.txt)|*.txt";
        }

        public override void Wykonaj()
        {
            LayerSchema _schemat = _form.Schemat;
            
            if (_schemat == null)
            {
                ShowInfo("Przed importem zasięgów wybierz schemat bazy metadanych.");
                return;
            }

            if (_dialog.ShowDialog(_form) != DialogResult.OK) return;

            try
            {
                _schemat.Validate();
                GeometryLayer zakresy = new GeometryLayer(_schemat, _dialog.FileName);

                string ext = Path.GetExtension(_dialog.FileName);

                switch (ext.ToLower())
                {
                    case ".txt":
                        zakresy.ImportujPhoto();
                        break;
                    default:
                        zakresy.ImportujOgr();
                        break;
                }
                
                _form.ImportujZakresy(zakresy);

                ShowInfo(zakresy.ToString());
            }
            catch (Exception ex)
            {
                _form.ImportujZakresy(null);
                ShowError(ex.Message);
            }

            _form.AktualizujTytul();
        }
    }
}
