using System;

using MetadaneORTO.Core.Schemat;

namespace MetadaneORTO.Polecenia
{
    class PolecenieEdytujSchemat : PolecenieBase
    {
        public PolecenieEdytujSchemat(MainForm form)
            : base(form)
        {
        }

        public override void Wykonaj()
        {
            LayerSchema schemat = _form.Schemat;

            if (schemat == null) return;

            EdytorSchematu edytor = new EdytorSchematu();
            edytor.Obiekt = schemat;
            edytor.ShowDialog(_form);

            _form.AktualizujNaglowekSchematu();
            _form.AktualizujTytul();

            try
            {
                schemat.Validate();
            }
            catch (Exception ex)
            {
                ShowOstrzezenie("Schemat metadanych zawiera błędy!\n" + ex.Message);
            }
        }
    }
}
