using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

using MetadaneORTO.Core.Schemat;
using MetadaneORTO.Core.Zakresy;
using MetadaneORTO.Core.Atrybuty;
using MetadaneORTO.Core.Metadane;

using MetadaneORTO.Properties;

namespace MetadaneORTO.Polecenia
{
    class PolecenieEksportujMetadane : PolecenieBase
    {
        private FolderBrowserDialog _dialog;

        public PolecenieEksportujMetadane(MainForm form)
            : base(form)
        {
            _dialog = new FolderBrowserDialog();
        }

        public override void Wykonaj()
        {
            LayerSchema _schemat = _form.Schemat;

            if (_schemat == null)
            {
                ShowInfo("Przed eksportem metadanych wybierz schemat bazy metadanych.");
                return;
            }

            GeometryLayer _zakresy = _form.Zakresy;

            if (_zakresy == null)
            {
                ShowInfo("Przed eksportem metadanych wczytaj zasięgi.");
                return;
            }

            AttributeLayer _atrybuty = _form.Atrybuty;

            if (_atrybuty == null)
            {
                ShowInfo("Przed eksportem metadanych wczytaj atrybuty.");
                return;
            }

            if (Directory.Exists(Settings.Default.RecentCatalog)) _dialog.SelectedPath = Settings.Default.RecentCatalog;

            if (_dialog.ShowDialog(_form) != DialogResult.OK) return;

            Settings.Default.RecentCatalog = _dialog.SelectedPath;
            Settings.Default.Save();

            try
            {
                LayerCatalog catalog = new LayerCatalog(_dialog.SelectedPath, _schemat);

                if (catalog.LayerExists(_zakresy.LayerName))
                    ShowError("Zbiór metadanych " + _zakresy.LayerName + " już istnieje.");
                else
                {
                    MetadataLayer layer = null;

                    switch (_zakresy.Typ)
                    {
                        case TypZakresu.Poligonowy:
                            layer = catalog.CreatePolygonLayer(_zakresy.LayerName);
                            break;
                        case TypZakresu.Punktowy:
                            layer = catalog.CreatePointLayer(_zakresy.LayerName);
                            break;
                    }

                    _form.EksportujMetadane(layer);
                    layer.Dispose();

                    ShowInfo("Eksport zakończony.");
                }

                catalog.Dispose();
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
            }

            _form.AktualizujTytul();
        }
    }
}
