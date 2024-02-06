using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace Cestovni_nahrady
{
    public partial class Zahranici : UserControl
    {
        public Zahranici()
        {
            InitializeComponent();
            StazeniDat();
        }

        List<string> staty;

        private void StazeniDat()
        {
            string url = "https://www.mfcr.cz/cs/kontrola-a-regulace/legislativa/legislativni-dokumenty/2022/vyhlaska-c-462-2021-sb-49677";

            // Stežení obsahu webu
            string htmlObsah = DownloadHtml(url);
            staty = ParseHtml(htmlObsah);
        }

        private static string DownloadHtml(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                return client.GetStringAsync(url).Result;
            }
        }

        private static List<string> ParseHtml(string htmlContent)
        {
            List<string> staty = new List<string>();

            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc.OptionDefaultStreamEncoding = Encoding.UTF8;
            doc.LoadHtml(htmlContent);

            // Vyberu elementy z webu s tagem <tr>
            var castiWebu = doc.DocumentNode.SelectNodes("//tr");

            if (castiWebu != null)
            {
                foreach (var node in castiWebu)
                {
                    // Vyberu jednotlive objekty z webu pomoci hledani stylu
                    string nazevStatu = HttpUtility.HtmlDecode(node.SelectSingleNode(".//td[@class='leftAlign']")?.InnerText?.Trim());
                    string mena = HttpUtility.HtmlDecode(node.SelectSingleNode(".//td[@class='centerAlign']")?.InnerText?.Trim());

                    string styleTag = node.SelectSingleNode(".//td[@class='centerAlign'][@style='white-space:nowrap']")?.InnerText?.Trim();

                    int cenaStatu;
                    // Naplnim promennou, pokud nastane selhani nastavi se na 0
                    if (!int.TryParse(styleTag, out cenaStatu))
                    {
                        cenaStatu = 0; // or any other default value
                    }

                    // Kontrola jestli se naslo jmeno statu
                    if (!string.IsNullOrEmpty(nazevStatu))
                    {
                        staty.Add(nazevStatu + " " + cenaStatu + " " + mena);
                    }
                }
            }
            return staty;
        }

        Panel panelZeme;


        public void Vygeneruj(int pocet)        //Vygeneruje ovládací prvky pro určitý počet navštívených zemí
        {
            this.Controls.Clear();
            for (int i = 0; i < pocet; i++)
            {
                panelZeme = new Panel();
                panelZeme.Width = 500;
                panelZeme.Height = 150;
                panelZeme.Location = new Point(10, (panelZeme.Height + 10) * i);

                ComboBox comboBoxVyberZeme = new ComboBox();
                Label labelVyberZeme = new Label();
                Label labelPrijezd = new Label();
                Label labelOdjezd = new Label();
                DateTimePicker datumPrijezdu = new DateTimePicker();   
                DateTimePicker casPrijezdu = new DateTimePicker();
                DateTimePicker datumOdjezdu = new DateTimePicker();
                DateTimePicker casOdjezdu = new DateTimePicker();

                // 
                // comboBox pro vybrání státu
                // 
                comboBoxVyberZeme.FormattingEnabled = true;
                comboBoxVyberZeme.Location = new Point(51, 17);
                comboBoxVyberZeme.Name = "comboBox1";
                comboBoxVyberZeme.Size = new Size(250, 21);
                comboBoxVyberZeme.TabIndex = 1;
                comboBoxVyberZeme.Items.AddRange(staty.ToArray());
                comboBoxVyberZeme.DropDownStyle = ComboBoxStyle.DropDownList;
                comboBoxVyberZeme.SelectedIndex = 0;
                // 
                // label vyber zemi
                // 
                labelVyberZeme.AutoSize = true;
                labelVyberZeme.Location = new Point(48, 1);
                labelVyberZeme.Name = "label1";
                labelVyberZeme.Size = new Size(100, 15);
                labelVyberZeme.TabIndex = 2;
                labelVyberZeme.Text = "Vyberte zemi " + (i + 1);        
                // 
                // label prijezd
                // 
                labelPrijezd.AutoSize = true;
                labelPrijezd.Location = new Point(4, 65);
                labelPrijezd.Name = "label2";
                labelPrijezd.Size = new Size(41, 13);
                labelPrijezd.TabIndex = 4;
                labelPrijezd.Text = "Příjezd:";
                // 
                // label odjezd
                // 
                labelOdjezd.AutoSize = true;
                labelOdjezd.Location = new Point(4, 98);
                labelOdjezd.Name = "label3";
                labelOdjezd.Size = new Size(40, 13);
                labelOdjezd.TabIndex = 5;
                labelOdjezd.Text = "Odjezd:";
                // 
                // dateTimePicker pro datum prijezdu
                // 
                datumPrijezdu.Location = new Point(51, 63);
                datumPrijezdu.Name = "dateTimePicker1";
                datumPrijezdu.Size = new Size(200, 20);
                datumPrijezdu.TabIndex = 1;
                // 
                // dateTimePicker pro cas prijezdu
                // 
                casPrijezdu.Format = DateTimePickerFormat.Time;
                casPrijezdu.Location = new Point(257, 63);
                casPrijezdu.Name = "dateTimePicker2";
                casPrijezdu.Size = new Size(200, 20);
                casPrijezdu.TabIndex = 2;
                // 
                // dateTimePicker pro datum odjezdu
                // 
                datumOdjezdu.Location = new Point(51, 96);
                datumOdjezdu.Name = "dateTimePicker3";
                datumOdjezdu.Size = new Size(200, 20);
                datumOdjezdu.TabIndex = 3;
                // 
                // dateTimePicker pro cas odjezdu
                // 
                casOdjezdu.Format = DateTimePickerFormat.Time;
                casOdjezdu.Location = new Point(257, 96);
                casOdjezdu.Name = "dateTimePicker4";
                casOdjezdu.Size = new Size(200, 20);
                casOdjezdu.TabIndex = 4;


                panelZeme.Controls.Add(comboBoxVyberZeme);

                panelZeme.Controls.Add(datumPrijezdu);
                panelZeme.Controls.Add(casPrijezdu);

                panelZeme.Controls.Add(datumOdjezdu);
                panelZeme.Controls.Add(casOdjezdu);

                panelZeme.Controls.Add(labelVyberZeme);
                panelZeme.Controls.Add(labelPrijezd);
                panelZeme.Controls.Add(labelOdjezd);

                this.Controls.Add(panelZeme);


            }

        }
    }
}
