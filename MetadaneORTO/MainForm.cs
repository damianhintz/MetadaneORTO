using MetadaneORTO.Core.Atrybuty;
using MetadaneORTO.Core.Metadane;
using MetadaneORTO.Core.Schemat;
using MetadaneORTO.Core.Zakresy;
using MetadaneORTO.Polecenia;
using System;
using System.Windows.Forms;

namespace MetadaneORTO
{
    public partial class MainForm : Form
    {
        public string Tytuł { get { return string.Format("{0} v{1}", Nazwa, Wersja); } }
        public string Nazwa { get { return string.Format("{0}", Application.ProductName); } }
        public string Wersja { get { return string.Format("{0} (2013-04-09)", Application.ProductVersion); } }

        private PolecenieNowySchemat _nowySchemat;
        private PolecenieWczytajSchemat _wczytajSchemat;
        private PolecenieZapiszSchemat _zapiszSchemat;
        private PolecenieEdytujSchemat _edytujSchemat;

        private PolecenieZakończ _zakończ;

        private PolecenieImportujZasięgi _importujZasięgi;
        private PolecenieImportujPunkty _importujPunkty;
        private PolecenieImportujAtrybuty _importujAtrybuty;
        private PolecenieImportujAtrybutyKolumnowo _importujAtrybutyKolumnowo;
        private PolecenieEksportujMetadane _eksportujMetadane;

        private PolecenieInformacje _informacje;

        LayerSchema _schemat = null;
        public LayerSchema Schemat { get { return _schemat; } }

        GeometryLayer _zakresy = null;
        public GeometryLayer Zakresy { get { return _zakresy; } }

        AttributeLayer _atrybuty = null;
        public AttributeLayer Atrybuty { get { return _atrybuty; } }

        public MainForm()
        {
            InitializeComponent();
            InicjowaniePolecen();
            BindowaniePolecen();
        }

        /// <summary>
        /// Tworzenie instancji poleceń powiązanych z tym formularzem.
        /// </summary>
        private void InicjowaniePolecen()
        {
            _nowySchemat = new PolecenieNowySchemat(this);
            _wczytajSchemat = new PolecenieWczytajSchemat(this);
            _zapiszSchemat = new PolecenieZapiszSchemat(this);
            _edytujSchemat = new PolecenieEdytujSchemat(this);
            _zakończ = new PolecenieZakończ(this);
            _importujZasięgi = new PolecenieImportujZasięgi(this);
            _importujPunkty = new PolecenieImportujPunkty(this);
            _importujAtrybuty = new PolecenieImportujAtrybuty(this);
            _importujAtrybutyKolumnowo = new PolecenieImportujAtrybutyKolumnowo(this);
            _eksportujMetadane = new PolecenieEksportujMetadane(this);
            _informacje = new PolecenieInformacje(this);
        }

        /// <summary>
        /// Przypisywanie poleceń do pozycji w menu oraz do istniejących kontrolek.
        /// Właściwość <code>Tag</code>, kontrolki lub pozycji w menu zawiera przypisany obiekt polecenia.
        /// </summary>
        private void BindowaniePolecen()
        {
            _nowySchemat.Bind(nowySchematMenuItem);
            _wczytajSchemat.Bind(wczytajSchematMenuItem);
            _zapiszSchemat.Bind(zapiszSchematMenuItem);
            _edytujSchemat.Bind(edytujSchematMenuItem);
            _zakończ.Bind(zakończMenuItem);
            _importujZasięgi.Bind(importujZasięgiMenuItem);
            _importujPunkty.Bind(importujPunktyMenuItem);
            _importujAtrybuty.Bind(importujAtrybutyMenuItem);
            _importujAtrybutyKolumnowo.Bind(importujAtrybutyKolumnowoMenuItem);
            _eksportujMetadane.Bind(eksportujMetadaneMenuItem);
            _informacje.Bind(informacjeMenuItem);
        }

        private void WykonajPolecenieDlaMenu(object sender, EventArgs e)
        {
            ToolStripItem item = sender as ToolStripItem;
            if (item == null) return;
            WykonajPolecenie(item.Tag);
        }

