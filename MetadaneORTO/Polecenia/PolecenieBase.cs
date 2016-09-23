using System.Windows.Forms;

namespace MetadaneORTO.Polecenia
{
    abstract class PolecenieBase
    {
        protected string _nazwa;

        protected MainForm _form;
        protected Form m_form;

        protected PolecenieBase(MainForm form)
        {
            _form = form;
        }
        protected PolecenieBase(Form form)
        {
            m_form = form;
        }

        public void Bind(Control control)
        {
            control.Tag = this;
            _nazwa = control.Text;
        }

        public void Bind(ToolStripItem item)
        {
            item.Tag = this;
            _nazwa = item.Text;
        }

        public abstract void Wykonaj();

        protected void ShowInfo(string text)
        {
            MessageBox.Show(_form,
                text, _nazwa,
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        protected void ShowOstrzezenie(string text)
        {
            MessageBox.Show(_form,
                text, _nazwa,
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        protected void ShowError(string text)
        {
            MessageBox.Show(_form,
                text, _nazwa,
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        protected DialogResult ShowPytanie(string text)
        {
            DialogResult result = MessageBox.Show(_form,
                text, _nazwa,
                MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

            return result;
        }
    }
}
