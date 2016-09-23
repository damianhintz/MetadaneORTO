using System.Windows.Forms;

using MetadaneORTO.Core.Schemat;

namespace MetadaneORTO.Polecenia
{
    class PolecenieWczytajSchemat : PolecenieBase
    {
        private OpenFileDialog _dialog;

        public PolecenieWczytajSchemat(MainForm form)
            : base(form)
        {
            _dialog = new OpenFileDialog();
            _dialog.Title = _nazwa;
            _dialog.Filter = "Schemat bazy (*.xml)|*.xml";
        }

        public override void Wykonaj()
        {
            DialogResult result = _dialog.ShowDialog(_form);
            
            if (result != DialogResult.OK) return;

            LayerSchema layerSchema = LayerSchema.FromXML(_dialog.FileName);

            _form.NowySchemat(layerSchema);
            _form.AktualizujNaglowekSchematu();
            _form.AktualizujTytul();
        }
    }
}
