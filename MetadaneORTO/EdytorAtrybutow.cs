using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MetadaneORTO
{
    public partial class EdytorAtrybutow : Form
    {
        private ListViewItem _item;
        private string[] _pola;

        public EdytorAtrybutow(ListViewItem item)
        {
            InitializeComponent();

            _pola = new string[item.SubItems.Count];
            for (int i = 0; i < item.SubItems.Count; i++)
            {
                string name = item.ListView.Columns[i].Name;
                string value = item.SubItems[i].Text;
                mainDataGridView.Rows.Add(new string[] { name, value });
                _pola[i] = value;
            }
            _item = item;
        }

        private void mainDataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            string value = mainDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
            //_item.SubItems[e.RowIndex].Text = value;
            _pola[e.RowIndex] = value;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < _item.SubItems.Count; i++)
            {
                _item.SubItems[i].Text = _pola[i];
            }

            Hide();
        }
    }
}
