
namespace MetadaneORTO.Polecenia
{
    class PolecenieZakończ : PolecenieBase
    {
        public PolecenieZakończ(MainForm form)
            : base(form)
        {
        }

        public override void Wykonaj()
        {
            _form.Close();
        }
    }
}
