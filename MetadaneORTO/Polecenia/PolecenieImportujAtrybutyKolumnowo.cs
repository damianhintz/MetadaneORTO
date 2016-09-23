﻿using System;
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
    class PolecenieImportujAtrybutyKolumnowo : PolecenieBase
    {
        private OpenFileDialog _dialog;

        public PolecenieImportujAtrybutyKolumnowo(MainForm form)
            : base(form)
        {
            _dialog = new OpenFileDialog();
            _dialog.Title = _nazwa;
            _dialog.Filter = "Atrybuty/metadane stałe dla zasięgów (*.xls)|*.xls";
        }

        public override void Wykonaj()
        {
            LayerSchema schemat = _form.Schemat;

            if (schemat == null)
            {
                ShowInfo("Przed importem atrybutów wybierz schemat bazy metadanych.");
                return;
            }

            GeometryLayer zakresy = _form.Zakresy;

            if (zakresy == null)
            {
                ShowInfo("Przed importem atrybutów wczytaj zasięgi.");
                return;
            }

            if (_dialog.ShowDialog(_form) != DialogResult.OK) return;

            try
            {
                schemat.Validate();

                AttributeLayer atrybuty = new AttributeLayer(schemat, _dialog.FileName);
                atrybuty.ImportujExcelKolumnowo();
                
                _form.ImportujAtrybutyKolumnowo(atrybuty);

                ShowInfo(atrybuty.ToString() + "\nPrzypisane atrybuty: " + zakresy.Count);

            }
            catch (Exception ex)
            {
                _form.ImportujAtrybutyKolumnowo(null);
                ShowError(ex.Message);
            }

            _form.AktualizujTytul();
        }
    }
}
