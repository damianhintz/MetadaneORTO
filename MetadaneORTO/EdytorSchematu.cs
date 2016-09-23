using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using MetadaneORTO.Core;

namespace MetadaneORTO
{
    public partial class EdytorSchematu : Form
    {
        public object Obiekt
        {
            set
            {
                if (value == null) return;

                mPropertyGrid.SelectedObject = value;
            }
        }

        public EdytorSchematu()
        {
            InitializeComponent();
        }
    }
}
