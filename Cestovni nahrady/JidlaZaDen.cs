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
    public partial class JidlaZaDen : UserControl
    {
        public JidlaZaDen()
        {
            InitializeComponent();
        }

        public void Vygeneruj(int pocet)
        {
            this.Controls.Clear();

            for(int i = 0; i < pocet; i++)
            {
                Label labelPocetJidel=new Label();
                labelPocetJidel.Size= new Size(160, 15);
                labelPocetJidel.Location = new Point(5, 10 + (i * 30));
                labelPocetJidel.Text = "Počet bezplatných jídel " + (i+1) + ". den: ";

                NumericUpDown numericUpDownPocetJidel = new NumericUpDown();
                numericUpDownPocetJidel.Size = new Size(120, 20);
                numericUpDownPocetJidel.Location = new Point(175, 10 + (i * 30));

                this.Controls.Add(labelPocetJidel);
                this.Controls.Add(numericUpDownPocetJidel);
            }
        }
    }
}
