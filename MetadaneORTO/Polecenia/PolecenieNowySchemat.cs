
using MetadaneORTO.Core.Schemat;

namespace MetadaneORTO.Polecenia
{
    class PolecenieNowySchemat : PolecenieBase
    {
        public PolecenieNowySchemat(MainForm form)
            : base(form)
        {
        }

        public override void Wykonaj()
        {
            _form.NowySchemat(new LayerSchema());
            _form.AktualizujNaglowekSchematu();
            _form.AktualizujTytul();
        }
    }
}
