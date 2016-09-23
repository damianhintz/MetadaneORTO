using System.Windows.Forms;

using MetadaneORTO.Core.Schemat;

namespace MetadaneORTO.Polecenia
{
    class PolecenieZapiszSchemat : PolecenieBase
    {
        private SaveFileDialog _dialog;

        public PolecenieZapiszSchemat(MainForm form)
            : base(form)
        {
            _dialog = new SaveFileDialog();
            _dialog.Title = _nazwa;
            _dialog.Filter = "Schemat bazy (*.xml)|*.xml";
        }

        public override void Wykonaj()
        {
            LayerSchema schemat = _form.Schemat;

            if (schemat == null) return;

            _dialog.FileName = schemat.Name;
            
            DialogResult result = _dialog.ShowDialog(_form);
            
            if (result != DialogResult.OK) return;

            schemat.ToXML(_dialog.FileName);

            _form.AktualizujTytul();
        }
    }
}
