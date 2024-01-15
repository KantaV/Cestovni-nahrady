using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cestovni_nahrady
{
    public partial class UdajeStravne : UserControl
    {

        public UdajeStravne()
        {
            InitializeComponent();
            checkBoxBezplatneJidlo.Checked = true;
            comboBoxStravneSektor.SelectedIndex = 0;
        }

        public void Vygeneruj(int pocet)
        {
            jidlaZaDen1.Vygeneruj(pocet);
        }

        private void checkBoxBezplatneJidlo_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxBezplatneJidlo.Checked)
            {
                jidlaZaDen1.Enabled = true;
            }
            else
            {
                jidlaZaDen1.Enabled = false;
            }
        }
    }
}