        private void WykonajPolecenieDlaKontrolki(object sender, EventArgs e)
        {
            Control control = sender as Control;
            if (control == null) return;
            WykonajPolecenie(control.Tag);
        }

        private void WykonajPolecenie(object tag)
        {
            PolecenieBase polecenie = tag as PolecenieBase;
            if (polecenie != null) polecenie.Wykonaj();
        }

        public void AktualizujTytul()
        {
            string title = "";

            if (_schemat != null)
            {
                title = "Schemat [" + _schemat.Name + "]";

                if (_zakresy != null)
                    title += ", Zasięgi [" + _zakresy.LayerName + ":" + _zakresy.Count + "]";

                if (_atrybuty != null)
                    title += ", Atrybuty [" + _atrybuty.LayerName + ":" + _atrybuty.Count + "]";
            }
            else title = "Schemat <brak>";

            Text = Tytuł + " - " + title;
        }

        public void AktualizujNaglowekSchematu()
        {
            mListView.Columns.Clear();

            foreach (LayerField field in _schemat.Fields)
            {
                if (!mListView.Columns.ContainsKey(field.Name))
                {
                    mListView.Columns.Add(field.Name, field.Name);
                }
            }
        }

        public void NowySchemat(LayerSchema schemat)
        {
            _schemat = schemat;
            _zakresy = null;
            _atrybuty = null;
            mListView.Items.Clear();
        }

        public void ImportujZakresy(GeometryLayer zakresy)
        {
            _atrybuty = null;
            _zakresy = zakresy;
            mListView.Items.Clear();

            if (zakresy == null) return;

            foreach (GeometryFeature gf in _zakresy.Features)
            {
                string[] pola = new string[_schemat.Fields.Count];

                int index = mListView.Columns.IndexOfKey(_schemat.AttribKey);
                pola[index] = gf.Value;
                ListViewItem item = new ListViewItem(pola);
                item.Tag = gf;

                mListView.Items.Add(item);
            }
        }

        public void ImportujZintegrowaneZakresy(GeometryLayer zakresy, AttributeLayer atrybuty)
        {
            ImportujZakresy(zakresy);
            ImportujAtrybuty(atrybuty);
        }

        public void ImportujAtrybuty(AttributeLayer atrybuty)
        {
            _atrybuty = atrybuty;

            if (_atrybuty == null) return;

            mListView.Items.Clear();
            _zakresy.ImportujAtrybutyWarstwy(_atrybuty);

            foreach (GeometryFeature gf in _zakresy.Features)
            {
                string[] pola = gf.Attributes.Values;
                ListViewItem item = new ListViewItem(pola);
                item.Tag = gf;

                mListView.Items.Add(item);
            }
        }

        public void ImportujAtrybutyKolumnowo(AttributeLayer atrybuty)
        {
            _atrybuty = atrybuty;

            if (_atrybuty == null) return;

            mListView.Items.Clear();
            _zakresy.ImportujAtrybutyWarstwyKolumnowo(_atrybuty);

            foreach (GeometryFeature gf in _zakresy.Features)
            {
                string[] pola = gf.Attributes.Values;
                ListViewItem item = new ListViewItem(pola);
                item.Tag = gf;

                mListView.Items.Add(item);
            }
        }

        public void EksportujMetadane(MetadataLayer layer)
        {
            foreach (ListViewItem item in mListView.Items)
            {
                item.Selected = true;
                item.EnsureVisible();
                Application.DoEvents();

                string[] pola = new string[item.SubItems.Count];

                for (int i = 0; i < item.SubItems.Count; i++)
                {
                    pola[i] = item.SubItems[i].Text;
                }

                GeometryFeature gf = item.Tag as GeometryFeature;

                if (gf != null)
                {
                    layer.CreateFeature(gf, pola);
                }
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            AktualizujTytul();
        }

        private void EdytorAtrybutow(object sender, EventArgs e)
        {
            foreach (ListViewItem item in mListView.SelectedItems)
            {
                EdytorAtrybutow edytor = new EdytorAtrybutow(item);
                edytor.ShowDialog(this);
            }
        }
    }
}
