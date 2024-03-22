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
    public partial class UdajeOZahranicniCeste : UserControl
    {
        public UdajeOZahranicniCeste()
        {
            InitializeComponent();
        }

        public int pocet;

        private void numericUpDownPocetZemi_ValueChanged(object sender, EventArgs e)   
        {
            pocet = int.Parse(numericUpDownPocetZemi.Value.ToString());
            zahranici.Vygeneruj(pocet);
        }
    }
}
