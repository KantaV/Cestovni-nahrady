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
                numericUpDownPocetJidel.Location = new Point(175, 5 + (i * 30));

                this.Controls.Add(labelPocetJidel);
                this.Controls.Add(numericUpDownPocetJidel);
            }
        }

        public int[] NaplnPoleJidlaZaDen(int delkaCesty,bool jeBezplatneJidlo)
        {
            int[] jidelZaDen = new int[delkaCesty+ 1];
            int pocetNalezenychNumericUpDownu = 0;
            //Naplnim pole jidel za den, kazdy index pole je jeden den
            for (int i = 0; i < this.Controls.Count; i++)
            {
                if (this.Controls[i] is NumericUpDown)
                {
                    if (jeBezplatneJidlo) jidelZaDen[pocetNalezenychNumericUpDownu] = int.Parse((this.Controls[i] as NumericUpDown).Value.ToString());
                    else jidelZaDen[pocetNalezenychNumericUpDownu] = 0;
                    pocetNalezenychNumericUpDownu++;
                }
            }
            return jidelZaDen;
        }
    }
}
