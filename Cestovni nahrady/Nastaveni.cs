using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cestovni_nahrady
{
    public partial class Nastaveni : UserControl
    {
        private FileStream fs;

        public Nastaveni()
        {
            InitializeComponent();

            ////Upozornit uživatele pokud se jeho nastavení nevejde do vytyčených hranic
            try
            {
                //Načtení proběhne podle hodnot v souboru
                using (fs = new FileStream("nastaveni.dat", FileMode.Open, FileAccess.Read))
                {
                    BinaryReader br = new BinaryReader(fs);
                    //Privatni sektor
                    numericupordown5az12Priv.Value = new decimal(br.ReadDouble());
                    numericUpDown12az18Priv.Value = new decimal(br.ReadDouble());
                    numericUpDown18aVicePriv.Value = new decimal(br.ReadDouble());
                    //Verejny sektor
                    numericUp5az12Ver.Value = new decimal(br.ReadDouble());
                    numericUp12az18Ver.Value = new decimal(br.ReadDouble());
                    numericUp18aViceVer.Value = new decimal(br.ReadDouble());
                }
            }
            catch (FileNotFoundException)
            {
                //Pokud soubor neexistuje např byl smazán vytvoří se nový s původními hodnotami
                using(fs = new FileStream("nastaveni.dat", FileMode.Create, FileAccess.Write))
                {
                    BinaryWriter bw = new BinaryWriter(fs);
                    //Hodnoty pro privatni sektor
                    bw.Write(140.0);
                    bw.Write(212.0);
                    bw.Write(333.0);
                    //Hodnoty pro verejny sektor
                    bw.Write(140.0);
                    bw.Write(212.0);
                    bw.Write(333.0);
                }           
            }
        }
    }
}
