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
    public partial class Udaje3 : UserControl
    {
        public Udaje3()
        {
            InitializeComponent();
            comboBoxTypPohonnychHmot.SelectedIndex = 0;
            comboBoxPohonneHmotyZpsb.SelectedIndex = 0;
            comboBoxZpusobPrepravy.SelectedIndex = 0;
        }

        private void comboBoxTypPohonnychHmot_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxTypPohonnychHmot.SelectedIndex == 3) labelSpotrebovano.Text = "Spotřebováno v kilowatthodinách:";
            else labelSpotrebovano.Text = "Spotřebováno v litrech:";
        }
    }
}
